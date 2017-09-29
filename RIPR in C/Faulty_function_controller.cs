using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sample.Models;
namespace Sample.Controllers
{
   
    public class Faulty_function_controller : ApiController
    {
        int min = Int32.MinValue;
        
        bool reached = false;
        bool infected = false;
        bool propagated = false;
        public Faulty_function_controller() { }
        public Faulty_function_controller(int min) {
            this.min = min;
        }
        public Boolean[] minimum(int a, int b, int c, int d)
        {
            min = a;


            if (b < min)
            {
                min = b;
            }
            if (c <= min)
            {
                reached = true;
                if (c != min)
                { infected = true; }
                min = b;// fault : should be min =c;
            }
            if (d < min)
            {
                min = d;
            }

            if (min != Math.Min(Math.Min(a, b), Math.Min(c, d)))
            {
                propagated = true;
            }

            bool[] ar = { reached, infected, propagated };
            return ar;

        }

        public int min_value()
        {
            return min;
        }
    }
}
