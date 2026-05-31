using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class SpeedBoost : UpkeepSpell
    {

        public SpeedBoost(Creature owner) : base(owner, 200, 5000, 100, 50)
        {
            statModifier = new Stat(2f);
            statToModify = owner.MoveSpeed;
            statModifierType = StatModifierType.PercentMultiply;
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellCastEffectType = SpellCastEffectType.ModifyStat;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statToModify"] = "MoveSpeed",
                ["statModifier"] = statModifier.Value.ToString(),
            };
        }

        public SpeedBoost(Creature owner, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            statModifier = new Stat(2f);
            statToModify = owner.MoveSpeed;
            statModifierType = StatModifierType.PercentMultiply;
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellCastEffectType = SpellCastEffectType.ModifyStat;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statToModify"] = "MoveSpeed",
                ["statModifier"] = statModifier.Value.ToString(),
                ["statModifierType"] = statModifierType.ToString()
            };
        }
    }
}
