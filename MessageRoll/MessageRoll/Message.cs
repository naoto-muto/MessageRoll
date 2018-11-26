using System.Drawing;

namespace MessageRoll
{
    class Message
    {
        public string Text { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public Color ForeColor { get; set; }
        public float FontSize { get; set; }
        public string FontFamilyName { get; set; }
        public FontStyle FontStyle { get; set; }
    }
}
