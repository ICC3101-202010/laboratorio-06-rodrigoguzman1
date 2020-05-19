using System;
using System.Collections.Generic;

namespace Laboratorio6
{
    [Serializable]
    public class Empresa
    {
        public string nombre;
        public string rut;
        public List<Division> divisiones = new List<Division>();
    

        public Empresa(string nombre, string rut)
        {
            this.nombre = nombre;
            this.rut = rut;
        }
    }
}
