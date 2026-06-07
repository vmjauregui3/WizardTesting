using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Regeneration : UpkeepSpell
    {
        public Regeneration(Creature owner) : base(owner, 200, 5000, 1000, 50)
        {
            spellValuePrimary = new Stat(50);
            TargetDestructible = owner;
            castEffect = HealTargetDestructible;
            upkeepEffect = HealTargetDestructible;
            SpellCastEffectType = SpellCastEffectType.Heal;
        }

        public Regeneration(Creature owner, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            spellValuePrimary = new Stat(50);
            TargetDestructible = owner;
            castEffect = HealTargetDestructible;
            upkeepEffect = HealTargetDestructible;
            SpellCastEffectType = SpellCastEffectType.Heal;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString()
            };
        }
    }
}
