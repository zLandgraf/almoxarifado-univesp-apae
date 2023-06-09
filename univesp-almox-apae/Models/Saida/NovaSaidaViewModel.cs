﻿using System.ComponentModel.DataAnnotations;

namespace univesp.almox.apae.Models.Saida
{
    public class NovaSaidaViewModel
    {
        [Required]
        public int EstoqueId { get; set; }

        [Required(ErrorMessage = "Escolha uma data.")]
        public DateTime Data { get; set; }
        
        [Required(ErrorMessage = "Informe o requisitante.")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O documento deve conter de 3 a 200 caracteres")]
        public string Requisitante { get; set; }

        [Required(ErrorMessage = "Adicione ao menos um item.")]
        public ItemSaidaViewModel ItemSaidaViewModel { get; set; }
    }

    public class ItemSaidaViewModel
    {
        [Required(ErrorMessage = "Informe a medida.")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Informe a medida.")]
        public int MedidaId { get; set; }

        [Required(ErrorMessage = "Informe o valor.")]
        [Range(minimum: 0.001, maximum: double.MaxValue)]
        public decimal Quantidade { get; set; }
        public string Material { get; set; }
        public string Medida { get; set; }
    }
}
