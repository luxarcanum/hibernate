using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using AWHibernateTestApp.Models;
using NHibernate.Criterion;

namespace AWHibernateTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.SetProperty("dialect", "NHibernate.Dialect.MsSql2012Dialect");
            cfg.SetProperty("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
            cfg.SetProperty("connection.connection_string", "Server=n131dopsvrsql11;Initial Catalog=Development_Testing;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            cfg.AddAssembly("AWHibernateTestApp");
            ISessionFactory dbSession = cfg.BuildSessionFactory();
            */

            ISessionFactory dbSession = new Configuration().Configure().BuildSessionFactory();
            ISession session = dbSession.OpenSession();

            using (var transaction = session.BeginTransaction())
            {
                Console.WriteLine("starting");
                // return recordset with criteria
                var needs = session.CreateCriteria<NeedRequirement>()
                    .Add(Restrictions.Like("Need_LOB", "CBH%"));

                foreach (var need in needs.List<NeedRequirement>())
                {
                    Console.WriteLine("{0} \t{1:yyyy/dd/MM} \t{2} \t{3} \t{4}", need.Id, DateTime.Parse(need.Need_Date), need.Need_LOB, need.ts_0700, need.ts_0730);
                }
                Console.WriteLine("Next");

                /*
                // Return full dataset
                IList<NeedRequirement> needfull = session.Query<NeedRequirement>().ToList(); //  Select Query
                Console.WriteLine("Record Count: " + needfull.Count);
                Console.WriteLine("Full Dataset");
                foreach (var need in needfull)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", need.Id, need.Need_Date, need.Need_LOB, need.ts_0700, need.ts_0730);
                }

                // Return specific record
                Console.WriteLine("<Get>Specific Record by Id?");
                int zz = int.Parse(Console.ReadLine());
                var specNeed = session.Get<NeedRequirement>(System.Convert.ToInt64(zz));
                Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", specNeed.Id, specNeed.Need_Date, specNeed.Need_LOB, specNeed.ts_0700, specNeed.ts_0730);

                //update Record by ID
                Console.WriteLine("Update LOB for specific Id(" + zz+ ") to ?");
                string yy = Console.ReadLine().ToString();
                specNeed.Need_LOB = yy;
                session.Update(specNeed);

                // Return specific record
                Console.WriteLine("Delete Specific Record by Id?");
                int xx = int.Parse(Console.ReadLine());
                var delNeed = session.Get<NeedRequirement>(System.Convert.ToInt64(xx));
                session.Delete(delNeed);
                Console.WriteLine("Deleted Record" + xx + " by Id?");

                //Add a new record
                Console.WriteLine("Adding a new record");
                var newLOB = new NeedRequirement
                {
                    Need_Date = "2018/03/08",
                    Need_LOB = "CBH",
                    ts_0700 = 21.3,
                    ts_0730 = 14.73
                };
                session.Save(newLOB);*/
                transaction.Commit();

                IList<NeedRequirement> needfull = session.Query<NeedRequirement>().ToList(); //  Select Query
                Console.WriteLine("Return updated list");
                foreach (var need in needfull)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", need.Id, need.Need_Date, need.Need_LOB, need.ts_0700, need.ts_0730);
                }

                Console.ReadLine();

            }


        }

    }
}
