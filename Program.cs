using System;
using System.Collections.Generic;
using System.Linq;

namespace bookOffers
{
    internal class Program
    {
        public static void Main()
        {
            if (int.TryParse(Console.ReadLine(), out var notifications))
            {
                var book = new Dictionary<int, Offer>();

                for (var i = 0; i < notifications; i++)
                {
                    var notification = Console.ReadLine()?.Split(',');
                    if (notification == null || notification.Length != 4)
                    {
                        Console.WriteLine("Dados Inválidos. Forneça as notificações corretamente!");
                        return;
                    }
                    
                    if (int.TryParse(notification[0], out var position) &&
                        int.TryParse(notification[1], out var action) &&
                        double.TryParse(notification[2], out var value) &&
                        int.TryParse(notification[3], out var quantity))
                    {
                        ProcessNotification(book, position, action, value, quantity);
                    }
                    else
                    {
                        Console.WriteLine("Notificação com formato inválido. Fornecer valores numéricos corretos.");
                        return;
                    }
                }
                
                var sortedBook = book.OrderBy(x => x.Key);
                
                foreach (var offer in sortedBook)
                {
                    Console.WriteLine($"{offer.Key},{offer.Value.Value},{offer.Value.Quantity}");
                }
            }
            else
            { 
                Console.WriteLine("Número de notificações inválido. Fornecer um valor inteiro válido.");
            }
        }
        
        private static void ProcessNotification(IDictionary<int, Offer> book, int position, int action, double value, int quantity)
        {
            switch (action)
            {
                case 0:
                    book[position] = new Offer(value, quantity);
                    break;
                case 1:
                    if (book.ContainsKey(position))
                    {
                        book[position].Value = value;
                        book[position].Quantity = quantity;
                    }
                    break;
                case 2:
                    book.Remove(position);
                    break;
                default:
                    Console.WriteLine($"Ação desconhecida: {action}.");
                    break;
            }
        }
    }

    public class Offer
    {
        public double Value { get; set; }
        public double Quantity { get; set; }

        public Offer(double value, int quantity)
        {
            Value = value;
            Quantity = quantity;
        }
    }
}