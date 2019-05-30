using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Sensor
    {
        public string Name { get; set; }
        public SensorTypeEnum Type { get; set; }
        public virtual Location Location { get; set; }
        public virtual SensorCenter SensorCenter { get; set; }
    }
}
