using System;
using System.Collections.Generic;

namespace GualterpistolaBookingServices.interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<reservation> reservations = new List<reservation>();
            List<reservation> hostedClients = new List<reservation>();
            List<reservation> storedReservations = new List<reservation>();

            var continueDo = true;
            int numReservation = 1;
            
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("-- Wellcome to Gualterpistola Booking Services --");
                Console.WriteLine(" 1) Make a reservation");
                Console.WriteLine(" 2) arrive to the reserved");
                Console.WriteLine(" 3) Show hosted clients");
                Console.WriteLine(" 4) leave reserved rom");
                Console.WriteLine(" 5) Show stored reservations");
                Console.WriteLine(" 6) Exit");
                Console.Write("\tOpción: ");
                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1 : MakeReservation(reservations, numReservation, storedReservations); numReservation++; break;
                    case 2 : ArriveToTheReserved(reservations, hostedClients); break;
                    case 3 : ShowHostedClients(hostedClients); break;
                    case 4 : LeaveReservedRom(hostedClients); break;
                    case 5 : ShowStoredReservations(storedReservations); break;
                    case 6 : continueDo = false; break;
                    default: Console.WriteLine("Opcion errónea!\n"); break;
                }
            }while(continueDo);
        }

        static public void MakeReservation(List<reservation> reservations, int numReservation, List<reservation> storedReservations)
        {
            //este numero es la key de la reservacion y aumentara cuando se realize una nueva reservacion
            
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("(Write the DUI with hyphen)");
            Console.Write($"DUI of {name}: ");
            var DUI = Console.ReadLine();

            var continueDo = true;
            string payment = "";
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Tipe Reservation");
                Console.WriteLine(" 1) Hotel");
                Console.WriteLine(" 2) Cabin");
                Console.WriteLine(" 3) Hun");
                Console.Write("Opción: ");
                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1 : 
                        payment = PaymentType();
                        Hotel hotel0 = new Hotel();
                        
                        reservation reservation0 = new reservation(name, DUI, hotel0, payment);
                        reservations.Add(reservation0);
                        storedReservations.Add(reservation0);
                        continueDo = false; break;

                    case 2 : 
                        payment = PaymentType();
                        Cabin hotel1 = new Cabin();
                        reservation reservation1 = new reservation(name, DUI, hotel1, payment);
                        reservations.Add(reservation1);
                        storedReservations.Add(reservation1);
                        continueDo = false; break;

                    case 3 : 
                        payment = PaymentType();
                        Hut hotel2 = new Hut();
                        reservation reservation2 = new reservation(name, DUI, hotel2, payment);
                        reservations.Add(reservation2);
                        storedReservations.Add(reservation2);
                        continueDo = false; break;
                        
                    default: Console.WriteLine("Opcion errónea!\n"); break;
                }
            }while(continueDo);
        }

        static public string PaymentType()
        {
            var continueDo = true;
            
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Payment Type");
                Console.WriteLine(" 1) Card");
                Console.WriteLine(" 2) Cash");
                Console.Write("Opción: ");
                int option = Int32.Parse(Console.ReadLine());
                
                switch (option)
                {
                    case 1 : return "Card";
                    case 2 : return "Cash";
                    default: Console.WriteLine("Opcion errónea!\n"); break;
                }
            }while(continueDo);

            //esta linea la puse porque da error sin ella :V
            //pero en realidad nunca pasario por aqui 
            return "";
        }

        static public void ArriveToTheReserved(List<reservation> reservations, List<reservation> hostedClients)
        {
            var keyReservation = 0;
            var continueDo = true;
            
            do
            {
                //mostra la lista de reservacions
                printResrvations(reservations);

                Console.Write("-> Enter the ID to enter: ");
                keyReservation = Int32.Parse(Console.ReadLine());

                if(keyReservation < 1)                
                    Console.WriteLine("Opcion errónea!\n");

                else if(keyReservation > reservations.Count)                
                    Console.WriteLine("Opcion errónea!\n");

                else
                    continueDo = false;
                
            }while(continueDo);

            hostedClients.Add(reservations[keyReservation-1]);
            reservations.RemoveAt(keyReservation-1);
        }

        static public void printResrvations(List<reservation> reservations)
        {
            Console.WriteLine("/ ID   / Name      / DUI      / Tipe Reservation    / Payment Type");
            reservations.ForEach(reservation0 => 
            {
                Console.WriteLine($"/-> {reservation0.name}\t/ {reservation0.DUI}\t/ {reservation0.tipeReservation}\t/ {reservation0.paymentType}");
            });
        }

        static public void LeaveReservedRom(List<reservation> hostedClients)
        {
            //mostra la lista de reservacions
            printResrvations(hostedClients);

            Console.Write("-> Enter the ID to delete: ");
            int option = Int32.Parse(Console.ReadLine());

            reservation reservation0 = hostedClients[option-1];

            Console.WriteLine($"/-> {reservation0.name}\t/ {reservation0.DUI}\t/ {reservation0.tipeReservation}\t/ {reservation0.paymentType}");
            if(reservation0.tipeReservation == "Hotel")
                    Console.Write($"regreso: {reservation0.hotel.key}\n");
                else if(reservation0.tipeReservation == "Cabin")
                    Console.Write($"regreso: {reservation0.cabin.key}, {reservation0.cabin.wood}\n");
                else if(reservation0.tipeReservation == "Hut")
                    Console.Write($"regreso: {reservation0.hut.key}, {reservation0.hut.wood}, {reservation0.hut.oils}\n");
            //hostedClients.RemoveAll(Clients => Clients.RemoveVocal(Clients));
            hostedClients.RemoveAt(option-1);
        }

        static public void ShowStoredReservations(List<reservation> showStoredReservations)
        {
            Console.WriteLine("/ ID   / Name      / DUI      / Tipe Reservation    / Payment Type");
            showStoredReservations.ForEach(reservation0 => 
            {
                Console.WriteLine($"/-> {reservation0.name}\t/ {reservation0.DUI}\t/ {reservation0.tipeReservation}\t/ {reservation0.paymentType}");
            });
        }

        static public void ShowHostedClients(List<reservation> hostedClients)
        {
            
            //foreach (reservation reservation0 in hostedClients)
            Console.WriteLine("/ ID   / Name      / DUI      / Tipe Reservation    / Payment Type   / key and accessories");
            hostedClients.ForEach(reservation0 => 
            {
                
                Console.WriteLine($"/-> {reservation0.name}\t/ {reservation0.DUI}\t/ {reservation0.tipeReservation}\t/ {reservation0.paymentType}");
                
                if(reservation0.tipeReservation == "Hotel")
                    Console.Write($"{reservation0.hotel.key}\n");
                else if(reservation0.tipeReservation == "Cabin")
                    Console.Write($"{reservation0.cabin.key}, {reservation0.cabin.wood}\n");
                else if(reservation0.tipeReservation == "Hut")
                    Console.Write($"{reservation0.hut.key}, {reservation0.hut.wood}, {reservation0.hut.oils}\n");
            });
            
        }
    }
}
