using SimplerTrader.Domain;
using SimplerTrader.Domain.Models;
using SimpleTrader.EF;
using SimpleTrader.EF.Services;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());

            Console.WriteLine($"Nombre d'enregistrements : {userService.GetAll().Result.Count()}");
            userService.Create(new User { Username = $"user_{new Random().Next(10000).ToString("D5")}" });
            Console.WriteLine($"Nombre d'enregistrements : {userService.GetAll().Result.Count()}");

            userService.Update(2, new User { Username = $"user_{new Random().Next(10000).ToString("D5")}" });

            Console.WriteLine("Appuyez sur un touche pour continuer...");
            Console.ReadKey();
        }
    }
}
