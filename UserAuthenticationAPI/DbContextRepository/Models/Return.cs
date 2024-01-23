namespace UserAuthenticationAPI.DbContextRepository.Models
{
    public class Return<T>
    {
        public Return(T data)
        {
            Success = true;
            Messages = new List<string>();
            Data = data;
        }

        public Return(string errorMessage)
        {
            Success = false;
            Messages = new List<string>();
            Data = default;
            Messages.Add(errorMessage);
        }

        public bool Success { get; }
        public List<string> Messages { get; }
        public T Data { get; }
    }
}
