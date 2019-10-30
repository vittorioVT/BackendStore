using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackendStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool IsStore { get; set; }
        public bool IsStock { get; set; }
        public int Count { get; set; }
        public int CountStore { get; set; }
        public int CountStock { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Ordered { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }

        [NotMapped]
        public int Quantity { get; set; }
    }
}