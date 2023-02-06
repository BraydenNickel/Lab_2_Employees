using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork.cs.Entities;

namespace Classwork.cs.Entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public double Rate
        { 
            get { return rate; } 
        }

        public double Hours
        {
            get { return hours; }
        }

        public override double Pay
        {
            get
            {
                double rate = this.Rate;
                double hours = this.Hours;

                double pay = rate * hours;

                return pay;
            }
        }

        public override double PartTimeCount
        {
            get { return PartTimeCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="rate"></param>
        /// <param name="hours"></param>
        public PartTime(string id, string name, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.rate = rate;
            this.hours = hours; 

        }
    }
}
