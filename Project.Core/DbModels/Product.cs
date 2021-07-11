using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.Core.DbModels
{
    public class Product : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductTypeId")]
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        [ForeignKey("ProductBrandId")]
        public int ProductBrandId { get; set; }
    }
}
