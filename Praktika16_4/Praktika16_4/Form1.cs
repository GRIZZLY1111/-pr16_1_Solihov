using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace Praktika16_4
{
    public partial class Form1 : Form
    {
        List<string[]> strani = new List<string[]>();
        string country = "Country.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!File.Exists(country))
            {
                MessageBox.Show("Такого файла не существует");
            }
            try
            {
                string[] lines = File.ReadAllLines(country);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        string countryName = parts[0].Trim();
                        int population = int.Parse(parts[1].Trim());
                        strani.Add(new string[] { parts[0].Trim(), population.ToString() });
                    }
                }
                
                var sort = strani
                    .Where(strana => int.Parse(strana[1]) > 104000000)
                    .OrderBy(strana => strana[0].Length)
                    .ThenBy(strana => strana[0])
                    .ToList();
                listBox1.Items.Clear();
                foreach (var strana in sort)
                {
                    string Name = strana[0];
                    int Naselenie = int.Parse(strana[1]);
                    listBox1.Items.Add($"{Name} {Naselenie}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(country))
            {
                MessageBox.Show("Такого файла не существует");
            }
            try
            {
                string[] lines = File.ReadAllLines(country);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        string countryName = parts[0].Trim();
                        int population = int.Parse(parts[1].Trim());
                        strani.Add(new string[] { parts[0].Trim(), population.ToString() });
                    }
                }
                listBox1.Items.Clear();
                foreach(var strana in strani)
                {
                    string Name = strana[0];
                    int Naselenie = int.Parse(strana[1]);
                    listBox1.Items.Add($"{Name} {Naselenie}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    foreach(var i in textBox1.Text)
                    {
                        if (char.IsLetter(i))
                        {
                        }
                        else
                        {
                            MessageBox.Show("В названии страны должны быть только буквы");
                            return;
                        }
                    }
                    StreamWriter s = File.AppendText(country);
                    s.WriteLine(textBox1.Text + " " + numericUpDown1.Value);
                    s.Close();
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод");
            }
        }
    }
}
