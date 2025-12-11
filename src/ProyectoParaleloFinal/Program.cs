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


            // 2. SECUENCIAL
            Console.WriteLine("\n-> Ejecutando Análisis SECUENCIAL...");
            ResultadoPrediccion[] resSec = new ResultadoPrediccion[CANTIDAD_PRODUCTOS];
            Stopwatch swSec = Stopwatch.StartNew();

            for (int i = 0; i < inventario.Count; i++)
            {               
                resSec[i] = MotorEspeculativo.Procesar(inventario[i]);
            }
            swSec.Stop();
            Console.WriteLine($"Tiempo: {swSec.ElapsedMilliseconds} ms");

            // 3. PARALELO
            Console.WriteLine("\n-> Ejecutando Análisis PARALELO...");
            ResultadoPrediccion[] resPar = new ResultadoPrediccion[CANTIDAD_PRODUCTOS];
            Stopwatch swPar = Stopwatch.StartNew();

            Parallel.For(0, inventario.Count, i =>
            {
                resPar[i] = MotorEspeculativo.Procesar(inventario[i]);
            });

            swPar.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Tiempo: {swPar.ElapsedMilliseconds} ms");
            Console.ResetColor();

            // 4. REPORTES
            AnalistaReportes.MostrarInformeEjecutivo(resPar);

            // 5. MÉTRICAS FINALES
            double speedup = (double)swSec.ElapsedMilliseconds / swPar.ElapsedMilliseconds;
            double eficiencia = speedup / Environment.ProcessorCount;

            Console.WriteLine("\n=== Metricas de rendimiento ===");
            Console.WriteLine($"Speedup: {speedup:F2}x");
            Console.WriteLine($"Eficiencia: {eficiencia:F2}");

            Console.WriteLine("\nPresione ENTER para finalizar...");
            Console.ReadLine();
        }
    }
}