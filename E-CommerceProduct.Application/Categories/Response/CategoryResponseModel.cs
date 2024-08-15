using E_CommerceProduct.Domain.Enums;

namespace E_CommerceProduct.Application.Categories.Response
{
    public class CategoryResponseModel
    {
        public Guid Id { get; set; }
        public CategoryName Name { get; set; }
    }
}
