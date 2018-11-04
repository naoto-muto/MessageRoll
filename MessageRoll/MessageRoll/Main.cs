using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{

    public partial class Main : Form
    {
        private List<Message> messageList = new List<Message>();
        private Logger logger = LogManager.GetCurrentClassLogger();
        private MessageWatcher messageWatcher;

        private Random colorRandom;
        private int maxMessageHeight = 0;

        /// <summary>字幕領域の幅</summary>
        private int MessagePictureWidth { get; set; }

        /// <summary>字幕領域の高さ</summary>
        private int MessagePictureHeight { get; set; }

        private int scrollSpeed;

        partial void MainMessageRoll_Init();
        partial void MainMessageRoll_NextDraw();
        partial void MainMessageRoll_Dispose();

        public Main()
        {
            logger.Trace("start");
            InitializeComponent();

            colorRandom = new Random();

            MessagePictureWidth = 960;
            MessagePictureHeight = 540;
            scrollSpeed = 2;

            MessageSendEvent evt = new MessageSendEvent();
            evt.CommentEventHander += Evt_CommentEventHander;

            MainMessageRoll_Init();

            messageWatcher = new MessageWatcher
            {
                SynchronizeInvoke = this,
                WatchFile = Properties.Settings.Default.WatchFile,
                MessageSend = new MessageSendHander(evt.OnMessageSend)
            };
            messageWatcher.Init();
            logger.Trace("end");
        }

        private void Evt_CommentEventHander(object sender, MessageEventArgs e)
        {
            logger.Trace("start");

            var height = MessagePictureHeight;
            int textY = 0;
            int rgb = colorRandom.Next(0xFFFFFF);
            float fontSize = Properties.Settings.Default.FontSize;

            if (height > maxMessageHeight)
            {
                textY = height;
                maxMessageHeight = height + (int)fontSize;
            }
            else
            {
                textY = maxMessageHeight;
                maxMessageHeight += (int)fontSize;
            }
            logger.Debug("maxMessageHeight:{0}", maxMessageHeight);

            var label = new Message()
            {
                Text = e.Text,
                Left = 2,
                Top = textY,
                ForeColor = Color.FromArgb(255, (rgb >> 16) & 0xFF, (rgb >> 8) & 0xFF, rgb & 0xFF),
                FontSize = fontSize
            };

            messageList.Add(label);

            logger.Trace("end");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            logger.Trace("start");
            Size borderSize = SystemInformation.BorderSize + SystemInformation.FrameBorderSize + SystemInformation.FixedFrameBorderSize;
            Width = MessagePictureWidth + borderSize.Width * 2;
            Height = MessagePictureHeight + SystemInformation.CaptionHeight + borderSize.Height * 2;

            ScrollTimer.Start();
            logger.Trace("end");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Trace("start");
            MainMessageRoll_Dispose();
            ScrollTimer.Stop();
            ScrollTimer.Dispose();
            logger.Trace("end");
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            logger.Trace("start");
            messageList.ForEach((s) => {
                s.Top -= scrollSpeed;
            });
            maxMessageHeight -= Math.Max(maxMessageHeight - scrollSpeed, MessagePictureHeight);

            MainMessageRoll_NextDraw();
            logger.Trace("end");
        }

    }
}
