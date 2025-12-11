namespace ProyectoFinalModular
{
    public class Producto
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public double StockActual { get; set; }
        public double[] VentasUltimosDias { get; set; }
    }

    public class ResultadoPrediccion
    {
        public int ProductoId { get; set; }
        public string Categoria { get; set; }
        public string EscenarioGanador { get; set; }
    }
}