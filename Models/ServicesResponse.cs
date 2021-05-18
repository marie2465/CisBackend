namespace Cis_part2.Models
{
    public class ServicesResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}