using System;

namespace MinecraftPoo
{
    internal class Bloque
    {
        private string tipo;
        private int dureza;

        public string Tipo
        {
            get { return tipo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tipo = value;
                }
            }
        }

        public int Dureza
        {
            get { return dureza; }
            set
            {
                if (value >= 0)
                {
                    dureza = value;
                }
            }
        }

        // El bloque está roto automáticamente cuando su dureza llega a 0.
        public bool EstaRoto
        {
            get { return dureza <= 0; }
        }

        public Bloque(string tipo, int dureza)
        {
            this.Tipo = tipo;
            this.Dureza = dureza;
        }

        // Método para reducir la dureza del bloque al ser golpeado
        public void Romper(int cantidad)
        {
            if (EstaRoto)
            {
                Console.WriteLine($"El bloque de {Tipo} ya está roto.");
                return;
            }

            Dureza -= cantidad;
            if (Dureza < 0)
            {
                Dureza = 0;
            }

            Console.WriteLine($"Golpe al bloque de {Tipo}. Dureza restante: {Dureza}");

            if (EstaRoto)
            {
                Console.WriteLine($"¡El bloque de {Tipo} se ha roto por completo!");
            }
        }

        internal void Romper()
        {
            // Default single hit when no amount is provided from the caller.
            // Use the existing overload that handles validation and messages.
            Romper(1);
        }
    }
}