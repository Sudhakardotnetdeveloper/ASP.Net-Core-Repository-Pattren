using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
    }
}
