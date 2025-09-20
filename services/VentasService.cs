
public class ventasService
{
    private List<Venta> ventas = new List<Venta>();

    // Guardar ventas recibidas por el usuario: 
    public void Guardar(Venta venta)
    {
        // intentar guardar el objeto de ventas recibido
        try
        {
            // guardar ventas
            ventas.Add(venta);
        }
        catch (Exception ex)
        {
            // Error al guardar una venta: 
            Console.WriteLine($"Error al guardar la venta: {ex.Message}");

        }
    }

    public void Mostrar()
    {
        if (ventas.Count > 0)
        {
            int i = 0;
            foreach (Venta venta in ventas)
            {
                Console.WriteLine($"{i + 1}: [{venta}]");
                i++;
            }
        }
        else
        {
            Console.WriteLine("La lista esta vacia porfavor llenar la lista");
        }


    }

    // Desarrollar funcion para calcular el valor total de una venta específica.
    public void calcularTotal(int index)
    {
        var venta = ventas.ElementAtOrDefault(index - 1); // Obtener venta en la posición index, o null si no existe

        if (venta != null)
        {
            var total = venta.ValorProducto * venta.CantidadProducto;
            Console.WriteLine($"El total de la venta {index} es: {total}");
        }
        else
        {
            Console.WriteLine($"No existe una venta en la posición {index}");
        }
    }

    //Desarrollar funcion para calcular el promedio de ventas diarias

    public void CalcularPromedioVentas(DateTime fechaRecibida)
    {
        // Filtra las ventas de la fecha recibida
        var ventasPorDia = ventas
            .Where(v => v.FechaVenta.Date == fechaRecibida.Date) // usar .Date por si vienen horas
            .ToList();

        if (ventasPorDia.Count == 0)
        {
            Console.WriteLine("No hay ventas en esa fecha.");
            return;
        }

        // Suma total (CantidadProducto * ValorProducto)
        var totalVentasDia = ventasPorDia.Sum(v => v.CantidadProducto * v.ValorProducto);

        // Promedio de ventas en ese día
        var promedioVentas = totalVentasDia / ventasPorDia.Count;

        foreach (var venta in ventasPorDia)
        {
            Console.WriteLine($"Producto: {venta.ValorProducto}");
        }

        Console.WriteLine($"Total vendido: {totalVentasDia}");
        Console.WriteLine($"Promedio ventas: {promedioVentas}");
    }

    //Mostrar el empleado del Mes (empleado que tenga las mejores ventas)
    public void VendedorQueMasSeRepite()
    {
        var vendedorMasFrecuente = ventas
            .GroupBy(v => v.Vendedor)                // agrupa por vendedor
            .OrderByDescending(g => g.Count())       // ordena por cantidad descendente
            .FirstOrDefault();                       // toma el primero (el más repetido)

        if (vendedorMasFrecuente != null)
        {
            Console.WriteLine($"El vendedor que más se repite es: {vendedorMasFrecuente.Key} con {vendedorMasFrecuente.Count()} ventas.");
        }
        else
        {
            Console.WriteLine("No hay ventas registradas.");
        }
    }

    public void compradorConMasCompras()
    {
        var compradorMasFrecuentes = ventas.GroupBy(v => v.Comprador).OrderByDescending(g => g.Count()).FirstOrDefault();
        if (compradorMasFrecuentes != null)
        {
            Console.WriteLine($"El comprador con mas compras es:{compradorMasFrecuentes.Key} con {compradorMasFrecuentes.Count()} compras");
        }
        else
        {
            Console.WriteLine("No hay ventas registradas.");
        }
    }

    // Filtrar una lista de ventas para obtener todas las ventas realizadas después de una fecha específica.
   
}