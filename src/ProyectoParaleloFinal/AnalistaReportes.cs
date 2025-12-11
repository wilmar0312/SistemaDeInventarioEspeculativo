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

           
        }
    }
}