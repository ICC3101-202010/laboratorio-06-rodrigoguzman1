using System;
namespace Laboratorio6
{
    [Serializable]
    public class Seccion : Division
    {
        public Seccion(string nombre, Persona encargado)
        {
            this.nombre = nombre;
            this.encargado = encargado;
        }
    }
}
