using System;
using System.Collections.Generic;

namespace Laboratorio6
{
    [Serializable]
    public class Bloque : Division
    {
        public List<Persona> personal = new List<Persona>();

        public Bloque(string nombre, Persona encargado)
        {
            this.nombre = nombre;
            this.encargado = encargado;
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine("\nPERSONAL: ");
            foreach (Persona persona in personal) { persona.Info(); }
        }

    }
}
