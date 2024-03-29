﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class SimpleIterationMethod
    {
        public float[] Solve(Matrix matrix, float epsilon, bool calculateNorm)
        {
            if (calculateNorm && matrix.GetMatrixNorm() > 1)
                throw new ApplicationException("Matrix norm greater than one!");

            bool recalculateSolutions = true;
            float[] solution = new float[matrix.Cols - 1];
            float[] buffer = new float[matrix.Cols - 1];
            float epsilon2 = GetEpsilon2(matrix, epsilon);

            while (recalculateSolutions)
            {
                int i;
                for (i = 0; i < matrix.Rows; i++)
                {
                    CalculateNewSolution(matrix, solution, buffer, i);
                    recalculateSolutions = (Math.Abs(solution[i] - buffer[i]) < epsilon2) ? false : true;
                }

                for (int j = 0; j < matrix.Cols - 1; j++)
                    solution[j] = buffer[j];
            }

            return solution;
        }

        private void CalculateNewSolution(Matrix matrix, float[] solution, float[] buffer, int i)
        {
            float sum = 0;

            for (int j = 0; j < matrix.Cols - 1; j++)
                sum += matrix[i, j] * solution[j];
            sum += matrix[i, matrix.Cols - 1];

            buffer[i] = sum;
        }

        private float GetEpsilon2(Matrix _sourceMatrix, float epsilon)
        {
            float sourceMatrixNorm = _sourceMatrix.GetMatrixNorm();
            Matrix upperTriMatrix = DeepCloneMatrix(_sourceMatrix);

            MakeUpperTriMatrix(upperTriMatrix);
            float upperTriMatrixNorm = upperTriMatrix.GetMatrixNorm();

            return (1 - sourceMatrixNorm) * epsilon / upperTriMatrixNorm;
        }

        private void MakeUpperTriMatrix(Matrix _matrix)
        {
            for (int i = 0; i < _matrix.Rows; i++)
                for (int j = 0; j <= i; j++)
                    _matrix[i, j] = 0;
        }

        private Matrix DeepCloneMatrix(Matrix sourceMatrix)
        {
            float[,] matrix = new float[sourceMatrix.Rows, sourceMatrix.Cols];

            for (int i = 0; i < sourceMatrix.Rows; i++)
                for (int j = 0; j < sourceMatrix.Cols; j++)
                    matrix[i, j] = sourceMatrix[i, j];

            return new Matrix(matrix, sourceMatrix.Rows, sourceMatrix.Cols);
        }
    }
}
