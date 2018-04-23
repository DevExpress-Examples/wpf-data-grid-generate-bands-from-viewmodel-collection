using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXGridSample
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Bool { get; set; }
    }

    public class BandItem
    {
        public string BandHeader
        {
            get;
            set;
        }
        public List<ColumnItem> Columns
        {
            get;
            set;
        }
    }
    public class ColumnItem
    {
        public string ColumnFieldName
        {
            get;
            set;
        }
    }
}
