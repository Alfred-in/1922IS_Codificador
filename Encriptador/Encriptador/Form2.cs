using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encriptador
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form1 frm2 = new Form1();

            frm2.Close();
        }
        Criptografia cr;

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Ingresa texto");
                }
                else
                {
                    cr = new Criptografia(textBox1.Text);
                    cr.convertirANumero();
                    cr.cifrar();
                    for (int i = 0; i < cr.numeroVectores; i++)
                    {
                        richTextBox1.Text += "[";
                        for (int j = 0; j < 3; j++)
                        {
                            richTextBox1.Text += $" {cr.mensajeCifrado[i][j]} ";
                        }
                        richTextBox1.Text += "] \n";
                    }
                }

            }
              button2.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingresa texto");
            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                    cr.decifrar();
                    cr.convertirALetra();
                    label3.Text = cr.listaUnida;
                    for (int i = 0; i < cr.numeroVectores; i++)
                    {
                        richTextBox2.Text += "[";
                        for (int j = 0; j < 3; j++)
                        {
                            richTextBox2.Text += $" {cr.mensajeDecifrado[i][j]} ";
                        }
                        richTextBox2.Text += "] \n";
                    }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ingresa texto y codifica primero");
            }
           
        }
    }
}
