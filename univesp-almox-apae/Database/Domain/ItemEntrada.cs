namespace univesp.almox.apae.Database.Domain
{
    public class ItemEntrada
    {
        public int Id { get; set; }
        public int EntradaId { get; set; }
        public Entrada Entrada { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int MedidaId { get; set; }
        public Medida Medida { get; set; }
        public decimal Quantidade { get; set; }
    }
}
