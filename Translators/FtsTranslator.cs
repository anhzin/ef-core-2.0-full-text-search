using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using StudyEfCore.Expressions;
using StudyEfCore.Utilities;

namespace StudyEfCore.Translators
{
    public class FtsTranslator : IMethodCallTranslator
    {
        private static readonly MethodInfo ContainsMethodInfo
            = typeof(SqlFunctions).GetMethod(nameof(SqlFunctions.Contains), new[] { typeof(string), typeof(string) });

        private static readonly MethodInfo FreetextMethodInfo
            = typeof(SqlFunctions).GetMethod(nameof(SqlFunctions.Freetext), new[] { typeof(string), typeof(string) });

        public virtual Expression Translate(MethodCallExpression expr)
            => Equals(expr.Method, ContainsMethodInfo)
            ? new FtsExpression("CONTAINS", new[] { expr.Arguments.First(), expr.Arguments.Last() })
            : Equals(expr.Method, FreetextMethodInfo)
                ? new FtsExpression("FREETEXT", new[] { expr.Arguments.First(), expr.Arguments.Last() })
                : null;
    }
}
