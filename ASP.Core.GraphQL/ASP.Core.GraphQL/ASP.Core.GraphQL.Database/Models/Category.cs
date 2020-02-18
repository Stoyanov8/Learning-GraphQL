using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Core.GraphQL.Database.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
