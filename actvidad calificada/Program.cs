using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actvidad_calificada
{
    internal class Program
    {
            static bool validardatos(double precio, int cantidad)
            {       
                if (precio > 0 && cantidad > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Alerta precio o la cantidad no son validos ");
                    return false;
                }       
            }
            static void buscarorden(string codigobuscado, string[] codigos, string[] provedoores, double[,] datos)
            {
                bool encontrado = false;
                for (int i = 0; i < codigos.Length; i++)
                {
                    if (codigos[i] == codigobuscado && codigos[i] != "")
                    {
                        double monto = datos[i, 0] * datos[i, 1];
                        Console.WriteLine("ENCONTRADO");
                        Console.WriteLine("proveedor: " + provedoores[i]);
                        Console.WriteLine("monto: $ " + monto.ToString("N2"));
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    Console.WriteLine("ERROR: codigo no encontrado.");
                }
            }
        static void main()
        {
            string[] codigos =
            {
                    "OC-101","OC-102","OC-103", "OC-104","OC-105","OC-106"
                };
            string[] provedoores =
            {
                    "TechCorp", "LogiExpress", "InsumosGlobal", "TechCorp1", "AlfaSuministros", "ServiRedes"
                };
            double[,] datos =
            {
                    {150.0, 10},
                    {450.0, 2},
                    {80.0, 50},
                    {1200.0, 1},
                    {25.0, 100},
                    {600.0, 3},
                };
            double[] montos = new double[5];
            double totalacumulado = 0;
            int contadorcriticos = 0;

            for (int i = 0; i < 5; i++)
            {
                double precio = datos[i, 0];
                int cantidad = (int)datos[i, 1];
                if (validardatos(precio, cantidad))
                {
                    montos[i] = precio * cantidad;

                    totalacumulado += montos[i];
                    if (montos[i] > 1000)
                    {
                        contadorcriticos++;
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        //cambio de montos
                        double montoCambio = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = montoCambio;
                        //cambio de codigo
                        string codigoCambio = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = codigoCambio;
                        //cambio de proovedores
                        string provedoresCambio = provedoores[j];
                        provedoores[j] = provedoores[j + 1];
                        provedoores[j + 1] = provedoresCambio;
                        //cambio de las filas
                        for (int k = 0; k < 2; k++)
                        {
                            double datosCambio = datos[j, k];
                            datos[j, k] = datos[j + 1, k];
                            datos[j + 1, k] = datosCambio;
                        }
                    }
                }
            }
        }
        static void main(string[] args)
        {

        }       
    }
}
