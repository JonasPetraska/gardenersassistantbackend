using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Points { get; set; }

        public void SetPoints(List<Tuple<double, double>> points)
        {
            Points = string.Join(";", points.Select(x => "(" + x.Item1.ToString("N2") + "," + x.Item2.ToString("N2") + ")").ToList());
        }

        public List<Tuple<double, double>> GetPoints()
        {
            var res = new List<Tuple<double, double>>();
            var splitString = Points.Split(';');

            foreach(var str in splitString)
            {
                var trimedString = str.Trim(new char[] { '(', ')' });
                var splitString2 = trimedString.Split(',');
                var item1 = ParseDouble(splitString2[0]);
                var item2 = ParseDouble(splitString2[1]);
                res.Add(new Tuple<double, double>(item1, item2));
            }

            return res;
        }

        private double ParseDouble(string dbl)
        {
            var parsed = double.TryParse(dbl, out var res);
            if (parsed)
                return res;
            return 0;
        }

    }
}
