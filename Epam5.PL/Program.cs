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
            using ApplicationContext db = new ApplicationContext();
            ADOUnitOfWork auof = new ADOUnitOfWork();
            //EFUnitOfWork sas = (EFUnitOfWork)auof;
            EFUnitOfWork uof = new EFUnitOfWork(db);
            Console.WriteLine(uof.GetType().Name);
            Service s = new Service(uof);
            s.OutputAllData();
            var res = s.GetVendorsByCategory(3);
            foreach(var e in res)
            {
                Console.WriteLine(e);
            }
        }
    }
}
