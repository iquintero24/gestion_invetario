using System.Data;

public class Menu
{

    private ventasService ventasService = new ventasService();

    public void Mostrar()
    {
        bool continuar = true;


        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== Menú de Ventas ===");
            Console.WriteLine("1. Agregar venta");
            Console.WriteLine("2. Listar ventas");
            Console.WriteLine("3. Sacar total de una venta en especifico: ");
            Console.WriteLine("4. Sacar las ventas de un dia en especifico: ");
            Console.WriteLine("5. Vendedor del mes: ");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            Console.WriteLine("");
            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--- Agregar nueva venta ---");

                    Console.Write("Fecha de venta (yyyy-mm-dd): ");
                    DateTime fechaVenta = DateTime.Parse(Console.ReadLine() ?? "");

                    Console.Write("Valor del producto (example: 1000): ");
                    int valorProducto = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Ingrese la cantidad de producto: ");
                    int CantidadProducto = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Ingrese el nombre del vendedor: ");
                    string nombreVendedor = Console.ReadLine() ?? "";

                    Console.Write("Ingrese el nombre del comprador: ");
                    string NombreComprador = Console.ReadLine() ?? "";

                    Console.Write("Fecha de garantia (yyyy-mm-dd): ");
                    DateTime fechaGarantia = DateTime.Parse(Console.ReadLine() ?? "");

                    Venta nuevaVenta = new Venta(fechaVenta, valorProducto, CantidadProducto, nombreVendedor, NombreComprador, fechaGarantia);


                    ventasService.Guardar(nuevaVenta);

                    break;
                case "2":
                    Console.WriteLine("");
                    Console.WriteLine("--- Las ventas registradas son ---");
                    Console.WriteLine("");
                    ventasService.Mostrar();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("--- seleccione la venta que quiere calcular ---");
                    ventasService.Mostrar();
                    Console.Write("Seleccione un indice: ");
                    int index = int.Parse(Console.ReadLine() ?? "0");
                    ventasService.calcularTotal(index);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("--- ingrese la fecha del dia que desea calcular sus ventas ---");
                    Console.Write("(yyyy-mm-dd): ");
                    DateTime fechaComparar = DateTime.Parse(Console.ReadLine() ?? "");
                    ventasService.CalcularPromedioVentas(fechaComparar);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("--- el vendedor del mes es: ---");
                    ventasService.VendedorQueMasSeRepite();
                break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }


        }



    }
}