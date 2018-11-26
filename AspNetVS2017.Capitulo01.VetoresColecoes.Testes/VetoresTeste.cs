using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AspNetVS2017.Capitulo01.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var strings = new string[10];

            strings[0] = "A";
            //strings[-1] = "Outra Coisa"; //VETOR não pode ter Numero Negativo
            //strings[10] = "B"; //Não existe a Posição 10

            var decimais = new decimal[] { 0.5m, 78, 1.59m};

            //decimal[] novoDecimais = { 2, 3, 5.9m};

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanhodo Vetor: {decimais.Length}");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.5m, 78, 1.59m };

            Array.Resize(ref decimais, 5);

            decimais[3] = 20.01m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 35.89m, 0.5m, 78, 1.59m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], 0.5m);
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 35.89m, 0.5m, 78, 1.59m };
            Console.WriteLine(Media(decimais));

            //Utilizando o Método por causa do PARAMS
            //Sò é Usado com VETORES e 1 única vez
            //E também só utilizado no final da Instrução
            Console.WriteLine(Media(2, 8, 9.8m, 4.23m));
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            const string nome = "Hejlsberg"; //CONST é mais Leve do que um VAR

            Assert.AreEqual(nome[0], 'H'); //Toda STRING é um VETOR

            foreach (var @char in nome)
            {
                Console.WriteLine(@char);
            }
        }

        private decimal Media(decimal valor1, decimal valor2)
        {
            return (valor1 + valor2) / 2;
        }

        private decimal Media(params decimal[] valores)
        {
            decimal total = 0;

            foreach (var @decimal in valores)
            {
                total += @decimal;
            }

            return total;
        }

        ////private decimal Media(params decimal[] valores)
        //{
        //    return valores.Average();
        //}
    }
}
