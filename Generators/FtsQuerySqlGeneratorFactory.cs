using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.Sql;
using Microsoft.EntityFrameworkCore.Query.Sql.Internal;

namespace StudyEfCore.Generators
{
    public class FtsQuerySqlGeneratorFactory : QuerySqlGeneratorFactoryBase
    {
        private readonly ISqlServerOptions _sqlServerOptions;

        public FtsQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies,
            ISqlServerOptions sqlServerOptions) : base(dependencies) 
            => _sqlServerOptions = sqlServerOptions;

        public override IQuerySqlGenerator CreateDefault(SelectExpression selectExpression)
            => new FtsQuerySqlGenerator(Dependencies, selectExpression, _sqlServerOptions.RowNumberPagingEnabled);
    }
}
