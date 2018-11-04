using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Main : Form
    {
        private Brush brush;
        private FontFamily ff; 
        private Bitmap srcBitmap;
        private Bitmap destImage;
        private Graphics srcGraphics; 
        private Graphics destGraphics;

        private static int bufHeight = 100;

        partial void MainMessageRoll_Init()
        {
            logger.Trace("start");
            brush = new SolidBrush(Color.FromArgb(255, 8, 8, 8));
            ff = new FontFamily("consolas");
            srcBitmap = new Bitmap(MessagePictureWidth, MessagePictureHeight + bufHeight);
            destImage = new Bitmap(MessagePictureWidth, MessagePictureHeight + bufHeight);
            srcGraphics = Graphics.FromImage(srcBitmap);
            destGraphics = Graphics.FromImage(destImage);
            logger.Trace("end");
        }


        partial void MainMessageRoll_NextDraw()
        {
            logger.Trace("start");
            Graphics pictureboxGraphics = MessagePictureBox.CreateGraphics();

            srcGraphics.FillRectangle(brush, 0, 0, MessagePictureWidth, MessagePictureHeight + bufHeight);
            srcGraphics.DrawImage(destImage, 0, -scrollSpeed);

            var delList = new List<Message>();

            foreach (var l in messageList)
            {
                if (l.Top < MessagePictureHeight)
                {
                    GraphicsPath gp = new GraphicsPath();
                    Pen pen = new Pen(Color.Black, 1);
                    gp.AddString(l.Text, ff, 1, l.FontSize, new Point(l.Left, l.Top), StringFormat.GenericDefault);
                    srcGraphics.FillPath(new SolidBrush(l.ForeColor), gp);

                    srcGraphics.DrawPath(Pens.Black, gp);

                    pen.Dispose();
                    gp.Dispose();

                    delList.Add(l);
                }
            }

            foreach (var l in delList)
            {
                messageList.Remove(l);
            }

            destGraphics.DrawImage(srcBitmap, 0, 0);
            pictureboxGraphics.DrawImage(destImage, 0, 0);

            pictureboxGraphics.Dispose();
            logger.Trace("end");
        }

        partial void MainMessageRoll_Dispose()
        {
            logger.Trace("start");
            destGraphics.Dispose();
            srcGraphics.Dispose();
            destImage.Dispose();
            srcBitmap.Dispose();
            ff.Dispose();
            brush.Dispose();
            logger.Trace("end");
        }
    }
}
