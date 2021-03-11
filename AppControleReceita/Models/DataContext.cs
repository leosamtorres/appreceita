using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleReceita.Models
{

    
   public  class DataContext : DbContext
    {
        public DataContext()
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 360;
        }
        
        
        public virtual DbSet<fin_categoria> Dbfin_categoria { get; set; }
        public virtual DbSet<fin_credito_debito> Dbfin_credito_debito { get; set; }

    }
}
