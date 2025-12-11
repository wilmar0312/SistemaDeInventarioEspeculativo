using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProyectoFinalModular
{
    class Program
    {
        const int CANTIDAD_PRODUCTOS = 2000000;

        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== SISTEMA INTEGRADO DE PREDICCIÓN PARALELA ===");
            Console.ResetColor();

            // 1. GENERACION
            Console.WriteLine($"Generando {CANTIDAD_PRODUCTOS:N0} registros...");
            var inventario = await Task.Run(() => InventarioDatos.Generar(CANTIDAD_PRODUCTOS));

        }
    }
}