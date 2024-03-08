using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator_BMI
{
    public class BMI
    {
        public Guid Guid { get; set; }
        public String Sex { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public double Bmi { get; set; }
        public string Score { get; set; }
        public override string ToString()
        {
            return $"{Guid.ToString()};{Sex};{Weight};{Height};{Bmi};{Score}";
        }

        public static BMI fromString(string s)
        {
            string[] props = s.Split(';');
            return new BMI()
            {
                Guid = Guid.Parse(props[0]),
                Sex = props[1],
                Weight = int.Parse(props[2]),
                Height = double.Parse(props[3]),
                Bmi = double.Parse(props[4]),
                Score  = props[5]
            };
        }
    }
}
