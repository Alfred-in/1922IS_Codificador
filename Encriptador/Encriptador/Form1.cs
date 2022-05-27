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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || maskedTextBox1.Text.Equals(""))
            {
                MessageBox.Show("Ingresa Usuario y contraseña");
            }
            else
            {
                if (textBox1.Text.Equals("root"))
                {
                    if (maskedTextBox1.Text.Equals("123456"))
                    {                        
                        MessageBox.Show("correcto, Bienvenido c:");                        
                        Form2 frm2 = new Form2();                        
                        frm2.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                }
            }
           

        }

    }
}
