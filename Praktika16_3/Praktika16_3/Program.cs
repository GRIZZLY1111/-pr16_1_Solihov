using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika16_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = new double[] { 5.1, 1.3, 9.2, 2, 3, 5.1, 3};
            Dictionary<double, int> frequency = new Dictionary<double, int>();

            foreach (double num in arr)
            {
                if (frequency.ContainsKey(num))
                    frequency[num]++;
                else
                    frequency[num] = 1;
            }
            Console.WriteLine("Число\tЧастота");
            foreach (var item in frequency)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }

            double[] newArray = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = arr[i] * frequency[arr[i]];
            }
            Console.WriteLine("\nЧисло\tЧастота(старого массива)");
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.WriteLine($"{newArray[i]}\t{frequency[arr[i]]}");
            }
            Console.ReadKey();
        }
    }
}
