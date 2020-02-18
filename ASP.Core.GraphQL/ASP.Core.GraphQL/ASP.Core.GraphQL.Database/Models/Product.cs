using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Core.GraphQL.Database.Models
{
    public class Product
    {
        public int Id { get; set; }

        public bool Available { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
