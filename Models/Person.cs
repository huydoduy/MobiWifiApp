using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiWifiApp.Models
{
    public  class Person
    {
        public  int Id { get; set; }
        public string hoten { get; set; }

       public Person(int Id,string hoten)
        {
            this.hoten = hoten;
            this.Id = Id;

        }

        public Person()
        {
        }
    }
}
