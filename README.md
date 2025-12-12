# Sistema de Inventario Especulativo

## Descripción General
Este proyecto es una aplicación de consola desarrollada en C# que simula un entorno de análisis de datos masivos. El sistema procesa un inventario de **2,000,000 de productos**, calculando predicciones de demanda futura (Subida, Bajada o Estable) basándose en tendencias históricas y categorías de producto. Su propósito principal es demostrar la eficiencia de la **Programación Paralela** frente al procesamiento secuencial tradicional.

## Objetivos
* **Comparar Rendimiento:** Medir la diferencia de tiempos de ejecución entre un bucle `for` tradicional y un `Parallel.For`.
* **Simulación Realista:** Implementar un "Motor Especulativo" que aplique lógica de negocio compleja y probabilística por categoría (Alimentos, Electrónica, etc.).
* **Optimización de Recursos:** Demostrar cómo el paralelismo de datos aprovecha todos los núcleos del procesador para reducir tiempos de espera (Speedup).

## Funcionalidades Clave
1.  **Generación Masiva de Datos:** Creación en memoria de millones de registros con atributos aleatorios simulados.
2.  **Motor Especulativo:** Algoritmo que calcula tres escenarios futuros posibles por producto y determina el más probable comparándolo contra una demanda simulada.
3.  **Ejecución Dual:** Capacidad de ejecutar el análisis en modo Secuencial y Paralelo en la misma corrida para comparación directa.
4.  **Reporte Ejecutivo:** Generación automática de un informe que agrupa las tendencias detectadas y sugiere acciones (Reabastecer u Ofertar).

## Tecnologías Utilizadas
* **Lenguaje:** C# (NET 8.0)
* **Paralelismo:** Task Parallel Library (TPL) y `System.Threading.Tasks`.
* **IDE:** Visual Studio 2022.
* **Control de Versiones:** Git y GitHub.