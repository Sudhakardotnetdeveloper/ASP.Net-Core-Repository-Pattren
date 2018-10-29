using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain
{
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
