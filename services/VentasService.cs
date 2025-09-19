
using System.Numerics;

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

    public void calcularPromedioVentas(DateTime fechaRecibida)
    {
        // recibe la fecha en la que se va sacar el promedio
        var resultado = ventas.Where(ventas => ventas.FechaVenta == fechaRecibida).ToList(); 
        var promedio = resultado.Average();
    }

}