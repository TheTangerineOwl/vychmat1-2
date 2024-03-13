namespace vychmat1_2
{
    /// <summary>
    /// Класс алгоритмов решения СЛАУ.
    /// </summary>
    public static class Algorithms
    {
        public static double[] ShuttleSolve(Matrix matrix, double[] bVector)
        {
            double[] res = new double[matrix.Rows];
            Matrix buffer = (Matrix)matrix.Clone();
            double[] bufVector = (double[])bVector.Clone();
            //if (!MatrixConverter.Tridiagonal.IsTridiagonal(buffer))
                //throw new ArgumentException("Матрица не трехдиагональная!");
            int n = buffer.Rows;
            double[] a = new double[n];
            double[] b = new double[n];
            a[0] = 0;
            b[0] = 0;
            for (int i = 1; i < n; i++)
            {
                a[i] = matrix[i - 1, i] / buffer[i - 1, i - 1];
                b[i] = bufVector[i - 1] / buffer[i - 1, i - 1];

                buffer[i, i] = matrix[i, i] - matrix[i, i - 1] * a[i];
                bufVector[i] = bVector[i] - matrix[i, i - 1] * b[i];
                buffer[i, i - 1] = 0.0;
            }
            res[n - 1] = bufVector[n - 1] / buffer[n - 1, n - 1];
            while (n > 1)
            {
                n--;
                res[n - 1] = b[n] - a[n] * res[n];
            }
            return res;
        }

        public static void SwapRows(Matrix matrix, int row1, int row2)
        {
            int cols = matrix.values.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        public static double[,] AddVectorToMatrix(Matrix matrix, double[] vector)
        {
            int rows = matrix.values.GetLength(0);
            int cols = matrix.values.GetLength(1);
            double[,] result = new double[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j];
                }
                result[i, cols] = vector[i];
            }
            return result;
        }


        public static double[] GaussWithoutMainElement(Matrix matrix, double[] vector)
        {
            Matrix fullMatrix = new Matrix(AddVectorToMatrix(matrix, vector));
            int rows = fullMatrix.values.GetLength(0);
            int cols = fullMatrix.values.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                int firstNonZero = i;
                while (firstNonZero < rows && fullMatrix[firstNonZero, i] == 0)
                {
                    firstNonZero++;
                }

                if (firstNonZero == rows)
                {
                    continue;
                }

                SwapRows(fullMatrix, i, firstNonZero);

                for (int j = i + 1; j < rows; j++)
                {
                    double factor = fullMatrix[j, i] / fullMatrix[i, i];
                    for (int k = i; k < cols; k++)
                    {
                        fullMatrix[j, k] -= factor * fullMatrix[i, k];
                    }
                }
            }

            double[] solution = new double[rows];
            for (int i = rows - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < cols - 1; j++)
                {
                    sum += fullMatrix[i, j] * solution[j];
                }
                solution[i] = (fullMatrix[i, cols - 1] - sum) / fullMatrix[i, i];
            }
            return solution;
        }

        public static double[] GaussWithMainElement(Matrix matrix, double[] vector)
        {
            Matrix fullMatrix = new Matrix(AddVectorToMatrix(matrix, vector));
            int rows = fullMatrix.values.GetLength(0);
            int cols = fullMatrix.values.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int maxRow = i;
                double maxVal = Math.Abs(fullMatrix[i, i]);

                for (int j = i + 1; j < rows; j++)
                {
                    double absVal = Math.Abs(fullMatrix[j, i]);
                    if (absVal > maxVal)
                    {
                        maxVal = absVal;
                        maxRow = j;
                    }
                }

                if (maxRow != i)
                {
                    SwapRows(fullMatrix, i, maxRow);
                }

                for (int j = i + 1; j < rows; j++)
                {
                    double factor = fullMatrix[j, i] / fullMatrix[i, i];
                    for (int k = i; k < cols; k++)
                    {
                        fullMatrix[j, k] -= factor * fullMatrix[i, k];
                    }
                }
            }

            double[] solution = new double[rows];
            for (int i = rows - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < cols - 1; j++)
                {
                    sum += fullMatrix[i, j] * solution[j];
                }
                solution[i] = (fullMatrix[i, cols - 1] - sum) / fullMatrix[i, i];
            }
            return solution;
        }

    }
}
