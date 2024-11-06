using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_rfc
    {
        public string RFC(E_rfc rfc)
        {
            //Se crea arreglo con las palabras prohibidas
            string[] prohibidas = new string[] {"BUEI", "CACA", "CAGA", "CAKA", "COGE", "COJE",
            "COJO", "FETO", "JOTO", "KACO", "KAGO", "KOJO", "KULO", "MAMO", "MEAS", "MION", "MULA",
            "PEDO", "PUTA", "QULO", "BUEY", "CACO", "CAGO", "CAKO", "COJA", "COJI", "CULO", "GUEY",
            "KACA", "KOGE", "KAKA", "MAME", "MEAR", "MEON", "MOCO", "PEDA", "PENE", "PUTO", "RATA"};
            //Se crea arreglo con las palabras de nombres comunes
            string[] nombres = new string[] { "Maria", "Ma.", "MA", "Jose", "J", "J." };

            char[] vocales = new char[] { 'A', 'E', 'I', 'O', 'U' };
            char[] consonantes = new char[] {'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 
                'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'};

            string apellidoPa = rfc.apellidoPa.ToUpper();
            //Se crea condicion en la que el apellido paterno comience con Ñ y se cambie por X
            if (apellidoPa.StartsWith("Ñ"))
            {
                apellidoPa = apellidoPa.Replace("Ñ", "X");
            }
            //Se crea la condicion que valida si la segunda letra del apellido es consonante, se tome la tercera letra
            if (vocales.Contains(apellidoPa[1]))
            {
                apellidoPa = apellidoPa.Substring(0, 2);
            }
            else
            {
                apellidoPa = apellidoPa.Substring(0, 1) + apellidoPa.Substring(2, 1);
            }
            //Se crea la condicion en la que se valida si la segunda letra es consonante
            if (consonantes.Contains(apellidoPa[1])){
                apellidoPa = apellidoPa.Replace(apellidoPa.Substring(1), "X");
            }
            string apellidoMa = rfc.apellidoMa.Substring(0, 1).ToUpper();
            string nombre = rfc.nombre.Substring(0, 1).ToUpper();
            //Se crea condicion en la que el primer nombre sea comun y se tome la primera letra del segundo nombre
            foreach (string nombreComun in nombres)
            {
                if (rfc.nombre.StartsWith(nombreComun))
                {
                    string[] nombresSeparados = rfc.nombre.Split(' ');
                    if (nombresSeparados.Length > 1)
                    {
                        nombre = nombresSeparados[1].Substring(0, 1).ToUpper();
                    }
                    break;
                }
            }
            string fechaNac = rfc.fechaNac.ToString("yyMMdd");
            string rfcCreado = apellidoPa + apellidoMa + nombre;
            //Se crea condicion para que en caso de que la suma de la palabras del RFC den una prohibida, se cambie por X al final
            if (prohibidas.Contains(rfcCreado))
            {
                rfcCreado = rfcCreado.Remove(rfcCreado.Length -1) + "X";
            }
            string final = rfcCreado + fechaNac;

            return final;
        }

        public void Agregar(E_rfc rfc)
        {
            D_rfc rfc1 = new D_rfc();
            rfc1.Agregar(rfc);
        }

        public List<E_rfc> Mostrar_todos()
        {
            D_rfc datos = new D_rfc();

            return datos.Mostrar_todos();
        }

        public E_rfc Mostrar_Id(int id)
        {
            D_rfc datos = new D_rfc();

            return datos.mostrarPorId(id);
        }

        public void Actualizar(E_rfc rfc)
        {
            D_rfc datos = new D_rfc();

            datos.Actualizar(rfc);
        }

        public void Eliminar(E_rfc rfc)
        {
            D_rfc datos = new D_rfc();

            datos.Eliminar(rfc);
        }

        public int mostrartotal()
        {
            D_rfc datos = new D_rfc();

            return datos.mostrarActivos();
        }

        public List<E_rfc> Buscar(string texto)
        {
            D_rfc datos = new D_rfc();

            return datos.Buscar(texto);
        }

    }
}
