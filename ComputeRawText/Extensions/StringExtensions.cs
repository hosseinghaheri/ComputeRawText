using NCalc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputeRawText.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Simple Compute using Datatable Compute
        /// </summary>
        /// <param name="expression">2+2</param>
        /// <returns></returns>
        public static string SimpleCompute(this string expression)
        {
            try
            {
                return Convert.ToDouble(new DataTable().Compute(expression, String.Empty)).ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// Ultra Compute using Ncalc
        /// </summary>
        /// <param name="expression">Raw math text</param>
        /// <param name="parameters">Object of parameters</param>
        /// <returns></returns>
        public static string Compute(this string expression, object parameters = null)
        {
            try
            {
                Expression expr = new Expression(expression);
                if (parameters != null)
                {
                    Type objectType = parameters.GetType();
                    PropertyInfo[] properties = objectType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        string propertyName = property.Name;
                        object propertyValue = property.GetValue(parameters, null);
                        expr.Parameters[propertyName] = propertyValue;
                    }
                }
                object result = expr.Evaluate();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
