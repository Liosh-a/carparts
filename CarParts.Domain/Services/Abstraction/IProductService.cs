using CarParts.Dto.DtoResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Abstraction
{
    public interface IProductService
    {
        Task<ResultDto> GetCategory();

    }
}
