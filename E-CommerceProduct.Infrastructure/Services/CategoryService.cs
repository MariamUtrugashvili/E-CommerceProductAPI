using E_CommerceProduct.Application.Categories.Request;
using E_CommerceProduct.Application.Categories.Response;
using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Exceptions;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using Mapster;

namespace E_CommerceProduct.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {

            var result = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken) ?? throw new ItemNotFoundException("Not Found");
            return result.Adapt<IEnumerable<CategoryResponseModel>>();
        }

        public async Task<CategoryResponseModel> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CategoryRepository.GetAsync(cancellationToken, id);
            return result.Adapt<CategoryResponseModel>();

        }

        public async Task CreateCategoryAsync(CategoryRequestModel category, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CategoryRepository.AnyAsync(x => x.Name == category.Name, cancellationToken))
                throw new AlreadyExistsException("Category with this Name already exist");

            var result = category.Adapt<Category>();
            result.Id = Guid.NewGuid();

            await _unitOfWork.CategoryRepository.AddAsync(result, cancellationToken);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCategoryAsync(CategoryRequestModel category, Guid id, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.CategoryRepository.AnyAsync(x => x.Id == id, cancellationToken))
                throw new ItemNotFoundException("Category with this Id wasn't found");

            var entity = category.Adapt<Category>();
            entity.Id = id;
            entity.Name = category.Name;

            _unitOfWork.CategoryRepository.Update(entity, cancellationToken);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(cancellationToken, id) 
                ?? throw new ItemNotFoundException("Category with this Id wasn't found");

            _unitOfWork.CategoryRepository.Delete(category, cancellationToken);
            await _unitOfWork.SaveAsync();
        }
    }
}
