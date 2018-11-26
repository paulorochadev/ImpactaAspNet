using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetVS2017.Capitulo01.VetoresColecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTest()
        {
            var inteiros = new List<int>(50) { 2, 1, 2, 6, 125};
            inteiros.Add(22);
            //inteiros[12] = 89;

            var maisInteiros = new List<int> { 21, 72, 14, 6 };

            inteiros.AddRange(maisInteiros); //ADD inserir no FINAL da LISTA
            inteiros.Insert(0, 29); //INSERT insere o Valor na POSICAO informada /redimensiona/empurra as demais posições
            inteiros.Remove(2); //REMOVE o 1º Valor/Item encontrado da LISTA
            inteiros.RemoveAt(5); //REMOVE o Valor encontrado na POSICAO exata
            inteiros.Sort(); //ORDENAR a LISTA

            //var primeiro = inteiros[0];
            var primeiro = inteiros.FirstOrDefault();
            //var ultimo = inteiros[inteiros.Count -1];
            var ultimo = inteiros.LastOrDefault();

            var estahVazia = inteiros.Count == 0;

            foreach (var @inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }

            for (int i = 0; i < inteiros.Count; i++)
            {
                Console.WriteLine($"Para cada inteiros = { i} : { inteiros[i] }");
            }
        }

        [TestMethod]
        public void DictionaryTest()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(new DateTime(2018, 12, 25), "Natal");
            feriados.Add(new DateTime(2019, 1, 1), "Ano Novo");
            feriados.Add(new DateTime(2019, 1, 25), "Aniversário SP");
            //feriados.Add(new DateTime(2019, 1, 25), "Aniversário SP"); //A Chave não pode REPETIR

            var natal = feriados[new DateTime(2018, 12, 25)];

            foreach (var feriado in feriados)
            {
                //Console.WriteLine(string.Format("{0}: {1}", feriado.Key, feriado.Value));
                //Console.WriteLine(string.Format("{0}: {1}", feriado.Key.ToShortDateString(), feriado.Value));
                //Console.WriteLine(string.Format("{0:dd/MM/yyyy}: {1}", feriado.Key, feriado.Value));
                //Console.WriteLine(string.Format("{0:dd/MM}: {1}", feriado.Key, feriado.Value));
                Console.WriteLine(string.Format("{0}: {1}", feriado.Key.ToString("dd/MM"), feriado.Value));
            }

            Console.WriteLine(feriados.ContainsKey(Convert.ToDateTime("25/12/2018")));
            Console.WriteLine(feriados.ContainsValue("Ano Novo"));
        }
    }
}
