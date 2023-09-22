﻿using System;
using System.Collections.Generic;
using Adletec.Sonic.Execution;

namespace Adletec.Sonic
{
    /// <summary>
    /// The CalculationEngine is the main component of sonic. It parses strings containing
    /// mathematical formulas and to calculates the result.
    /// 
    /// It can be configured to run in a number of modes based on the constructor parameters chosen.
    /// </summary>
    public interface IEvaluator
    {
        /// <summary>
        /// All functions registered with the engine.
        /// </summary>
        IEnumerable<FunctionInfo> Functions { get; }
        
        /// <summary>
        /// All constants registered with the engine.
        /// </summary>
        IEnumerable<ConstantInfo> Constants { get; }
        
        /// <summary>
        /// Evaluate the provided expression. The expression may only contain constants and known functions.
        /// </summary>
        /// <param name="expression">an expression string, e.g. "22+3*(4.2-2)</param>
        /// <returns>the result of the evaluation as double</returns>
        double Evaluate(string expression);
        
        /// <summary>
        /// Evaluate the provided expression. All referenced variables must be provided as a dictionary.
        /// </summary>
        /// <param name="expression">an expression string, e.g. "a+b*(2.4+c)</param>
        /// <param name="variables">a dictionary containing the values of all variables referenced in the expression</param>
        /// <returns>the result of the evaluation as double</returns>
        double Evaluate(string expression, IDictionary<string, double> variables);
        
        /// <summary>
        /// Creates a <see cref="Func{T, Double}"/> delegate for the string expression, which takes the variable dictionary as input.
        /// </summary>
        /// <param name="expression">The expression string for which a delegate should be created.</param>
        /// <returns>A delegate which takes an <see cref="IDictionary{TKey,TValue}"/> with variable values and evaluates the expression using those values.</returns>
        Func<IDictionary<string, double>, double> CreateDelegate(string expression);

    }
}