using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
        public SpeedBoost(Creature owner, int level, int exp, Dictionary<string, string> parameters) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            SpellParameters = parameters;
            foreach (KeyValuePair<string, string> param in SpellParameters)
            {
                if (param.Key == "target")
                {
                    if (param.Value == "owner")
                    {
                        TargetDestructible = owner;
                    }
                }
                else if (param.Key == "statToModify")
                {
                    if (param.Value == "MoveSpeed")
                    {
                        statToModify = TargetDestructible.MoveSpeed;
                    }
                }
                else if (param.Key == "statModifier")
                {
                    statModifier = new Stat(Convert.ToInt32(param.Value));
                }
                else if (param.Key == "statModifierType")
                {
                    statModifierType = (StatModifierType)Enum.Parse(typeof(StatModifierType), param.Value);
                }
            }
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellCastEffectType = SpellCastEffectType.ModifyStat;
        }
    }
}
