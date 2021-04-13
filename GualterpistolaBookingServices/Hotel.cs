using System;
using System.Collections.Generic;
using System.Linq;

namespace GualterpistolaBookingServices.interfaces
{
    public class Hotel : interface0
    {
        //atributos
        public string key { get; set; }

        public Hotel()
        {
            this.key = "Key";
        }

        void interface0.Print()
        {
            Console.Write("Key");
        }
    }
}
