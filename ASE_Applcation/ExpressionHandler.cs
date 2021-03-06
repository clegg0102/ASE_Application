using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Applcation
{
    /// <summary>
    /// This is a class that handles things like parsing numbers and variables
    /// </summary>
    internal class ExpressionHandler
    {
        Context context;
        public ExpressionHandler(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Replaces variable identifiers with values
        /// </summary>
        /// <param name="equation">equation to have variables replaced on</param>
        /// <returns>the equation with the variable identifiers replaced with values</returns>
        protected string ReplaceVariables(string equation)
        {
            // this has to be done in the right order for scoped variables to work correctly
            // luckily stacks work in reverse order by default which is what we need
            // the last scope added should be the one that takes precedence and this works with the LIFO nature of a stack
            foreach (Scope scope in context.scopes)
            {
                // this goes through each variable in the scope and tries to replace any identifiers with it in the equation
                foreach (KeyValuePair<string, int> variable in scope.variables)
                {
                    if (equation.Contains(variable.Key))
                    {
                        equation = equation.Replace(variable.Key, variable.Value.ToString());
                    }
                }
            }
            return equation;
        }

        /// <summary>
        /// A function which evaluates an equation including replacing variables with values
        /// </summary>
        /// <param name="equation">the equation</param>
        /// <returns>the value the equation evaluates to</returns>
        public int Evaluate(string equation)
        {
            DataTable dt = new DataTable();
            // use the function defined earlier to replace the variable identifiers with values
            equation = ReplaceVariables(equation);
            // perform the computation using the DataTable class Compute method
            return Convert.ToInt32(dt.Compute(equation, ""));
        }

        /// <summary>
        /// method that evaluates a boolean condition like those used in while loops and if statements
        /// </summary>
        /// <param name="condition">equation to evaluate</param>
        /// <returns>the result of the condition</returns>
        /// <exception cref="Exception">is thrown if equation does not contains a boolean operation</exception>
        public bool EvaluateCondition(string condition)
        {
            DataTable dt = new DataTable();
            bool containsOperation = false;
            // checks to make sure the string to evaluate actually contains a boolean operator
            foreach (string operation in new string[] { "<", ">", "=", "!=", "<=", ">=" })
            {
                //
                if (condition.Contains(operation))
                {
                    containsOperation = true;
                    break;
                }
            }
            if (containsOperation)
            {
                condition = ReplaceVariables(condition);
                bool result = (bool)dt.Compute(condition, "");
                return result;
            }
            else
            {
                throw new Exception("Operation string does not contain a boolean operation.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">literal or identifier to parse</param>
        /// <returns>the value of the literal or identifier</returns>
        /// <exception cref="Exception">thrown if it's an identifier that cannot be found</exception>
        public int EvaluateValue(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            foreach (Scope scope in context.scopes)
            {
                if (scope.variables.ContainsKey(value))
                {
                    return scope.variables[value];
                }
            }
            throw new Exception("Could not find variable " + value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">the text to be evaluated</param>
        /// <param name="result">the result if evaluation was successful</param>
        /// <returns>returns true if the value could be evaluated and false if not</returns>
        public bool TryEvalValue(string input, out int result)
        {
            try
            {
                result = EvaluateValue(input);
                return true;
            }
            catch (Exception ex)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Method to evaluate a raw value or a variable identifier into a byte
        /// similar to the normal EvaluateValue method but checks size and converts into a byte
        /// </summary>
        /// <param name="toEval">text to evaluate into a byte</param>
        /// <returns>result of the evaluation</returns>
        /// <exception cref="Exception">thrown if the variable contains a value that cannot fit in a byte</exception>
        public byte EvaluateByte(string toEval)
        {
            if (byte.TryParse(toEval, out byte result))
            {
                return result;
            }
            foreach (Scope scope in context.scopes)
            {
                var variables = scope.variables;
                if (variables.ContainsKey(toEval))
                {
                    int value = variables[toEval];
                    if (byte.MinValue <= value && value <= byte.MaxValue)
                    {
                        return (byte)value;
                    }
                    else
                    {
                        throw new Exception("Variable value out of range.");
                    }
                }
            }
            throw new Exception("Invalid expression: " + toEval);
        }
        public bool TryByte(string toEval, out byte result)
        {
            try
            {
                result = EvaluateByte(toEval);
                return true;
            }
            catch (Exception e)
            {
                result = 0;
                return false;
            }
        }
        /// <summary>
        /// Method to add or update a variable to the context
        /// </summary>
        /// <param name="name">name of the variable</param>
        /// <param name="value">value of the variable</param>
        public void AddUpdateVariable(string name, int value)
        {
            // checks if the variable already exists in one of the scopes
            foreach (Scope scope in context.scopes)
            {
                // if it does we update it accordingly
                if (scope.HasVariable(name))
                {
                    scope.AddUpdateVariable(name, value);
                    return;
                }
            }
            // adds a new varaiable to the current scope if it dosen't already exist
            context.lastScope.AddUpdateVariable(name, value);
        }
    }
}

