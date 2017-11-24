using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using StudyEfCore.Utilities;

namespace StudyEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var index = 0;

            retry:
            index++;
            Console.WriteLine($"Run: {index}. Enter to go");
            Console.ReadLine();

            try
            {
                using (var efContext = new EfCoreContext())
                {
                    var searchWord = "Product";
                    //var t =  efContext.FullTextSearch().ToList();
                    var list = efContext.Product.Where(p => SqlFunctions.Contains(p.Title, searchWord) == true).ToList();

                    //var list2 = efContext.Product
                    //    .Join(efContext.FullTextSearch(), p => p.Id, c => c.Id, (p, c) => p)
                    //    //.Where(p => p.Summary.Contains(searchWord) && p.Title.FullTextSearch(searchWord))
                    //    .ToList();

                    // Console.WriteLine(list2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Enter");
            Console.ReadLine();

            goto retry;
        }
    }

}
