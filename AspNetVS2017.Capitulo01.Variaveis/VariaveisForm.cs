using System;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Variaveis
{
    public partial class VariaveisForm : Form
    {
        //16 Bytes de Memória executando
        int x = 32;
        int w = 45;
        int y = 16;
        int z = 32;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = 2;
            int b = 6;
            int c = 10;
            int d = 13;

            //int meuInteiro = 10;
            //decimal valor = 22.39m;
            //string nome = "Paulo";
            //bool aprovado = true;
            //DateTime dataNascimento = new DateTime(1982, 11, 14);
            //int f = 17;
            //var sobrenome = "Rocha";

            //decimal nota = 0;
            //if (nota > 7)
            //{

            //}

            //var @decimal = 0.2m;

            //Consumo de 20 bytes
            //object meuObjeto = 45;
            //meuObjeto = "Paulo";


            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ", b));
            resultadoListBox.Items.Add(string.Format("c = {0}", c));
            resultadoListBox.Items.Add($"d = {d}");

            resultadoListBox.Items.Add("-------------------");

            resultadoListBox.Items.Add("c * d = " + (c * d));
            resultadoListBox.Items.Add("c / d = " + (c / d));
            resultadoListBox.Items.Add("d % a = " + (d % a));
            
        }

        private void resultadoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;

            resultadoListBox.Items.Add("x = " + x);

            //x = x - 3;
            x -= 3;

            resultadoListBox.Items.Add("x = " + x);
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo Pré-Incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + ++a = " + (2 + ++a));

            a = 5;
            resultadoListBox.Items.Add("Exemplo Pós-Incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + a++ = " + (2 + a++));
            resultadoListBox.Items.Add("a = " + a);
        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApresentarVariaveis();

            resultadoListBox.Items.Add("w <= x = " + (w <= x)); //False
            resultadoListBox.Items.Add("x == z = " + (x == z)); //True
            resultadoListBox.Items.Add("x != z = " + (x != z)); //False
        }

        private void ApresentarVariaveis()
        {
            resultadoListBox.Items.Add("x = " + x);
            resultadoListBox.Items.Add("w = " + w);
            resultadoListBox.Items.Add("y = " + y);
            resultadoListBox.Items.Add("z = " + z);

            resultadoListBox.Items.Add(new string('-', 50));
        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApresentarVariaveis();

            // || o OU somente será FALSE quando as Afirmações forem todas FALSE
            // && o OU somente será TRUE quando as Afirmações forem todas TRUE
            // ! NEGACAO


            //w = False
            //y = True
            
            resultadoListBox.Items.Add("w <= x || y == 16 = " + (w <= x || y == 16));
            resultadoListBox.Items.Add("x == z && z != z = " + (w == z && x != z));
            resultadoListBox.Items.Add("!(y > w) = " + (!(y > w)));
        }

        private void ternariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;

            ano = 2014;
            resultadoListBox.Items.Add(string.Format("O Ano {0} é Bissexto ? {1}.", ano, 
                ano % 4 == 0 ? "Sim" : "Não"));

            ano = 2016;
            resultadoListBox.Items.Add(string.Format("O Ano {0} é Bissexto ? {1}.", ano,
                DateTime.IsLeapYear(ano) ? "Sim" : "Não"));
        }
    }
}
