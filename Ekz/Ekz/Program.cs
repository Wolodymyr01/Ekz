using System;
using System.IO;
using static System.Convert;

namespace Ekz
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr;
            using (var sr = new StreamReader(new FileStream("Inlet.in", FileMode.Open)))
            {
                arr = sr.ReadToEnd().Split("\n");
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            int N = ToInt32(arr[0]);
            double[] A = new double[arr.Length - 1];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = ToDouble(arr[i + 1]);
            }
            double[] B = new double[A.Length];
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = 0;
                for (int j = 0; j <= i; j++)
                {
                    B[i] += A[j];
                }
                B[i] /= (i + 1);
            }
            string s = null;
            foreach (var item in B)
            {
                s += $"{item} ";
            }
            using (var sw = new StreamWriter(new FileStream("Outlet.out", FileMode.OpenOrCreate)))
            {
                sw.WriteLine(s);
            }
        }
    }
}
