using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalModular
{
    public class AnalistaReportes
    {
        public static void MostrarInformeEjecutivo(ResultadoPrediccion[] resultados)
        {
            Console.WriteLine("\n=== REPORTE EJECUTIVO POR CATEGORÍA ===");

            var reporte = resultados
                .GroupBy(x => x.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Suben = g.Count(x => x.EscenarioGanador == "Subida"),
                    Bajan = g.Count(x => x.EscenarioGanador == "Bajada"),
                    Estables = g.Count(x => x.EscenarioGanador == "Estable")
                })
                .ToList();

            foreach (var item in reporte)
            {
                string tendencia = "ESTABLE";
                ConsoleColor color = ConsoleColor.White;

                if (item.Suben > item.Estables && item.Suben > item.Bajan)
                {
                    tendencia = "ALTA DEMANDA (REABASTECER)";
                    color = ConsoleColor.Red;
                }
                else if (item.Bajan > item.Estables && item.Bajan > item.Suben)
                {
                    tendencia = "BAJA DEMANDA (OFERTAR)";
                    color = ConsoleColor.Green;
                }

                Console.Write($"[{item.Categoria.PadRight(12)}] -> Tendencia: ");
                Console.ForegroundColor = color;
                Console.WriteLine(tendencia);
                Console.ResetColor();
                Console.WriteLine($"    Detalle: {item.Suben} suben, {item.Bajan} bajan, {item.Estables} estables.");
                Console.WriteLine("- - - - - - - - - - - - - - -");
            }


        }
    }
}