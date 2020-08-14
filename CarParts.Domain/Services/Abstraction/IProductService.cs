using CarParts.DataAccess.Entities;
using CarParts.Dto.DtoResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Abstraction
{
    public interface IProductService
    {
        ResultDto GetCategory();
        ResultDto GetMark(int year);
        ResultDto GetModel(int mark);


    }
}
