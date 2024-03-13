namespace vychmat1_2
{
    /// <summary>
    /// Класс алгоритмов решения СЛАУ.
    /// </summary>
    public static class Algorithms
    {
<<<<<<< HEAD
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
=======
        public static float[] ShuttleSolve(Matrix matrix, float[] bVector)
        {
            float[] res = new float[matrix.Rows];
            Matrix buffer = (Matrix)matrix.Clone();
            float[] bufVector = (float[])bVector.Clone();
            //if (!MatrixConverter.Tridiagonal.IsTridiagonal(buffer))
                //throw new ArgumentException("Матрица не трехдиагональная!");
            int n = buffer.Rows;
            float[] a = new float[n];
            float[] b = new float[n];
>>>>>>> double изменен на float
            a[0] = 0;
            b[0] = 0;
            for (int i = 1; i < n; i++)
            {
                a[i] = matrix[i - 1, i] / buffer[i - 1, i - 1];
                b[i] = bufVector[i - 1] / buffer[i - 1, i - 1];

                buffer[i, i] = matrix[i, i] - matrix[i, i - 1] * a[i];
                bufVector[i] = bVector[i] - matrix[i, i - 1] * b[i];
<<<<<<< HEAD
                buffer[i, i - 1] = 0.0;
=======
                buffer[i, i - 1] = 0.0f;
>>>>>>> double изменен на float
            }
            res[n - 1] = bufVector[n - 1] / buffer[n - 1, n - 1];
            while (n > 1)
            {
                n--;
                res[n - 1] = b[n] - a[n] * res[n];
            }
            return res;
        }
    }
}
