using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using StudyEfCore.Expressions;
using StudyEfCore.Utilities;

namespace StudyEfCore.Translators
{
    public class FtsCompositeTranslator : SqlServerCompositeMethodCallTranslator
    {
        public FtsCompositeTranslator(RelationalCompositeMethodCallTranslatorDependencies dependencies) : base(dependencies) 
            => base.AddTranslators(new[] { new FtsTranslator() });
    }
}
