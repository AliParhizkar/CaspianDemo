using System.Linq.Expressions;

namespace Caspian.UI
{
    public interface IAutoCompleteValueInitializer
    {
        void SetValue(long id);

        void SetSearchStringValue(string str);
    }
}
