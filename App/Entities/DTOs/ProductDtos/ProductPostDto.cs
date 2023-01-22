﻿using Zay.Entities.Concrets;

namespace Zay.Entities.DTOs.ProductDtos
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<int> SpesificationIds { get; set; }
        public List<int> SizeIds { get; set; }
        public List<int> ColorIds { get; set; }
        public List<int> DiscountIds { get; set; }
        public ProductPostDto()
        {
            SpesificationIds = new();
            Images = new();
            SizeIds= new();
            ColorIds= new();
            DiscountIds= new();
        }
    }
}
