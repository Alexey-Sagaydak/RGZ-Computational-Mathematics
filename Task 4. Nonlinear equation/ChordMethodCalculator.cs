namespace SolvingNonlinearEquations
{
    public class ChordMethodCalculator
    {
        public MathFunction Function { get; set; }

        public ChordMethodCalculator(MathFunction _function)
        {
            if (_function == null) throw new ArgumentNullException(nameof(_function));
            Function = _function;
        }

        public float Solve(float left_border, float right_border, float epsilon = 0.001f)
        {
            float x, previousX;
            float a = Function.CalculateSecondDerivative(right_border);
            float b = Function.Calculate(right_border);

            if (Function.CalculateSecondDerivative(right_border) * Function.Calculate(right_border) >= 0)
                x = left_border;
            else
                x = right_border;

            previousX = x + epsilon * 2;

            while (Math.Abs(x - previousX) > epsilon)
            {
                previousX = x - epsilon;
                if (Function.CalculateSecondDerivative(right_border) * Function.Calculate(right_border) >= 0)
                    x -= (right_border - previousX) * Function.Calculate(previousX) /
                        (Function.Calculate(right_border) - Function.Calculate(previousX));
                else
                    x -= (previousX - left_border) * Function.Calculate(previousX) /
                         (Function.Calculate(previousX) - Function.Calculate(left_border));

                previousX += epsilon;
            }

            return previousX;
        }
    }
}
