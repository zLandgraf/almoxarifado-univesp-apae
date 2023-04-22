using System.ComponentModel.DataAnnotations;

namespace univesp.almox.apae.Models.Entrada
{
    public class NovaEntradaViewModel
    {
        [Required(ErrorMessage = "Escolha uma data.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informe o documento do fornecedor.")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O documento deve conter de 3 a 200 caracteres")]
        public string DocumentoFornecedor { get; set; }

        [Required(ErrorMessage = "Informe o fornecedor.")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O fornecedor deve conter de 3 a 200 caracteres")]
        public string Fornecedor { get; set; }
        
        [Required(ErrorMessage = "Adicione ao menos um item.")]
        public List<ItemEntradaViewModel> ItensEntradaModel { get; set; }
    }

    public class ItemEntradaViewModel
    {
        [Required(ErrorMessage = "Informe a descrição do material.")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O material deve conter de 3 a 200 caracteres")]
        public string Material { get; set; }
        
        [Required(ErrorMessage = "Informe a medida.")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "A medida deve conter de 3 a 200 caracteres")]
        public string Medida { get; set; }

        [Required(ErrorMessage = "Informe a quantidade.")]
        [Range(minimum: 0.001, maximum: double.MaxValue)]
        public decimal Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o valor.")]
        [Range(minimum: 0.001, maximum: double.MaxValue)]
        public decimal Valor { get; set; }
    }

    public class NovoItemEntradaViewModel
    {
        public int Index { get; set; }
        public NovaEntradaViewModel Model { get; set; }
        public List<ItemEntradaViewModel> ItensEntradaModel { get; set; }
    }
}
