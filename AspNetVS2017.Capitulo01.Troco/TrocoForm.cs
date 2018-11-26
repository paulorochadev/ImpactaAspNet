using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Troco
{
    public partial class TrocoForm : Form
    {
        public TrocoForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var valorCompra = Convert.ToDecimal (valorCompraTextBox.Text);
            var valorPago = Convert.ToDecimal (valorPagoTextBox.Text); // CONVERT para Números, faz ARREDONDAMENTO
            //var valorPago = decimal.Parse (valorPagoTextBox.Text); PARSE só trabaha com STRING

            var troco = valorPago - valorCompra;

            trocoTextBox.Text = troco.ToString("C2");

            // Listar Tarefas - LEMBRETES
            // ToDo: Refatorar para Usar Vetor com Foreach

            //var moedas1 = (int)(troco/1);
            //troco %= 1;

            //var moedas050 = (int)(troco / 0.5m);
            //troco %= 0.5m;

            //var moedas025 = (int)(troco / 0.25m);
            //troco %= 0.25m;

            //var moedas010 = (int)(troco / 0.1m);
            //troco %= 0.1m;

            //var moedas005 = (int)(troco / 0.05m);
            //troco %= 0.05m;

            //var moedas001 = (int)(troco / 0.01m);
            //troco %= 0.01m;

            //moedasListView.Items[0].Text = moedas1.ToString();
            //moedasListView.Items[1].Text = moedas050.ToString();
            //moedasListView.Items[2].Text = moedas025.ToString();
            //moedasListView.Items[3].Text = moedas010.ToString();
            //moedasListView.Items[4].Text = moedas005.ToString();
            //moedasListView.Items[5].Text = moedas001.ToString();

            var moedas = new decimal[] { 1, 0.5m, 0.25m, 0.1m, 0.05m, 0.01m};

            for (int i = 0; i < moedas.Length; i++)
            {
                moedasListView.Items[i].Text = ((int)(troco / moedas[i])).ToString();
                troco %= moedas[i];
            }
        }
    }
}
