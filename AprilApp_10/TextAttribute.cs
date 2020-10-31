using System;

namespace AprilApp_10
{
    class TextAttribute:Attribute
    {
        public string text { get; set; }

        public TextAttribute() { }

        public TextAttribute(string strText)
        {
            text = strText;
        }
    }
}
