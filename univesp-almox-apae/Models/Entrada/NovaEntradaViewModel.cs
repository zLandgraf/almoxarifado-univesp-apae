using univesp.almox.apae.Database.Domain;

namespace univesp.almox.apae.Models.Entrada
{
    public class NovaEntradaViewModel
    {
        public DateTime Data { get; set; }
        public string DocumentoFornecedor { get; set; }
        public string Fornecedor { get; set; }
        public List<ItemEntradaViewModel> ItensEntradaModel { get; set; }

        public NovaEntradaViewModel()
        {
            ItensEntradaModel = new List<ItemEntradaViewModel>();
        }
    }

    public class ItemEntradaViewModel
    {
        public string Material { get; set; }
        public string Medida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
    }

    public class NovoItemEntradaViewModel
    {
        public int Index { get; set; }
        public List<ItemEntradaViewModel> ItensEntradaModel { get; set; }
    }
}
