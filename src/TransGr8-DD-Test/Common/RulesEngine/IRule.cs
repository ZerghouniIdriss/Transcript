using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.Common.RulesEngine
{
    public interface IRule<T>
    {
        bool IsSatisfied(User user, T concept);
    }
}
