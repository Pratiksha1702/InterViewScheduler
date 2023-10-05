using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterViewScheduler
{
    public class DropDownItem
    {
        public string Text { get; set; }
        public Image Image { get; set; }

        public string ColorRGB { get; set; }

       public DropDownItem(string textValue , Image imageValue, string colorrgb)
        {
            Text = textValue;
            Image = imageValue;
            ColorRGB = colorrgb;
        }
    }
}
