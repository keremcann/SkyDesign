using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Core.ComplexTypes
{
    public struct HtmlInputTypes
    {
        private HtmlInputTypes(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static readonly HtmlInputTypes Button = new(1, "Button");
        public static readonly HtmlInputTypes Checkbox = new(2, "Checkbox");
        public static readonly HtmlInputTypes Color = new(3, "Color");
        public static readonly HtmlInputTypes Date = new(4, "Date");
        public static readonly HtmlInputTypes DatetimeLocal = new(5, "DatetimeLocal");
        public static readonly HtmlInputTypes Email = new(6, "Email");
        public static readonly HtmlInputTypes File = new(7, "File");
        public static readonly HtmlInputTypes Hidden = new(8, "Hidden");
        public static readonly HtmlInputTypes Image = new(9, "Image");
        public static readonly HtmlInputTypes Month = new(10, "Month");
        public static readonly HtmlInputTypes Number = new(11, "Number");
        public static readonly HtmlInputTypes Password = new(12, "Password");
        public static readonly HtmlInputTypes Radio = new(13, "Radio");
        public static readonly HtmlInputTypes Range = new(14, "Range");
        public static readonly HtmlInputTypes Reset = new(15, "Reset");
        public static readonly HtmlInputTypes Search = new(16, "Search");
        public static readonly HtmlInputTypes Submit = new(17, "Submit");
        public static readonly HtmlInputTypes Tel = new(18, "Tel");
        public static readonly HtmlInputTypes Text = new(19, "Text");
        public static readonly HtmlInputTypes Time = new(20, "Time");
        public static readonly HtmlInputTypes Url = new(21, "Url");
        public static readonly HtmlInputTypes Week = new(22, "Week");
    }
}