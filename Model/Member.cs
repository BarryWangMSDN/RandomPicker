using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPicker.Model
{
    public class Member
    {
        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string alias;

        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }

        private double data;

        public double Data
        {
            get { return data; }
            set { data = value; }
        }

    }
}
