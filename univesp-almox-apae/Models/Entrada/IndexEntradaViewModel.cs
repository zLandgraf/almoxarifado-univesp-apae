namespace univesp.almox.apae.Models.Entrada
{
    public class IndexEntradaViewModel
    {
        public string? Query { get; set; }
        public List<EntradaViewModel> Entradas { get; set; }
    }

    public class EntradaViewModel
    {
        public string Data { get; set; }
        public string Fornecedor { get; set; }
        public string Material { get; set; }
        public decimal Quantidade { get; set; }
    }
}
