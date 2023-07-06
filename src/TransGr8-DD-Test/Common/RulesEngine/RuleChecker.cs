using System.Collections.Generic;
using System.Linq;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.Common.RulesEngine
{

    public interface IRuleChecker<T>
    {
        bool CanExecute(User user, T concept);
    }

    public abstract class RuleChecker<T> : IRuleChecker<T>
    {
        protected readonly IEnumerable<IRule<T>> _rules;

        protected RuleChecker(IEnumerable<IRule<T>> rules)
        {
            _rules = rules;
        }

        public virtual bool CanExecute(User user, T concept) => _rules.All(rule => rule.IsSatisfied(user, concept));
    }
}
