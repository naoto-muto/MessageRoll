using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MessageRoll.Operate
{
    public partial class OperateForm : Form
    {
        private FontStyle fontStyle = FontStyle.Regular;

        internal MessageSendHandler MessageSend { get; set; }
        internal ConfigHandler Config { get; set; }

        private Logger logger = LogManager.GetCurrentClassLogger();

        private Color bef_ChromakeyColor;
        private string bef_FontFamilyName;
        private FontStyle bef_FontStyle;
        private Color bef_ForeColor;
        private string bef_FontSize;
        private bool bef_RandomColor;


        public OperateForm()
        {
            InitializeComponent();
        }

        private void OperateForm_Load(object sender, EventArgs e)
        {
            logger.Trace("start");

            bef_ChromakeyColor = ChromakeyPictureBox.BackColor;
            bef_FontFamilyName = "MS UI Gothic";
            bef_FontStyle = FontStyle.Regular;
            bef_ForeColor = FontColorPictureBox.BackColor;
            bef_FontSize = "9";

            fontStyle = bef_FontStyle;

            FontFamilyTextField.Text = bef_FontFamilyName;
            FontFamilyTextField.Font = new Font(bef_FontFamilyName, float.Parse(bef_FontSize) , bef_FontStyle);
            FontSizeTextField.Text = bef_FontSize;

            logger.Trace("end");
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            logger.Trace("start");

            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                FontColorPictureBox.BackColor = ColorDialog.Color;
            }

            logger.Trace("end");
        }

        private void FontFamilyButton_Click(object sender, EventArgs e)
        {
            logger.Trace("start");

            if (FontDialog.ShowDialog() == DialogResult.OK)
            {
                fontStyle = FontStyle.Regular;
                if(FontDialog.Font.Bold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (FontDialog.Font.Italic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                if (FontDialog.Font.Underline)
                {
                    fontStyle |= FontStyle.Underline;
                }
                if (FontDialog.Font.Strikeout)
                {
                    fontStyle |= FontStyle.Strikeout;
                }

                FontFamilyTextField.Text = FontDialog.Font.Name;
                FontFamilyTextField.Font = new Font(FontDialog.Font.FontFamily , 9f, fontStyle);
                FontSizeTextField.Text = FontDialog.Font.Size.ToString("#");
            }

            logger.Trace("end");
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            logger.Trace("start");

            MessageSend(new MessageEventArgs()
            {
                Text = MessageTextField.Text,
                FontColor = FontColorPictureBox.BackColor,
                FontFamilyName = FontFamilyTextField.Text,
                FontStyle = fontStyle,
                FontSize = float.Parse(FontSizeTextField.Text)
            });

            logger.Trace("end");
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            logger.Trace("start");

            FontFamilyTextField.Text = bef_FontFamilyName;
            FontFamilyTextField.Font = new Font(bef_FontFamilyName, 9f, bef_FontStyle);
            FontSizeTextField.Text = bef_FontSize;
            FontColorPictureBox.BackColor = bef_ForeColor;
            fontStyle = bef_FontStyle;

            ConstRadio.Checked = !bef_RandomColor;
            RandomRadio.Checked = bef_RandomColor;

            logger.Trace("end");
        }

        private void ChromakeyButton_Click(object sender, EventArgs e)
        {
            logger.Trace("start");

            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                ChromakeyPictureBox.BackColor = ColorDialog.Color;
            }

            logger.Trace("end");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            logger.Trace("start");

            bef_ChromakeyColor = ChromakeyPictureBox.BackColor;
            bef_RandomColor = RandomRadio.Checked;
            bef_ForeColor = FontColorPictureBox.BackColor;
            bef_FontFamilyName = FontFamilyTextField.Text;
            bef_FontStyle = fontStyle;
            bef_FontSize = FontSizeTextField.Text;

            Config(new ConfigEventArgs()
            {
                ChromakeyColor = bef_ChromakeyColor,
                RandomColor = bef_RandomColor,
                FontColor = bef_ForeColor,
                FontFamily = bef_FontFamilyName,
                FontStyle = bef_FontStyle,
                FontSize = float.Parse(bef_FontSize)
            });

            logger.Trace("end");
        }

        private void OperateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
