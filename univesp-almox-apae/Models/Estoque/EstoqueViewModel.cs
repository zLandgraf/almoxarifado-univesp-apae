﻿namespace univesp.almox.apae.Models.Estoque
{
    public class EstoqueViewModel
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Material { get; set; }
        public string Medida { get; set; }
        public decimal Quantidade { get; set; }
    }
}
