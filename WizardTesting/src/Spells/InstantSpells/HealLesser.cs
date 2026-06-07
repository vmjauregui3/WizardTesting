using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class HealLesser : InstantSpell
    {
        public HealLesser(Creature owner) : base(owner, 100, 1000, 1000)
        {
            spellValuePrimary = new Stat(50f);
            targetDestructible = owner;
            castEffect = HealTargetDestructible;
            SpellCastEffectType = SpellCastEffectType.Heal;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString()
            };
        }

        public HealLesser(Creature owner, int level, int exp) : base(owner, 100, 1000, 1000, level, exp)
        {
            spellValuePrimary = new Stat(50f);
            targetDestructible = owner;
            castEffect = HealTargetDestructible;
            SpellCastEffectType = SpellCastEffectType.Heal;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString()
            };
        }
    }
}
