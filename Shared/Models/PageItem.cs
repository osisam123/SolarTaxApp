using System;
using System.Collections.Generic;
using System.Text;

namespace SolarTaxApp.Shared.Models
{
    public class PageItem
    {
        public string Text { get; set; }
        public int PageIndex { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }

        public PageItem(string text, int pageIndex, bool enabled)
        {
            this.Text = text;
            this.PageIndex = pageIndex;
            this.Enabled = enabled;
        }
    }
}
