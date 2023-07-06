

using TransGr8_DD_Test.Common.RulesEngine;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.Core.SpellRules
{
    public class ComponentRule : IRule<Spell>
    {
        public bool IsSatisfied(User user, Spell spell)
        {
            return IsComponentSatisfied(spell.Components.Contains("V"), user.HasVerbalComponent)
                && IsComponentSatisfied(spell.Components.Contains("S"), user.HasSomaticComponent)
                && IsComponentSatisfied(spell.Components.Contains("M"), user.HasMaterialComponent);
        }

        private bool IsComponentSatisfied(bool spellRequiresComponent, bool userHasComponent)
        {
            return !spellRequiresComponent || userHasComponent;
        }
    }

}
