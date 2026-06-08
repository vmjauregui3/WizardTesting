using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace WizardTesting
{
    public class SpeedBoost : UpkeepSpell
    {

        public SpeedBoost(Creature owner) : base(owner, 200, 5000, 100, 50)
        {
            spellValuePrimary = new Stat(2f);
            statToModify = owner.MoveSpeed;
            statModifierType = StatModifierType.PercentMultiply;
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statToModify"] = "MoveSpeed",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString(),
                ["statModifierType"] = statModifierType.ToString()
            };
        }

        public SpeedBoost(Creature owner, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            spellValuePrimary = new Stat(2f);
            statToModify = owner.MoveSpeed;
            statModifierType = StatModifierType.PercentMultiply;
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["statToModify"] = "MoveSpeed",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString(),
                ["statModifierType"] = statModifierType.ToString()
            };
        }
        public SpeedBoost(Creature owner, XElement spellData) : base(owner, spellData)
        {
            /*
            SpellParameters = spellData.Element("SpellParameters").Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);
            if (SpellParameters.ContainsKey("target"))
            {
                if (SpellParameters["target"] == "owner")
                {
                    TargetDestructible = owner;
                }
            }
            if (SpellParameters.ContainsKey("statToModify"))
            {
                if (SpellParameters["statToModify"] == "MoveSpeed")
                {
                    statToModify = TargetDestructible.MoveSpeed;
                }
            }
            if (SpellParameters.ContainsKey("statModifier"))
            {
                statModifier = new Stat(Convert.ToInt32(SpellParameters["statModifier"]));
            }
            if (SpellParameters.ContainsKey("statModifierType"))
            {
                statModifierType = (StatModifierType)Enum.Parse(typeof(StatModifierType), SpellParameters["statModifierType"]);
            }
            castEffect = AddStatModifier;
            endEffect = RemoveStatModifier;
            SpellCastEffectType = SpellCastEffectType.ModifyStat;
            */
        }
    }
}
