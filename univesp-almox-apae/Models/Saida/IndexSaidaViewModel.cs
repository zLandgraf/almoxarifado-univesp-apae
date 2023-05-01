namespace univesp.almox.apae.Models.Saida
{
    public class IndexSaidaViewModel
    {
        public string? Query { get; set; }
        public List<SaidaViewModel> Saidas { get; set; }
    }

    public class SaidaViewModel
    {
        public string Data { get; set; }
        public string Requisitante { get; set; }
        public string Material { get; set; }
        public decimal Quantidade { get; set; }
    }
}
