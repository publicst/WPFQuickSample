using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFQuickSample
{
    public class Range
    {
        public string[] ItemsSource { get; private set; }

        public Range()
        {
            ItemsSource = new string[] { ">", "=", "<" };
        }
    }
}
