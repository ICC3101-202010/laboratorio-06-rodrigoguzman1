using System;
namespace Laboratorio6
{
    [Serializable]
    public class Departamento : Division
    {
        public Departamento(string nombre, Persona encargado)
        {
            this.nombre = nombre;
            this.encargado = encargado;
        }
    }
}
