using ProyectoFinalModular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalModular
{
    public class MotorEspeculativo
    {
        // 1. Constantes de prediccion y simulacion


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

        public static ResultadoPrediccion Procesar(Producto p)
        {
            // Calcula el promedio de ventas recientes como base de las predicciones
            double promedio = p.VentasUltimosDias.Average();

            // 1. Escenario especulativo las 3 predicciones a validadr
            double pSubida = promedio * FACTOR_ESCENARIO_SUBIDA;
            double pBajada = promedio * FACTOR_ESCENARIO_BAJADA;
            double pEstable = promedio;

            // 2. Simulacion de realidad dados cargados por categoria

            // Genera una 'seed' única basada en GUID y el ID del producto
            // Esto asegura que la simulación sea pseudo-aleatoria e independiente por producto

            int seed = Guid.NewGuid().GetHashCode() + p.Id;
            Random rnd = new Random();
            double azar = rnd.NextDouble();
            double demandaReal;


            switch (p.Categoria)
            {
                case "Alimentos":
                    // Sesgo 70% a la subida
                    demandaReal = (azar < FACTOR_SESGO_FUERTE)
                        ? promedio * FACTOR_ALIMENTO_SUBIDA
                        : promedio * FACTOR_ALIMENTO_BAJADA;
                    break;

                case "Electrónica":
                    // Sesgo 70% a la bajada
                    demandaReal = (azar < FACTOR_SESGO_FUERTE)
                        ? promedio * FACTOR_ELECTRONICA_BAJADA
                        : promedio * FACTOR_ELECTRONICA_SUBIDA;
                    break;

                case "Limpieza":
                    // Volátil 50/50
                    demandaReal = (azar < PROB_VOLATIL)
                        ? promedio * FACTOR_LIMPIEZA_ALTA
                        : promedio * FACTOR_LIMPIEZA_BAJA;
                    break;

                default: // Caso "Hogar" y cualquier otra categoría no definida
                    // Estable: variación entre 0.9 y 1.1
                    demandaReal = promedio * (FACTOR_HOGAR_BASE + (azar * FACTOR_HOGAR_VARIACION));
                    break;
            }

            
            demandaReal = Math.Round(demandaReal, 2);

            // 3. VALIDACIÓN (Comparar escenarios especulativos contra la realidad simulada)

            // Calcular el Error Absoluto (distancia) de cada predicción a la demanda simulada
            double errSub = Math.Abs(pSubida - demandaReal);
            double errBaj = Math.Abs(pBajada - demandaReal);
            double errEst = Math.Abs(pEstable - demandaReal);

            // Determinar el escenario con el menor error
            string ganador = "Estable";

            if (errSub < errEst && errSub < errBaj)
            {
                ganador = "Subida";
            }
            else if (errBaj < errEst && errBaj < errSub)
            {
                ganador = "Bajada";
            }

            // Devolver el resultado usando el modelo de datos no modificable
            return new ResultadoPrediccion
            {
                ProductoId = p.Id,
                Categoria = p.Categoria,
                EscenarioGanador = ganador
            };

            return new ResultadoPrediccion
            {
                ProductoId = p.Id,
                Categoria = p.Categoria,
                EscenarioGanador = ganador
            };
        }
    }
}
