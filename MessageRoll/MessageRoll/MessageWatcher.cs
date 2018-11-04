using NLog;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace WindowsFormsApp
{
    delegate void MessageSendHander(MessageEventArgs e);

    internal class MessageEventArgs : EventArgs
    {
        public string Text;
    }

    class MessageWatcher
    {
        private FileStream fs;
        private FileSystemWatcher fsw;
        private Logger logger = LogManager.GetCurrentClassLogger();
        private long position;

        public ISynchronizeInvoke SynchronizeInvoke { get; set; }
        public string WatchFile { get; set; }
        public MessageSendHander MessageSend { get; set; }

        public void Init()
        {
            logger.Trace("start");

            if (!File.Exists(WatchFile))
            {
                File.Create(WatchFile).Close();
            }

            fs = new FileStream(WatchFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            position = fs.Position;

            fsw = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(WatchFile),
                Filter = Path.GetFileName(WatchFile),
                NotifyFilter = NotifyFilters.LastWrite
            };
            fsw.Changed += new FileSystemEventHandler(Fsw_Changed);
            fsw.SynchronizingObject = SynchronizeInvoke;
            fsw.EnableRaisingEvents = true;
            Action();
            logger.Trace("end");
        }

        public void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            logger.Trace("start");
            fs.Seek(position, SeekOrigin.Begin);
            Action();
            logger.Trace("end");
        }

        public void Dispose()
        {
            logger.Trace("start");
            fs.Close();
            fsw.EnableRaisingEvents = false;
            fsw.Dispose();
            logger.Trace("end");
        }

        private void Action()
        {
            logger.Trace("start");
            int size = 0;
            byte[] bytes = new byte[0x10000];

            size = fs.Read(bytes, 0, bytes.Length);
            while (size != 0)
            {
                byte[] byteText = new byte[size];
                Buffer.BlockCopy(bytes, 0, byteText, 0, size);
                string text = Encoding.UTF8.GetString(byteText);

                foreach (var s in text.Split('\n'))
                {
                    if (s.Length == 0)
                    {
                        continue;
                    }

                    MessageEventArgs cm = new MessageEventArgs
                    {
                        Text = s
                    };
                    MessageSend(cm);
                }

                position += size;

                size = fs.Read(bytes, 0, bytes.Length);
            }
            logger.Trace("end");
        }
    }
}
