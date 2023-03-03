namespace SolvingNonlinearEquations
{
    public static class Program
    {
        public static void Main()
        {
            float EPSILON1 = 0.001f, EPSILON2 = 0.001f;

            MathFunction Function = new MathFunction(
                x => (float)(Math.Pow(Math.E, x) - 2 * x - 2),
                x => (float)(Math.Pow(Math.E, x) - 2),
                x => (float)Math.Pow(Math.E, x)
                );

            ChordMethodCalculator Calculator3 = new ChordMethodCalculator(Function);

            Console.WriteLine("Equation: e^x - 2x - 2 = 0\n");
            Console.WriteLine("Expected solution:\n-0,768039\n1,67835\n");

            Console.WriteLine("Chord method solution:");
            Console.WriteLine(Calculator3.Solve(-1, 0, EPSILON1));
            Console.WriteLine(Calculator3.Solve(1, 2, EPSILON2));
        }
    }
}
