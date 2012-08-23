using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

namespace PhotoADay.Data
{
    public class PhotoContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
    }
}
