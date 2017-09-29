using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class Fault_function
    {
        public int Min { get;}
       public bool Reached { get; set; }
        public bool Infected { get; set; }
        public bool Propogated{ get; set; }

    }
}