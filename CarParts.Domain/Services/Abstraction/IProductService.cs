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
        Task<List<FNameViewModel>> GetListFilter (int categoryId);

        Task<SingleResultDto<ProductDto>> GetProductById(string productUnickName);

        Task<CollectionResultDto<ProductDto>> GetProductbyCategoryandFilters(int categoryId, FilterOnUse filterOnUse, int pageIndex);

        Task<CollectionResultDto<ProductDto>> GetProductbyCarIdCategoryandFilteres(int categoryId, int carId, FilterOnUse filterOnUse, int pageIndex);

        Task<CollectionResultDto<ProductDto>> GetProductbyCatId(int categoryId, int paginationinfo);
    }
}
