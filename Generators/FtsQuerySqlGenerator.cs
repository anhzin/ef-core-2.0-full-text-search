using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.Sql;
using Microsoft.EntityFrameworkCore.Query.Sql.Internal;
using StudyEfCore.Expressions;

namespace StudyEfCore.Generators
{
    public class FtsQuerySqlGenerator : SqlServerQuerySqlGenerator
    {
        public FtsQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies, SelectExpression selectExpression, bool rowNumberPagingEnabled)
            : base(dependencies, selectExpression, rowNumberPagingEnabled) { }

        protected override Expression VisitBinary(BinaryExpression binaryExpression)
        {
            var ftsExpression = binaryExpression.Left as FtsExpression ?? binaryExpression.Right as FtsExpression;
            return ftsExpression != null ? base.VisitSqlFunction(ftsExpression) : base.VisitBinary(binaryExpression);
        }
    }
}
