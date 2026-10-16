using System;
using System.Collections.Generic;
using System.Threading;

namespace MinecraftPoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Creamos una colección polimórfica de herramientas (Herramienta[])
            // Cumple con el requisito de colección de objetos en Main() iterada con bucles.
            Herramienta[] herramientas = new Herramienta[]
            {
                new PicoHierro(5),       // Durabilidad inicial: 5
                new PicoDiamante(10)     // Durabilidad inicial: 10
            };

            // 2. Creamos una lista de bloques disponibles para picar
            List<Bloque> bloques = new List<Bloque>()
            {
                new Bloque("Piedra", 3),
                new Bloque("Diamante", 5),
                new Bloque("Obsidiana", 8)
            };

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SIMULADOR MINECRAFT (TEMA 6) ===");
                Console.WriteLine("1. Usar una herramienta");
                Console.WriteLine("2. Ver estado de los bloques");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("--- Elige una Herramienta ---");
                        Console.WriteLine($"0. Pico de Hierro (Durabilidad: {herramientas[0].Durabilidad})");
                        Console.WriteLine($"1. Pico de Diamante (Durabilidad: {herramientas[1].Durabilidad})");
                        Console.Write("Ingrese el número de la herramienta: ");

                        if (int.TryParse(Console.ReadLine(), out int indexHerramienta) && (indexHerramienta == 0 || indexHerramienta == 1))
                        {
                            Herramienta herramientaSeleccionada = herramientas[indexHerramienta];

                            Console.WriteLine("--- Elige un Bloque ---");
                            for (int i = 0; i < bloques.Count; i++)
                            {
                                string estadoRoto = bloques[i].EstaRoto ? " (Roto)" : "";
                                Console.WriteLine($"{i}. Bloque de {bloques[i].Tipo} (Dureza: {bloques[i].Dureza}){estadoRoto}");
                            }
                            Console.Write("Ingrese el número del bloque: ");

                            if (int.TryParse(Console.ReadLine(), out int indexBloque) && indexBloque >= 0 && indexBloque < bloques.Count)
                            {
                                Bloque bloqueSeleccionado = bloques[indexBloque];

                                Console.WriteLine("\n----------------------------------------");
                                // Aquí se ejecuta el polimorfismo llamando al método respectivo
                                herramientaSeleccionada.PicarBloque(bloqueSeleccionado);
                                Console.WriteLine("----------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Bloque inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Herramienta inválida.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n--- Estado Actual de los Bloques ---");
                        foreach (var b in bloques)
                        {
                            string estado = b.EstaRoto ? "Roto" : "Intacto";
                            Console.WriteLine($"- {b.Tipo}: Dureza {b.Dureza} [{estado}]");
                        }
                        break;

                    case "3":
                        salir = true;
                        Console.WriteLine("¡Gracias por jugar!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}