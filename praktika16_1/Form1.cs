using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace praktika16_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text!="" && textBox2.Text != "")
                {
                    string[] dot = textBox2.Text.Split('.');
                    string filename = "";
                    if (dot.Length == 0)
                    {
                        filename = textBox2.Text;
                    }
                    else
                    {
                        filename = textBox2.Text + ".txt";
                    }
                    if (File.Exists(filename))
                    {
                        string slovo = textBox1.Text;
                        string text = File.ReadAllText(filename);
                        int Kolwo = text
                            .Split(new char[] { ' ',',','!','.','?',':',';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Count(word => word.Equals(slovo, StringComparison.OrdinalIgnoreCase));
                        label2.Text = label2.Text + Kolwo;
                    }
                    else
                    {
                        MessageBox.Show("Такого файла не существует или введено некорректное имя файла");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Перед нажатием на кнопку заполните поля ввода");
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод");
            }
        }
    }
}
