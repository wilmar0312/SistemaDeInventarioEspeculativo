using ProyectoFinalModular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParaleloFinal.Core
{
    public class MotorEspeculativo
    {
        //###############################################
        // 1. Constantes de prediccion y simulacion
        //###############################################

        //--- Escenario Especulativo factores base para subida y bajada ---
        private const double FACTOR_ESCENARIO_SUBIDA = 1.5;
        private const double FACTOR_ESCENARIO_BAJADA = 0.5;

        //--- Probabilidad de sesgo fuerte ---
        private const double FACTOR_SESGO_FUERTE = 0.70;

        // --- Factores para la simulacion de la demanda real por categoria ---


        //--- Alimentos: Tiende a subir un 70% ---
        private const double FACTOR_ALIMENTO_SUBIDA = 1.8;
        private const double FACTOR_ALIMENTO_BAJADA = 0.9;

        // --- Electronica: Tiende a bajar un 70% ---
        private const double FACTOR_ELECTRONICA_BAJADA = 0.3;
        private const double FACTOR_ELECTRONICA_SUBIDA = 1.9;

        // Limpieza: Volátil (50/50)
        private const double PROB_VOLATIL = 0.5;
        private const double FACTOR_LIMPIEZA_ALTA = 1.6;
        private const double FACTOR_LIMPIEZA_BAJA = 0.4;

        // Hogar (Default): Estable (Rango de 0.9 a 1.1)
        private const double FACTOR_HOGAR_BASE = 0.9;
        private const double FACTOR_HOGAR_VARIACION = 0.2;

        public static ResultadoPrediccion procesar(Producto p)
        {
            // Calcula el promedio de ventas recientes como base de las predicciones
            double promedio = p.VentasUltimosDias.Average();

            // 1. Escenario especulativo las 3 predicciones a validadr
            double pSubida = promedio * FACTOR_ESCENARIO_SUBIDA;
            double pBajada = promedio * FACTOR_ESCENARIO_BAJADA;
            double pEstable = promedio;


            // Determinar el escenario con el menor error
            string ganador = "Estable";


            return new ResultadoPrediccion
            {
                ProductoId = p.Id,
                Categoria = p.Categoria,
                EscenarioGanador = ganador
            };
        }
    }
}
