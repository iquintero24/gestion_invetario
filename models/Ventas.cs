
public class Venta
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime FechaVenta { get; set; }
    public int ValorProducto { get; set; }
    public int CantidadProducto { get; set; }
    public string Vendedor { get; set; }
    public string Comprador { get; set; }
    public DateTime TiempoGarantia { get; set; }

    public Venta(DateTime fechaVenta, int valorProducto, int cantidadProducto, string vendedor, string comprador, DateTime tiempoGarantia)
    {
        Id = Guid.NewGuid();
        FechaVenta = fechaVenta;
        ValorProducto = valorProducto;
        CantidadProducto = cantidadProducto;
        Vendedor = vendedor;
        Comprador = comprador;
        TiempoGarantia = tiempoGarantia;

    }

    public Venta()
    {
        Id = Guid.NewGuid();
    }


    public override string ToString()
    {
        return $"Fecha: {FechaVenta}, Valor: {ValorProducto}, Cantidad: {CantidadProducto}, " +
               $"Vendedor: {Vendedor}, Comprador: {Comprador}, Garantía: {TiempoGarantia}";
    }

}