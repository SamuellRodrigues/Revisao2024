using System;
 using System.Text;
 namespece GeradorDeSenhas {
    class Program {
        static void Main(string[] args){
            int qtd = 20 ;
            string caracteresPossiveis = "ABCDEFGHIJKLMNOPQRSTUVMXYZÇ" + "ABCDEFGHIJKLMNOPQRSTUVMXYZÇ".ToLower()+ "0123456789" + "%$#!@";

            Random sorteio = new Random();
            int numeroSorteado = 0;
            stringBuilder password = new stringBuilder();
            for(int t = 0; t < qtd; t++){
                numeroSorteado = sorteio.Next(0, caracteresPossiveis.Length - 1);
                password.Append(caracteresPossiveis[numeroSorteado]);

            }
            Console.Write(password);
            Console.Readkey();
        }

    }
 }
