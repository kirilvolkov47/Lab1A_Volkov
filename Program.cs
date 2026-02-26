using System;
using System.Text;

namespace Lab1_PartA
{
    class Program
    {
        static double[,] ReadMatrix()
        {
            int rows = 0;
            while (rows <= 0)
            {
                Console.Write("Кількість рядків: ");
                if (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
                    Console.WriteLine("Введіть коректне число");
            }

            int cols = 0;
            while (cols <= 0)
            {
                Console.Write("Кількість стовпців: ");
                if (!int.TryParse(Console.ReadLine(), out cols) || cols <= 0)
                    Console.WriteLine("Введіть коректне число");
            }

            double[,] mat = new double[rows, cols];
            Console.WriteLine("Вводіть рядки через пробіл:");
            for (int i = 0; i < rows; i++)
            {
                bool ok = false;
                while (!ok)
                {
                    Console.Write("  Рядок " + (i + 1) + ": ");
                    string[] parts = Console.ReadLine().Split(' ');
                    if (parts.Length != cols)
                    {
                        Console.WriteLine("Невірна кількість елементів");
                        continue;
                    }
                    ok = true;
                    for (int j = 0; j < cols; j++)
                    {
                        if (!double.TryParse(parts[j], out mat[i, j]))
                        {
                            Console.WriteLine("Невірний формат числа");
                            ok = false;
                            break;
                        }
                    }
                }
            }
            return mat;
        }

        static double[] ReadVector(int n)
        {
            Console.Write("Вектор B через пробіл: ");
            string[] parts = Console.ReadLine().Split(' ');
            double[] vec = new double[n];
            for (int i = 0; i < n; i++)
                vec[i] = double.Parse(parts[i]);
            return vec;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            double[,] A = {
                { 5, -1, -1 },
                { 3,  2, -1 },
                { 1, -2, -3 }
            };
            double[] B = { 5, 6, 2 };

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1 - Знайти обернену матрицю (за варіантом)");
                Console.WriteLine("2 - Обчислити ранг матриці (за варіантом)");
                Console.WriteLine("3 - Розв'язати СЛАР (за варіантом)");
                Console.WriteLine("4 - Знайти обернену матрицю (ввести вручну)");
                Console.WriteLine("5 - Обчислити ранг матриці (ввести вручну)");
                Console.WriteLine("6 - Розв'язати СЛАР (ввести вручну)");
                Console.WriteLine("0 - Вихід");
                Console.Write("Введіть номер >> ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        MatrixCalc.InverseMatrix(A);
                        break;
                    case "2":
                        MatrixCalc.FindRank(A);
                        break;
                    case "3":
                        MatrixCalc.SolveLinear(A, B);
                        break;
                    case "4":
                        {
                            double[,] mat = ReadMatrix();
                            MatrixCalc.InverseMatrix(mat);
                            break;
                        }
                    case "5":
                        {
                            double[,] mat = ReadMatrix();
                            MatrixCalc.FindRank(mat);
                            break;
                        }
                    case "6":
                        {
                            double[,] mat = ReadMatrix();
                            double[] vec = ReadVector(mat.GetLength(0));
                            MatrixCalc.SolveLinear(mat, vec);
                            break;
                        }
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}