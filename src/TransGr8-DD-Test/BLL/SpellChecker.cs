using System.Collections.Generic;
using System.Linq;
using TransGr8_DD_Test.Common.RulesEngine;
using TransGr8_DD_Test.Core.SpellRules;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.BLL
{
    public interface ISpellChecker
    {
        bool CanUserCastSpell(User user, string spellName);
    }

    public class SpellChecker : RuleChecker<Spell>, ISpellChecker
    {
        private readonly List<Spell> _spellList;

        public SpellChecker(List<Spell> spells)
            : base(new List<IRule<Spell>>
            {
                new LevelRule(),
                new ComponentRule(),
                new RangeRule(),
                new ConcentrationRule()
            }
            )
        {
            _spellList = spells;
        }

        public bool CanUserCastSpell(User user, string spellName)
        {
            Spell spellToCast = _spellList.FirstOrDefault(s => s.Name.Equals(spellName, StringComparison.OrdinalIgnoreCase));

            if (spellToCast == null) return false;

            return CanExecute(user, spellToCast);
        }
    }
}
