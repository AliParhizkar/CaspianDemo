using Caspian.Common;
using System.Linq.Expressions;

namespace Caspian.UI
{
    public class GridHeaderData
    {
        public int? Width { get; set; }

        public string Title { get; set; }

        public LambdaExpression FromExpression { get; set; }

        public LambdaExpression ToExpression { get; set; }

        public MemberExpression Expression { get; set; }

        public OrderBy? OrderBy { get; set; }
    }
}
