using System;
using System.Collections.Generic;
using System.Linq;

namespace GualterpistolaBookingServices.interfaces
{
    public class Hut : Cabin, interface0
    {
        //atributos
        public string oils { get; set; }

        public Hut()
        {
            this.oils = "Aromatic oils";
        }

        void interface0.Print()
        {
            Console.Write("Aromatic oils");
        }
    }
}
