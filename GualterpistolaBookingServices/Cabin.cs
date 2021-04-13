using System;
using System.Collections.Generic;
using System.Linq;

namespace GualterpistolaBookingServices.interfaces
{
    public class Cabin : Hotel, interface0
    {
        //atributos
        public string wood { get; set; }

        public Cabin()
        {
            this.wood = "Wood for the fireplace";
        }

        void interface0.Print()
        {
            Console.Write("Wood for the fireplace");
        }
    }
}
