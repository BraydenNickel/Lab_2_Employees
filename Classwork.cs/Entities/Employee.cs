using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork.cs.Entities;

namespace Classwork.cs.Entities
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;
        protected string phone;
        protected long sin;
        protected string birthday;
        protected string department;

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get => name;
        }

       public virtual double Pay
        {
            get { return 0; }
        }

       public virtual double SalariedCount
        {
            get { return 0; }
        }

        public virtual double WagesCount
        {
            get { return 0; }
        }

        public virtual double PartTimeCount
        {
            get { return 0; }
        }

        public Employee(string id, string name, string address, string phone, long sin, string birthday, string department)

        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthday = birthday;
            this.department = department;
        }

    }
}
