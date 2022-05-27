using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Encriptador
{
    internal class Criptografia
    {
        public String mensaje { get; set; }
        public int[,] matrizClave { get; set; }
        public int[][] matrizNumero { get; set; }
        public Double[,] matrizInversa { get; set; }
        public int[][] mensajeCifrado { get; set; }
        public Double[][] mensajeDecifrado { get; set; }
        public String[] caracteres { get; set; }
        public String listaUnida { get; set; }
        public List<String> mensajeNumero = new List<string>();
        public List<String> mensajeLetra = new List<string>();        
        public int numeroVectores { get; set; }
        static String[,] abecedario = { { "A", "B","C","D","E","F","G","H","I","J","K","L","M","N","Ñ","O","P","Q","R","S","T","U","V","W","X","Y","Z"," ","." } ,
       {"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","0","28"} };
        static String[,] abecedarioInversoN = { { "28", "27", "26", "25", "24", "23", "22", "21", "20", "19", "18", "17", "16", "15", "14", "13", "12", "11", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0","_" },
         { ".","Z","Y","X","W","V","U","T","S","R","Q","P","O","Ñ","N","M","L","K","J","I","H","G","F","E","D","C","B","A"," ",""}};
        public Criptografia()
        {

        }
        public Criptografia(string mensaje)
        {
            this.mensaje = mensaje.ToUpper();
            this.matrizClave = new int[3, 3] {
                {1, 2, 1},
                {0,-1, 3},
                {2, 1, 0} };
            this.matrizInversa = new Double[3, 3] {
                { -0.27, 0.09, 0.63},
                { 0.54, -0.18,-0.27 },
                { 0.18, 0.27, -0.09 } };
        }
        public void convertirANumero()
        {
            caracteres = Regex.Split(mensaje, "");
            String temp = mensaje;
            for (int i = 0; i < 29; i++)
            {
                temp = temp.Replace(abecedario[0, i], $"{abecedario[1, i]}_");
            }
            var aux = temp.Split('_');
            foreach (var item in aux)
            {
                if (item != "")
                {
                    mensajeNumero.Add(item);
                }
            }
            do
            {
                if (mensajeNumero.Count() % 3 == 0)
                {
                    Console.WriteLine("ci");
                }
                else
                {
                    mensajeNumero.Add("0");
                }
            } while (mensajeNumero.Count() % 3 != 0);
            matrizNumero = new int[mensajeNumero.Count() / 3][];
            numeroVectores = mensajeNumero.Count() / 3;
            int j = 0;
            for (int i = 0; i < mensajeNumero.Count(); i = i + 3)
            {

                matrizNumero[j] = new int[] { int.Parse(mensajeNumero[i]), int.Parse(mensajeNumero[i + 1]), int.Parse(mensajeNumero[i + 2]) };
                j++;
            }

        }
        public void cifrar()
        {
            mensajeCifrado = new int[numeroVectores][];
            int j = 0;
            for (int i = 0; i < numeroVectores; i++)
            {

                mensajeCifrado[i] = new int[]
                { matrizNumero[i][0]*matrizClave[0,0]+matrizNumero[i][1]*matrizClave[1,0]+matrizNumero[i][2]*matrizClave[2,0],
                  matrizNumero[i][0]*matrizClave[0,1]+matrizNumero[i][1]*matrizClave[1,1]+matrizNumero[i][2]*matrizClave[2,1],
                  matrizNumero[i][0]*matrizClave[0,2]+matrizNumero[i][1]*matrizClave[1,2]+matrizNumero[i][2]*matrizClave[2,2]};
            }
        }
        public void decifrar()
        {
            mensajeDecifrado = new Double[numeroVectores][];
            int j = 0;
            for (int i = 0; i < numeroVectores; i++)
            {

                mensajeDecifrado[i] = new Double[]
                { Math.Round(mensajeCifrado[i][0]*matrizInversa[0,0]+mensajeCifrado[i][1]*matrizInversa[1,0]+mensajeCifrado[i][2]*matrizInversa[2,0]),
                  Math.Round(mensajeCifrado[i][0]*matrizInversa[0,1]+mensajeCifrado[i][1]*matrizInversa[1,1]+mensajeCifrado[i][2]*matrizInversa[2,1]),
                  Math.Round(mensajeCifrado[i][0]*matrizInversa[0,2]+mensajeCifrado[i][1]*matrizInversa[1,2]+mensajeCifrado[i][2]*matrizInversa[2,2])};
            }
        }
        public void convertirALetra()
        {
            for (int i = 0; i < numeroVectores; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mensajeLetra.Add(mensajeDecifrado[i][j] + "");
                }

            }
            listaUnida = String.Join("_", mensajeLetra.ToArray());
            for (int i = 0; i < 30; i++)
            {

                listaUnida = listaUnida.Replace(abecedarioInversoN[0, i], $"{abecedarioInversoN[1, i]}");


            }

        }

    }
}
