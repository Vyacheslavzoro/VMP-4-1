using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program1
    {
        
        static void FindingTheMinimum(in int[][] array, out string res)
        {
            res = "";
            for (int i = 0; i < array.Length; i++)
            {
                int minimum = array[i][0];
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j] < minimum)
                        minimum = array[i][j];
                }
                res += $"{minimum} ";
            }
        }
        static void FindingTheMaximum(in int[][] array, out string res)
        {
            res = "";
            for (int i = 0; i < array.Length; i++)
            {
                int maximum = array[i][0];
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j] > maximum)
                        maximum = array[i][j];
                }
                res += $"{maximum} ";
            }
        }
        static void Sum(in int[][] array, ref int[] res)
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];
                res[index++] = sum;
            }
        }

        static void Print(in int[][] array)
        {
            Console.WriteLine("Вывод массива");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write($"{array[i][j]} ");
                Console.WriteLine();
            }
        }




        static void Main(string[] args)
        {
           int n = -1;
           Console.Write("Количество строк = ");
           n = Convert.ToInt32(Console.ReadLine());
                
           

            int[][] array = new int[n][];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string str = Convert.ToString(input[0]);
                int counter = 0;
                for (int j = 1; j < input.Length; j++)
                {
                    if (input[j] != ' ' && input[j - 1] != ' ' || input[j] != ' ' && input[j - 1] == ' ')
                    {
                        str += input[j];
                        if (j == input.Length - 1)
                            counter++;
                        continue;
                    }
                    else if (input[j] == ' ' && input[j - 1] == ' ')
                    {
                        continue;
                    }
                    else if (input[j] == ' ' && input[j - 1] != ' ')
                    {
                        counter++;
                        str = "";
                    }
                }
                array[index++] = new int[counter];
                str = Convert.ToString(input[0]);
                int arrayIndex = 0;
                for (int j = 1; j < input.Length; j++)
                {
                    if (input[j] != ' ' && input[j - 1] != ' ' || input[j] != ' ' && input[j - 1] == ' ')
                    {
                        str += input[j];
                        int num = 0;
                        if (j == input.Length - 1)
                            try
                            {
                                num = Convert.ToInt32(str);
                            }
                            catch (FormatException)
                            {
                                num = 0;
                            }
                            finally
                            {
                                array[i][arrayIndex++] = num;
                            }
                        continue;
                    }
                    else if (input[j] == ' ' && input[j - 1] == ' ')
                    {
                        continue;
                    }
                    else if (input[j] == ' ' && input[j - 1] != ' ')
                    {
                        int num = 0;
                        try
                        {
                            num = Convert.ToInt32(str);
                        }
                        catch (FormatException)
                        {
                            num = 0;
                        }
                        finally
                        {
                            array[i][arrayIndex++] = num;
                        }
                        str = "";
                    }
                }
            }

            Print(in array);
            FindingTheMinimum(in array, out string res1);
            Console.WriteLine($"Минимумы: {res1}");
            FindingTheMaximum(in array, out string res2);
            Console.WriteLine($"Максимумы: {res2}");
            int[] res3 = new int[n];
            Sum(in array, ref res3);
            Console.Write("Суммы: ");
            for (int i = 0; i < n; i++)
                Console.Write($"{res3[i]} ");
        }
    }
}