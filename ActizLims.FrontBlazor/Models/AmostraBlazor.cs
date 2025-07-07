namespace ActitzLims.Blazor.Models
{
    public enum StatusAmostra
    {
        Pendente,
        EmAnalise,
        Finalizada
    }
    public class AmostraBlazor
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataRecebimento { get; set; }
        public StatusAmostra Status { get; set; }
        public int UserId { get; set; }
    }
}
