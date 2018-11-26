using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MessageRoll
{
    internal delegate void ConfigHandler(ConfigEventArgs e);

    public partial class Main : Form
    {

        private List<Message> messageList = new List<Message>();
        private Logger logger = LogManager.GetCurrentClassLogger();
        private MessageWatcher messageWatcher;
        private Operate.OperateForm operateForm;
        private Random colorRandom;
        private int maxMessageHeight = 0;

        private Color default_ChromakeyColor;
        private Color default_FontColor;
        private string default_FontFamily = "MS UI Gothic";
        private FontStyle default_FontStyle;
        private float default_FontSize = 9f;
        private bool default_RandomColor = true;

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
            scrollSpeed = Properties.Settings.Default.MessageSpeed;

            MessageSendEvent evt = new MessageSendEvent();
            evt.CommentEventHander += Evt_CommentEventHander;

            ConfigEvent confEvt = new ConfigEvent();
            confEvt.ConfigEventHander += ConfEvt_ConfigEventHander;

            MainMessageRoll_Init();

            messageWatcher = new MessageWatcher
            {
                SynchronizeInvoke = this,
                WatchFile = Properties.Settings.Default.WatchFile,
                MessageSend = new MessageSendHandler(evt.OnMessageSend)
            };
            messageWatcher.Init();

            operateForm = new Operate.OperateForm()
            {
                MessageSend = new MessageSendHandler(evt.OnMessageSend),
                Config = new ConfigHandler(confEvt.OnMessageSend)
            };
            logger.Trace("end");
        }

        private void ConfEvt_ConfigEventHander(object sender, ConfigEventArgs e)
        {
            if (!default_ChromakeyColor.Equals(e.ChromakeyColor))
            {
                default_ChromakeyColor = e.ChromakeyColor;

                brush.Dispose();
                brush = new SolidBrush(default_ChromakeyColor);

                destGraphics.FillRectangle(brush, 0, 0, MessagePictureWidth, MessagePictureHeight + bufHeight);
            }

            default_FontColor = e.FontColor;
            default_FontFamily = e.FontFamily;
            default_FontStyle = e.FontStyle;
            default_FontSize = e.FontSize;
            default_RandomColor = e.RandomColor;
        }

        private void Evt_CommentEventHander(object sender, MessageEventArgs e)
        {
            logger.Trace("start");

            var height = MessagePictureHeight;
            int textY = 0;
            int rgb = colorRandom.Next(0xFFFFFF);
            float fontSize = e.FontSize == 0f ? default_FontSize : e.FontSize;

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

            var foreColor = default_RandomColor ? Color.FromArgb(255, (rgb >> 16) & 0xFF, (rgb >> 8) & 0xFF, rgb & 0xFF) :
                e.FontColor.IsEmpty ? default_FontColor : e.FontColor;

            var label = new Message()
            {
                Text = e.Text,
                Left = 2,
                Top = textY,
                ForeColor = foreColor,
                FontSize = fontSize,
                FontFamilyName = e.FontFamilyName ?? default_FontFamily,
                FontStyle = e.FontStyle == 0 ? default_FontStyle : e.FontStyle
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

            default_ChromakeyColor = Color.FromArgb(255, 0, 255, 0);
            operateForm.Show();

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
