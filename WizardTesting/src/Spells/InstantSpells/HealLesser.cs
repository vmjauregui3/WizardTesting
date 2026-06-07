using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class HealLesser : InstantSpell
    {
        public HealLesser(Creature owner) : base(owner, 100, 1000, 1000)
        {
            statModifier = new Stat(50f);
            TargetDestructible = owner;
            castEffect = HealTargetDestructible;
            SpellCastEffectType = SpellCastEffectType.Heal;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statModifier"] = statModifier.Value.ToString()
            };
        }

        public HealLesser(Creature owner, int level, int exp) : base(owner, 100, 1000, 1000, level, exp)
        {
            statModifier = new Stat(50f);
            TargetDestructible = owner;
            castEffect = HealTargetDestructible;
            SpellCastEffectType = SpellCastEffectType.Heal;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statModifier"] = statModifier.Value.ToString()
            };
        }
    }
}
