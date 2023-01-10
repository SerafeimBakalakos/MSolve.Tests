﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGroup.FEM.ConvectionDiffusion.Tests.Commons
{
    public static class ResultChecker
    {
        public static bool CheckResults(double[] numericalSolution, double[] prescribedSolution, double tolerance)
        {
            if (numericalSolution.Length != prescribedSolution.Length)
            {
                Debug.WriteLine("Array Lengths do not match");
                return false;
            }

            var isAMatch = true;
            for (int i = 0; i < numericalSolution.Length; i++)
            {
                var error = Math.Abs((prescribedSolution[i] - numericalSolution[i]) / prescribedSolution[i]);
                Debug.WriteLine("Numerical: {0} \tPrescribed: {1} \tError: {2}", numericalSolution[i], prescribedSolution[i], error.ToString("E10"));
                if (error > tolerance)
                {
                    isAMatch = false;
                }
            }
            if (isAMatch == true)
            {
                Debug.WriteLine("MSolve Solution matches prescribed solution");
                Debug.WriteLine("Test Passed!");
            }
            else
            {
                Debug.WriteLine("MSolve Solution does not match prescribed solution");
                Debug.WriteLine("Test Failed!");
            }
            return isAMatch;
        }
    }
}
