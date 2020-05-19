using System;
namespace Laboratorio6
{ 
    [Serializable]
    public class Division
    {
        public string nombre;
        public Persona encargado;

        public Division()
        {
        }

        public virtual void Info()
        {
            Console.WriteLine("\nDIVISION: " + nombre);
            Console.WriteLine("ENCARGADO: ");
            encargado.Info();
        }
    }
}
