using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3._1_HLP
{
    internal class Program
    {
        static void MinEveryMatrixRow(in int[][] matrix, out int[] mins)
        {
            int n = matrix.GetLength(0);
            mins = new int[n];
            for (int i = 0; i < n; i++)
            {
                mins[i] = int.MaxValue;
                if (matrix[i].Length == 0) mins[i] = 0;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < mins[i]) mins[i] = matrix[i][j];
                }
            }
            return;
        }
        static void MaxEveryMatrixRow(in int[][] matrix, out int[] maxs)
        {
            int n = matrix.GetLength(0);
            maxs = new int[n];
            for (int i = 0; i < n; i++)
            {
                maxs[i] = int.MinValue;
                if (matrix[i].Length == 0) maxs[i] = 0;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > maxs[i]) maxs[i] = matrix[i][j];
                }
            }
            return;
        }
        static void SumEveryMatrixRow(in int[][] matrix, out int[] sums)
        {
            int n = matrix.GetLength(0);
            sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                sums[i] = 0;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sums[i] += matrix[i][j];
                }
            }
            return;
        }
        static void InputMatrix(ref int[][] matrix)
        {
            bool parse_successful;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write($"{i+1} row ");
                string[] input_array = Console.ReadLine().Split(' ');
                int double_spacebar = 0;
                for (int j = 0; j < input_array.Length; j++)
                {
                    if (input_array[j].Length == 0) double_spacebar++;
                }
                matrix[i] = new int[input_array.Length - double_spacebar];
                int internal_index = -1;
                for (int j = 0; j < input_array.Length; j++)
                {
                    if (input_array[j] == "") continue;
                    internal_index++;
                    parse_successful = int.TryParse(input_array[j], out matrix[i][internal_index]);
                    if (!parse_successful) matrix[i][internal_index] = 0;
                }
            }
            return;
        }
        static void Main(string[] args)
        {
            int n;
            string temp_n;
            do
            {
                Console.Write("Input n:");
                temp_n = Console.ReadLine();
            }
            while (!int.TryParse(temp_n, out n));
            int[][] matrix = new int[n][];
            InputMatrix(ref matrix);
            int[] sums;
            int[] mins;
            int[] maxs;
            SumEveryMatrixRow(matrix, out sums);
            MinEveryMatrixRow(matrix, out mins);
            MaxEveryMatrixRow(matrix, out maxs);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{sums[i]} | {mins[i]} | {maxs[i]}");
            }
            Console.ReadLine();
        }
    }
}
