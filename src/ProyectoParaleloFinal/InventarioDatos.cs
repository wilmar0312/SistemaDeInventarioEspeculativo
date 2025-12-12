using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalModular
{
    public class InventarioDatos
    {
        public static List<Producto> Generar(int cantidad)
        {
            string[] categorias = { "Alimentos", "Limpieza", "Hogar", "Electrónica" };
            Producto[] tempArray = new Producto[cantidad];

            // Generacion paralela para velocidad
            Parallel.For(0, cantidad, i =>
            {
                int seed = i + DateTime.Now.Millisecond;
                var rnd = new Random(seed);

                tempArray[i] = new Producto
                {
                    Id = i,
                    Categoria = categorias[rnd.Next(categorias.Length)],
                    StockActual = rnd.Next(100),
                    VentasUltimosDias = new double[] { 10, 12, 15, 9, 11 }
                };
            });

            return tempArray.ToList();
        }
    }
}
