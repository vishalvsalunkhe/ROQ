using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Common
{

    /// <summary>
    /// Bounded DBContexts
    /// https://msdn.microsoft.com/en-us/magazine/jj883952.aspx
    /// 
    /// public class ShippingContext:BaseContext<ShippingContext>
    /// 
    /// If you’re doing new development and you want to let Code First create or migrate your database 
    /// based on your classes, you’ll need to create an “uber-model” using a DbContext that includes all 
    /// of the classes and relationships needed to build a complete model that represents the database. 
    /// However, this context must not inherit from BaseContext. When you make changes 
    /// to your class structures, you can run some code that uses the uber-context to perform database 
    /// initialization whether you’re creating or migrating the database.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseContext() : base("ROQConnection")
        {
        }
    }
}
