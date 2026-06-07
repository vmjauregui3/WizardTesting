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
        public SpeedBoost(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp, Dictionary<string, string> spellTypeParameters, Dictionary<string, string> spellParameters) : base(owner, manaCost, cooldown, castTime, level, exp)
        {
            SpellTypeParameters = spellTypeParameters;
            upkeepCost = new Stat(Convert.ToInt32(SpellTypeParameters["upkeepCost"]));
            upkeepTimer = new MTimer(Convert.ToInt32(SpellTypeParameters["upkeepTimer"]));
            SpellParameters = spellParameters;
            if (spellParameters.ContainsKey("target"))
            {
                if (spellParameters["target"] == "owner")
                {
                    TargetDestructible = owner;
                }
            }
            if (spellParameters.ContainsKey("statToModify"))
            {
                if (spellParameters["statToModify"] == "MoveSpeed")
                {
                    statToModify = TargetDestructible.MoveSpeed;
                }
            }
            if (spellParameters.ContainsKey("statModifier"))
            {
                statModifier = new Stat(Convert.ToInt32(spellParameters["statModifier"]));
            }
            if (spellParameters.ContainsKey("statModifierType"))
            {
                statModifierType = (StatModifierType)Enum.Parse(typeof(StatModifierType), spellParameters["statModifierType"]);
            }
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellCastEffectType = SpellCastEffectType.ModifyStat;
        }
    }
}
