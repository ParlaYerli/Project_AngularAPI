using Project.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Specification
{
    public class ProductsWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams)
                                                            :base(x=>
                                                            (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
                                                            &&
                                                            (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                                                            &&
                                                            (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex-1),productSpecParams.PageSize);
            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }
        public ProductsWithProductTypeAndBrandsSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
