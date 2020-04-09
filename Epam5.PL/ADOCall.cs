using Epam5.ADODAL.Interfaces;
using Epam5.ADODAL.Repositories;
using Epam5.BLL.Interfaces;
using Epam5.BLL.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Epam5.PL
{
    class ADOCall
    {
        public static void MENU()
        {
            IUnitOfWork uof = new ADOUnitOfWork();
            IService service = new ADOService(uof);
            MethodInfo[] methodInfos = typeof(ADOService)
                .GetMethods();
            while (true)
            {
                service.OutputAllData();
                Console.WriteLine();
                int i = 1;
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    if (methodInfo.Name.StartsWith("G") && methodInfo.Name.Length > 11)
                    {
                        Console.WriteLine($"{i++}) {methodInfo.Name}");
                    }
                }
                Console.Write("Enter menu item: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        var res = service.GetProductsByCategory(1);
                        foreach (var e in res)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 2:
                        var res1 = service.GetProductsByPrice(200);
                        foreach (var e in res1)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 3:
                        var res2 = service.GetProductsByVendor(3);
                        foreach (var e in res2)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 4:
                        var res3 = service.GetVendorsByCategory(3);
                        foreach (var e in res3)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 5:
                        var res4 = service.GetVendorsByCity("Lviv");
                        foreach (var e in res4)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    default: Console.WriteLine("There are not such item in a menu!"); break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
