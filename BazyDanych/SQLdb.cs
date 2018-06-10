using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace BazyDanych
{
    public class SQLdb : System.Data.Entity.DropCreateDatabaseIfModelChanges<BazyDanychContext>
    {
        public void addToDb(BazyDanychContext context)
        {
            context.SaveChanges();
        }
        protected override void Seed(BazyDanychContext context)
        {
            context.SaveChanges();
            base.Seed(context);
        }

    }
}
