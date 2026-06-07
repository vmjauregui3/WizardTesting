using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class BuffSpeed : DurationSpell
    {
        public BuffSpeed(Creature owner) : base(owner, 100, 1000, 50, 1000)
        {
            spellValuePrimary = new Stat(2f);
            statToModify = owner.MoveSpeed;
            statModifierType = StatModifierType.PercentMultiply;
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellCastEffectType = SpellCastEffectType.ModifyStat;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statToModify"] = "MoveSpeed",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString(),
                ["statModifierType"] = statModifierType.ToString()
            };
        }

        public BuffSpeed(Creature owner, int level, int exp) : base(owner, 100, 1000, 50, 1000, level, exp)
        {
            spellValuePrimary = new Stat(2f);
            statToModify = owner.MoveSpeed;
            statModifierType = StatModifierType.PercentMultiply;
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellCastEffectType = SpellCastEffectType.ModifyStat;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statToModify"] = "MoveSpeed",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString(),
                ["statModifierType"] = statModifierType.ToString()
            };
        }
    }
}
