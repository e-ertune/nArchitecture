using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicated(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(x => x.Name.Equals(name));
            if (result.Items.Any())
            {
                throw new BusinessException("Brand name already exists.");
            }
        }

        public void BrandShouldExistWhenRequested(Brand? brand)
        {
            if (brand == null)
            {
                throw new BusinessException("Requested Brand does not exist.");
            }
        }
    }
}
