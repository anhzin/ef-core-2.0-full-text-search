using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace StudyEfCore.Expressions
{
    public class FtsExpression : SqlFunctionExpression
    {
        public FtsExpression(string method, IEnumerable<Expression> arguments) : base(method, typeof(bool), arguments) { }
    }
}
