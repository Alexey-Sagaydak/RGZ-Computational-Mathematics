namespace SolvingNonlinearEquations
{
    public class MathFunction
    {
        private readonly Func<float, float> function;

        private readonly Func<float, float> derivative;

        private readonly Func<float, float> secondDerivative;

        public MathFunction(Func<float, float> _function, Func<float, float> _derivative,
            Func<float, float> _secondDerivative)
        {
            function = _function;
            derivative = _derivative;
            secondDerivative = _secondDerivative;
        }

        public float Calculate(float x)
        {
            return function(x);
        }

        public float CalculateDerivative(float x)
        {
            return derivative(x);
        }

        public float CalculateSecondDerivative(float x)
        {
            return secondDerivative(x);
        }
    }
}
