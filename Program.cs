

namespace vychmat1_2
{
    class Program
    {
        static void Main()
        {
            //MatrixConsole.EnterSystem(out Matrix matrix, out double[] bVector);
            //Console.WriteLine("\nВведено: \n");
            //MatrixConsole.PrintSystem(matrix, bVector);
            //Console.WriteLine("\nРезультат: \n");
            double[,] matm = {
            {2.83333f, 5, 1},
            {1.7f, 3, 7},
            {8, 1, 1}
            };
            double[] vect = { 11.66666f, 13.4f, 18 };
            Matrix matrix = new Matrix(matm); 
            foreach (var r in Algorithms.GaussWithMainElement(matrix,vect)) Console.Write(Math.Round(r, 3) + " ");
        }
    }
}