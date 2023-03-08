namespace Task_2;
public static class Program
{
    public static void Main()
    {
        try
        {
            float[,] matrixValues =
            {
                { 0, -0.313f, -0.313f, 1.25f },
                { -0.27f, 0, -0.27f, 1.216f },
                { -0.238f, -0.238f, 0, 1.19f },
            };

            float epsilon = 0.001f;

            Matrix matrix = new Matrix(matrixValues, 3, 4);
            SimpleIterationMethod seidelMethod = new SimpleIterationMethod();
            float[] solution = seidelMethod.Solve(matrix, epsilon, true);

            Console.WriteLine("Expected solution:\n0,745 0,792 0,825\n");

            Console.WriteLine("Simple iteration method solution:");
            foreach (var val in solution)
            {
                Console.Write($"{val} ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}