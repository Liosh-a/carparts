using System.Collections.Generic;
namespace CarParts.Dto.DtoResult
{
    public class CollectionResultDto<T> : ResultDto
    {
        public ICollection<T> Data { get; set; }
        public int Count { get; set; }
    }
}