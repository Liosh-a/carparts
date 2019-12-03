namespace CarParts.Dto.DtoResult
{
    public class SingleResultDto<T> : ResultDto
    {
        public T Data { get; set; }
    }
}