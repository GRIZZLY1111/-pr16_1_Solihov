using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace praktika16_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите массив строк");
            List<string> arr = new List<string>();
            arr.Add(Console.ReadLine());
            int digitcount = 0;
            var digits = "";
            foreach(var str in arr)
            {
                foreach(var ch in str)
                {
                    if (char.IsDigit(ch))
                    {
                        digitcount++;
                        digits += ch + " ";
                    }
                }
            }
            Console.WriteLine($"Количество цифр в массиве из строк = {digitcount}. Цифры:{digits}");
            Console.WriteLine("Элементы массива до символа /");
            foreach(var str in arr)
            {
                int index = str.IndexOf('/');
                if (index == -1)
                {
                    Console.WriteLine(str);
                }
                else
                {
                    Console.WriteLine(str.Substring(0, index));
                    break;
                }
            }
            Console.WriteLine("Элементы массива после символа / с изменением регистра");
            List<string> izmenenie = new List<string>();
            foreach(var str in arr)
            {
                int index = str.IndexOf('/');
                if (index != -1 && index < str.Length)
                {
                    string slesh = str.Substring(index + 1);
                    string izmenen = new string(slesh.Select(ch =>
                    char.IsLetter(ch) ? (char.IsUpper(ch) ? char.ToLower(ch) : char.ToUpper(ch)) : ch
                    ).ToArray());
                    izmenenie.Add(izmenen);
                    Console.WriteLine(izmenen);
                }
            }
            StreamWriter s = File.CreateText("1.txt");
            s.WriteLine(izmenenie);
            s.Close();
            Console.ReadKey();
        }
    }
}
