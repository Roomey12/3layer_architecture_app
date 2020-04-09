using Epam5.BLL.Interfaces;
using Epam5.BLL.Services;
using Epam5.EFDAL.EF;
using Epam5.EFDAL.Repositories;
using Epam5.ADODAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Epam5.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Entity Framework Core\n2. ADO.NET");
            Console.Write("Enter menu item:");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (key)
            {
                case 1:
                    EFCall.MENU();
                    break;
                case 2:
                    ADOCall.MENU();
                    break;
                default:
                    Console.WriteLine("There are no such menu item! Please try again!");
                    break;
            }
        }
    }
}
