﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork.cs.Entities;

namespace Classwork.cs.Entities
{
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
        }

        public override double Pay
        {
            get { return salary; }
        }

        public override double SalariedCount
        {
            get { return SalariedCount; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="salary"></param>


        public Salaried(string id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
    }
}
