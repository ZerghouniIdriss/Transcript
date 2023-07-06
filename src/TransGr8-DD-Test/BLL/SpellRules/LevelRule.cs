using TransGr8_DD_Test.Common.RulesEngine;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.Core.SpellRules
{

    public class LevelRule : IRule<Spell>
    {
        public bool IsSatisfied(User user, Spell spell) => user.Level >= spell.Level;
    }
}
