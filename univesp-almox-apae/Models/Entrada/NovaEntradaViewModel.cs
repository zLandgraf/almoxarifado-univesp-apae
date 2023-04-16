using univesp.almox.apae.Database.Domain;

namespace univesp.almox.apae.Models.Entrada
{
    public class NovaEntradaViewModel
    {
        public DateTime Data { get; set; }
        public string DocumentoFornecedor { get; set; }
        public string Fornecedor { get; set; }
        public List<ItemEntradaViewModel> ItemEntradaModel { get; set; }

        public NovaEntradaViewModel()
        {
            ItemEntradaModel = new List<ItemEntradaViewModel>();
        }
    }

    public class ItemEntradaViewModel
    {
        public string Material { get; set; }
        public string Medida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
