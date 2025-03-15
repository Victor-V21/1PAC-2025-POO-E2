namespace E1U2POO.API.Dtos
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public bool Status {  get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
