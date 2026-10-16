using System;

namespace MinecraftPoo
{
    // Clase abstracta para crear herramientas especificas.
    abstract class Herramienta
    {
        // Las clases hijas pueden acceder al material.
        protected string material;

        // La durabilidad solo se modifica desde esta clase
        // o mediante la propiedad.
        private int durabilidad;

        public int Durabilidad
        {
            get { return durabilidad; }

            set
            {
                if (value >= 0)
                {
                    durabilidad = value;
                }
            }
        }

        // Constructor parametrizado.
        public Herramienta(string material, int durabilidad)
        {
            this.material = material;
            this.Durabilidad = durabilidad;
        }

        // Cada herramienta define como pica un bloque.
        public abstract void PicarBloque(Bloque b);
    }
}