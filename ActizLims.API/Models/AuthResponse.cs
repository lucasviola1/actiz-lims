namespace ActizLims.API.Models
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}
