using E_CommerceProduct.Domain.Enums;

namespace E_CommerceProduct.Application.ProductCategories.Request
{
    public class UpdateProductCategoryRequest
    {
        public CategoryName NewCategory { get; set; }
    }
}
