using System.Collections.Generic;

namespace CarParts.Dto.DtoResult
{
    public class ResultDto
    {
        public bool IsSuccessful { get; set; }
        public IDictionary<string,string> collectionResult { get; set; }
    }
}