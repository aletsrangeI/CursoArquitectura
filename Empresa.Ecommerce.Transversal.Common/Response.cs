namespace Empresa.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }
}
