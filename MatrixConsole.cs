﻿namespace vychmat1_2
{
    /// <summary>
    /// Ввод-вывод матрицы СЛАУ и вектора свободных коэффициентов в консоль.
    /// </summary>
    public static class MatrixConsole
    {
<<<<<<< HEAD
        public static void PrintSystem(Matrix matrix, double[] bVector)
=======
        public static void PrintSystem(Matrix matrix, float[] bVector)
>>>>>>> double изменен на float
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix[i, j]} * x{j + 1} ");
                    if (j + 1 != matrix.Columns) Console.Write("+ ");
                }
                Console.WriteLine($"= {bVector[i]}");
            }
        }

<<<<<<< HEAD
        public static void EnterSystem(out Matrix matrix, out double[] bVector)
=======
        public static void EnterSystem(out Matrix matrix, out float[] bVector)
>>>>>>> double изменен на float
        {
            string? str;
            Console.WriteLine("Введите размерность матрицы: ");
            int size;
            do
            {
                str = Console.ReadLine();
                if (!int.TryParse(str, out size) || size < 1)
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз: ");
                    str = null;
                }
            } while (string.IsNullOrEmpty(str));
            matrix = MatrixConsole.EnterMatrix(size);
            bVector = MatrixConsole.EnterB(size);
        }

        public static void WriteMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }

<<<<<<< HEAD
        public static void WriteB(double[] bVector)
=======
        public static void WriteB(float[] bVector)
>>>>>>> double изменен на float
        {
            foreach (var b in bVector)
                Console.Write($"{b} ");
        }

        public static Matrix EnterMatrix(int size)
        {
            Matrix newMatrix = new Matrix(size);
            string? str;
            string[] row;
            Console.WriteLine($"\nВведите значения матрицы размерности {size} через пробел:\n");
            for (int i = 0; i < size; i++)
            {
                str = Console.ReadLine();
                if (str == null)
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте ввести строку еще раз: ");
                    i--;
                    continue;
                }
                row = str.Split(' ');
                if (row.Length != size)
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте ввести строку еще раз: ");
                    i--;
                    continue;
                }
                for (int j = 0; j < size; j++)
                {
<<<<<<< HEAD
                    if (double.TryParse(row[j], out double res))
=======
                    if (float.TryParse(row[j], out float res))
>>>>>>> double изменен на float
                    {
                        newMatrix[i, j] = res;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод! Попробуйте ввести строку еще раз: ");
                        i--;
                        break;
                    }
                }
            }
            return newMatrix;
        }

<<<<<<< HEAD
        public static double[] EnterB(int rows)
        {
            double[] bVector = new double[rows];
=======
        public static float[] EnterB(int rows)
        {
            float[] bVector = new float[rows];
>>>>>>> double изменен на float
            string? str;
            string[] values;
            bool flag;
            Console.WriteLine($"\nВведите столбец свободных коэффициентов В размерности {rows} через пробел:\n");
            do
            {
                flag = false;
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз: ");
                    flag = true;
                    continue;
                }
                values = str.Split(' ');
                if (values.Length != rows)
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз: ");
                    flag = true;
                    continue;
                }
                for (int i = 0; i < rows; i++)
                {
<<<<<<< HEAD
                    if (double.TryParse(values[i], out double res))
=======
                    if (float.TryParse(values[i], out float res))
>>>>>>> double изменен на float
                        bVector[i] = res;
                    else
                    {
                        Console.WriteLine("Некорректный ввод! Попробуйте еще раз: ");
                        flag = true;
                        continue;
                    }
                }
            } while (flag);
            return bVector;
        }
    }
}
