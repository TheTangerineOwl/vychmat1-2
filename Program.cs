

namespace vychmat1_2
{
    class Program
    {
        static void Main()
        {
<<<<<<< HEAD
            MatrixConsole.EnterSystem(out Matrix matrix, out double[] bVector);
=======
            MatrixConsole.EnterSystem(out Matrix matrix, out float[] bVector);
>>>>>>> double изменен на float
            Console.WriteLine("\nВведено: \n");
            MatrixConsole.PrintSystem(matrix, bVector);
            Console.WriteLine("\nРезультат: \n");
            foreach (var r in Algorithms.ShuttleSolve(matrix, bVector)) Console.Write(Math.Round(r, 3) + " ");
        }
    }
}