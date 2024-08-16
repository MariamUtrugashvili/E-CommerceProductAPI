using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Exceptions;
using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.ProductCategories.Response;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;

namespace E_CommerceProduct.Infrastructure.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProductCategoriesResponseModel>> GetProductCategoriesAsync(Guid productId, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductCategoryRepository.GetProductCategoriesAsync(productId, cancellationToken);
            return result;
        }


        public async Task UpdateProductCategoryAsync(UpdateProductCategoryRequest request, Guid id, CancellationToken cancellationToken)
        {
            var productCategory = await _unitOfWork.ProductCategoryRepository.GetAsync(cancellationToken, id);

            if (productCategory == null)
            {
                throw new ItemNotFoundException("ProductCategory not found");
            }

            var existingCategories = await GetProductCategoryNamesByProductIdAsync(productCategory.ProductId, cancellationToken);

            if (existingCategories.Contains(request.NewCategory.ToString()))
            {
                throw new AlreadyExistsException("This category already exists for the product");
            }

            var category = await GetCategoryByNameAsync(request.NewCategory, cancellationToken);
            if (category == null)
            {
                throw new ItemNotFoundException("Category not found");
            }

            productCategory.CategoryId = category.Id;

            _unitOfWork.ProductCategoryRepository.Update(productCategory, cancellationToken);
            await _unitOfWork.SaveAsync();
        }

        private async Task<List<string>> GetProductCategoryNamesByProductIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            var productCategories = await _unitOfWork.ProductCategoryRepository.GetProductCategoriesAsync(productId, cancellationToken);
            return productCategories.SelectMany(pc => pc.CategoryNames).ToList();
        }

        private async Task<Category> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken)
        {
            var allCategories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);

            return allCategories.FirstOrDefault(c => c.Name == categoryName);
        }

        public async Task DeleteProductCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            var productCategory = await _unitOfWork.ProductCategoryRepository.GetAsync(cancellationToken, id);
            if (productCategory == null) throw new ItemNotFoundException("Product not found");

            _unitOfWork.ProductCategoryRepository.Delete(productCategory, cancellationToken);
            await _unitOfWork.SaveAsync();
        }


    }
}
