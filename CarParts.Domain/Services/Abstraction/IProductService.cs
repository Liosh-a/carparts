using CarParts.DataAccess;
using CarParts.DataAccess.Entities;
using CarParts.Dto;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Abstraction
{
    public interface IProductService
    {
        List<FNameViewModel> GetListFilter (int categoryId);

        Task<SingleResultDto<Product>> GetProductById(string productUnickName);

        Task<CollectionResultDto<Product>> GetProductbyCategoryandFilters(int categoryId, FilterOnUse filterOnUse, int page);

        Task<CollectionResultDto<Product>> GetProductbyCarIdCategoryandFilteres(int carId, FilterOnUse filterOnUse, int page);
    }
}
