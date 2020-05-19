using System;
namespace Laboratorio6
{
    [Serializable]
    public class Persona
    {
        string nombre;
        string apellido;
        string rut;
        string cargo;

        public Persona(string nombre, string apellido, string rut, string cargo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.rut = rut;
            this.cargo = cargo;
        }

        public void Info()
        {
            Console.WriteLine("\nNombre: "+ this.nombre);
            Console.WriteLine("Apellido: " + this.apellido);
            Console.WriteLine("Rut: " + this.rut);
            Console.WriteLine("Cargo: " + this.cargo);
        }
    }
}
