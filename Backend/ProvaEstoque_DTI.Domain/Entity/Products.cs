using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEstoque_DTI.Domain.Entity
{
    public class Product: EntityBase
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }
    }
}
