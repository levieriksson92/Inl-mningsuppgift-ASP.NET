﻿using System.ComponentModel.DataAnnotations;

namespace ASP_API.Models.Entity
{
    public class CategoryEntity
    {

        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();


    }
}
