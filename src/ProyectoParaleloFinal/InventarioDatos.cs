using System;
using System.Collections.Generic;

namespace ProyectoFinalModular
{
    public class InventarioDatos
    {
        public static List<Producto> Generar(int cantidad)
        {
            List<Producto> productos = new List<Producto>();

            for (int i = 0; i < cantidad; i++)
            {
                productos.Add(new Producto
                {
                    Id = i,
                    Categoria = "",
                    StockActual = 0,
                    VentasUltimosDias = Array.Empty<double>()
                });
            }

            return productos;
        }
    }
}
