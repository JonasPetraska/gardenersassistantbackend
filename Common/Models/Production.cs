using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Production
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public virtual Garden Garden { get; set; }
    }
}
