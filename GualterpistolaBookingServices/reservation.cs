using System;
using System.Collections.Generic;
using System.Linq;

namespace GualterpistolaBookingServices.interfaces
{
    public class reservation
    {
        //atributos
        public string name { get; set; }
        public string DUI { get; set; }
        public string tipeReservation { get; set; }
        public string paymentType { get; set; }
        public Hotel hotel { get; set; }
        public Cabin cabin { get; set; }
        public Hut hut { get; set; }

        //contructores //sobrecarga 1
        public reservation(string name, string DUI, Hotel hotel, string paymentType)
        {
            this.name = name;
            this.DUI = DUI;
            this.tipeReservation = "Hotel";
            this.hotel = hotel;
            this.paymentType = paymentType;
        }

        public reservation(string name, string DUI, Cabin cabin, string paymentType)
        {
            this.name = name;
            this.DUI = DUI;
            this.tipeReservation = "Cabin";
            this.cabin = cabin;
            this.paymentType = paymentType;
        }

        public reservation(string name, string DUI, Hut hut, string paymentType)
        {
            this.name = name;
            this.DUI = DUI;
            this.tipeReservation = "Hut";
            this.hut = hut;
            this.paymentType = paymentType;
        }
    }
}
