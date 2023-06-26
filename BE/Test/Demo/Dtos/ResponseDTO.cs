namespace Demo.Dtos
{
    public class ResponseDTO
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool IsFailed { get; set; }
    }
}
