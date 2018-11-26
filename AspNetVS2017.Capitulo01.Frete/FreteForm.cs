using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Frete
{
    public partial class FreteForm : Form
    {
        public FreteForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var erros = ValidarFormulario();

            if (erros.Count == 0)
            {
                Calcular();
            }

            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros),
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private List<string> ValidarFormulario()
        {
            var erros = new List<string>();

            //if (clienteTextBox.Text == string.Empty)
            if (string.IsNullOrEmpty (clienteTextBox.Text))
            {
                erros.Add("O Campo Ciente é Obrigatório");
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("Selecione uma UF");
            }

            if (valorTextBox.Text == string.Empty)
            {
                erros.Add("O Campo Valor é Obrigatório");
            }

            else
            {
                //var valor = 0m;
                if (!decimal.TryParse(valorTextBox.Text, out decimal valor))
                {
                    //var x = valor;
                    erros.Add("O Campo Valor está com o Formato Inválido");
                }
            }
            return erros;
        }
        
        private void Calcular()
        {
            var percentual = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);
            var nordeste = new List<string> { "BA", "PE", "AL"};

            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentual = 0.2m;
                    break;

                case "RJ":
                    percentual = 0.3m;
                    break;

                case "MG":
                    percentual = 0.35m;
                    break;

                case "AM":
                    percentual = 0.6m;
                    break;

                case var uf when nordeste.Contains(uf):
                    percentual = 0.45m;
                    break;

                case null:
                    throw new NullReferenceException("ComboBox Nulo");

                default:
                    percentual = 0.5m;
                    break;
            }

            if (ufComboBox.Text.ToUpper() == "SP")
            {
                percentual = 0.2m;
            }

            else if (ufComboBox.Text.ToUpper() == "RJ")
            {
                percentual = 0.3m;
            }

            else if (ufComboBox.Text.ToUpper() == "MG")
            {
                percentual = 0.3m;
            }

            else
            {
                percentual = 0.5m;
            }

            freteTextBox.Text = percentual.ToString("P1");
            totalTextBox.Text = (valor * (1 + percentual)).ToString("C2");
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.Text = string.Empty;
            ufComboBox.SelectedIndex = -1;
            valorTextBox.Text = null;
            freteTextBox.Clear();
            totalTextBox.Text = "";

            clienteTextBox.Focus();

            //this.Close();
        }
    }
}
