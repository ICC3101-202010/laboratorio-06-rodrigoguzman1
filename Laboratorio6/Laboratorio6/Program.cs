using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Laboratorio6
{
    class MainClass
    {
        //COMO NO SE ESPICIFICA EN EL ENUNCIADO LAS PERSONAS YA ESTAN CREADAS Y SE ASIGNAN ALEATORIAMENTE A CADA CARGO AL CREAR LA EMPRESA. CADA VEZ QUE SE CREE LA EMPRESA LAS PERSONAS SE ASIGNARÁN A UN CARGO DIFERENTE A LA VEZ ANTERIOR

        public static void Main(string[] args)
        {
            Empresa empresa;
           
            Console.WriteLine("¿Desea utilizar un archivo para cargar la información de la empresa?\n1. SI\n2. NO");
            int eleccion = Convert.ToInt32(Console.ReadLine());

            switch (eleccion)
            {
                case 1:
                    try
                    {
                        empresa = CargarEmpresa();
                        Console.WriteLine("Nombre empresa: " + empresa.nombre);
                        Console.WriteLine("Rut empresa: "+ empresa.rut);

                        foreach(Division division in empresa.divisiones)
                        {
                            division.Info();
                        }
                        Console.WriteLine("Presione cualquier tecla para terminar");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No existe archivo");
                        Thread.Sleep(1500); Console.Clear();
                        GuardarEmpresa();
                    }
                    break;
                case 2:
                    GuardarEmpresa();
                    break;
                default:
                    break;
            }
        }

        static Empresa CargarEmpresa()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Empresa empresa = (Empresa)formatter.Deserialize(stream);
            stream.Close();
            return empresa;
        }

        static void GuardarEmpresa()
        {
            Console.WriteLine("Nombre de la empresa: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Rut de la empresa: ");
            string rut = Console.ReadLine();
            Empresa empresa = new Empresa(nombre, rut);
            List<List<string>> personasAsignar = new List<List<string>>();
            personasAsignar.Add(new List<string>(new string[] { "Rodrigo", "Guzman", "20.164.752-5" }));
            personasAsignar.Add(new List<string>(new string[] { "Pedro", "Perez", "13.421.376-3" }));
            personasAsignar.Add(new List<string>(new string[] { "Javier", "Gonzales", "9.462.204-5" }));
            personasAsignar.Add(new List<string>(new string[] { "Sofia", "Soto", "18.638.097-k" }));
            personasAsignar.Add(new List<string>(new string[] { "Javiera", "Opazo", "19.954.285-k" }));
            personasAsignar.Add(new List<string>(new string[] { "Felipe", "Alcalde", "21.488.213-8" }));
            personasAsignar.Add(new List<string>(new string[] { "Maximiliano", "Gross", "17.841.552-4" }));
            personasAsignar.Add(new List<string>(new string[] { "Nicolas", "Vial", "11.245.899-3" }));

            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int numero = rnd.Next(0, personasAsignar.Count);
                if (i == 0) { Departamento departamento = new Departamento("Departamento 1", new Persona(personasAsignar[numero][0], personasAsignar[numero][1], personasAsignar[numero][2], "Jefe de Departamento")); empresa.divisiones.Add(departamento); personasAsignar.RemoveAt(numero); }
                if (i == 1) { Seccion seccion = new Seccion("Seccion 1", new Persona(personasAsignar[numero][0], personasAsignar[numero][1], personasAsignar[numero][2], "Jefe de Seccion")); empresa.divisiones.Add(seccion); personasAsignar.RemoveAt(numero); }
                if (i == 2 || i == 3)
                {
                    Bloque bloque = new Bloque("Bloque " + (i-1), new Persona(personasAsignar[numero][0], personasAsignar[numero][1], personasAsignar[numero][2], "Jefe de Bloque")); personasAsignar.RemoveAt(numero);
                    numero = rnd.Next(0, personasAsignar.Count); bloque.personal.Add(new Persona(personasAsignar[numero][0], personasAsignar[numero][1], personasAsignar[numero][2], "Personal")); personasAsignar.RemoveAt(numero);
                    numero = rnd.Next(0, personasAsignar.Count); bloque.personal.Add(new Persona(personasAsignar[numero][0], personasAsignar[numero][1], personasAsignar[numero][2], "Personal")); personasAsignar.RemoveAt(numero);
                    empresa.divisiones.Add(bloque);
                }
                
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresa);
            stream.Close();
        }
    }
}
