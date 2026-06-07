using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WizardTesting
{
    public abstract class Spell
    {
        protected string name;
        public string Name
        {
            get { return name; }
        }

        protected int level;
        public int Level
        {
            get { return level; }
        }
        protected int exp;
        public int Exp
        {
            get { return exp;  }
        }

        protected Stat manaCost;
        public int ManaCost
        {
            get { return (int)Math.Round(manaCost.Value, 4); }
        }

        protected Creature owner;
        public Creature Owner
        {
            get { return owner; }
        }

        protected bool onCooldown;
        public bool OnCooldown
        {
            get { return onCooldown; }
        }
        protected MTimer cooldownTimer;

        protected bool isCasting;
        public bool IsCasting
        {
            get { return isCasting; }
        }
        protected MTimer castingTimer;

        public SpellType SpellType;
        public SpellCastEffectType SpellCastEffectType;

        protected Action castEffect;
        protected Action upkeepEffect;
        protected Action endEffect;

        public Dictionary<string, string> SpellTypeParameters;
        public Dictionary<string, string> SpellParameters;

        protected Spell()
        {
            onCooldown = false;
            isCasting = false;
            castEffect = DoNothing;
            upkeepEffect = DoNothing;
            endEffect = DoNothing;
            SpellTypeParameters = new Dictionary<string, string>();
            SpellParameters = new Dictionary<string, string>();
        }

        public Spell(Creature owner, int manaCost, int cooldown, int castTime) : this()
        {
            this.owner = owner;
            this.manaCost = new Stat(manaCost);
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
            level = 1;
            exp = 0;
        }

        public Spell(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp) : this()
        {
            this.owner = owner;
            this.manaCost = new Stat(manaCost);
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
            this.level = level;
            this.exp = exp;
        }

        public Spell(Creature owner, XElement spellData) : this()
        {
            this.owner = owner;
            manaCost = new Stat(Convert.ToInt32(spellData.Element("manaCost").Value));
            cooldownTimer = new MTimer(Convert.ToInt32(spellData.Element("cooldown").Value));
            castingTimer = new MTimer(Convert.ToInt32(spellData.Element("castTime").Value));
            level = Convert.ToInt32(spellData.Element("level").Value);
            exp = Convert.ToInt32(spellData.Element("exp").Value);
        }

        public static void LoadSpellData(Creature owner, XElement spellData)
        {
            List<XElement> spell = (from t in spellData.Elements() select t).ToList<XElement>();
            for (int i = 0; i < spell.Count; i++)
            {
                SpellType spellType = (SpellType)Enum.Parse(typeof(SpellType), spell[i].Element("SpellType").Value);
                SpellCastEffectType spellCastEffectType = (SpellCastEffectType)Enum.Parse(typeof(SpellCastEffectType), spell[i].Element("SpellCastEffectType").Value);
                string WT = "WizardTesting.";
                Type type = Type.GetType(Convert.ToString(WT + spell[i].Name, WizardTesting.Culture));
                if (type.IsSubclassOf(typeof(Spell)))
                {
                    if (spellType == SpellType.Upkeep && spellCastEffectType == SpellCastEffectType.ModifyStat)
                    {
                        Dictionary<string, string> spellTypeParameters = spell[i].Element("SpellTypeParameters").Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);
                        Dictionary<string, string> spellParameters = spell[i].Element("SpellParameters").Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);

                        object[] parameters = { owner,
                            spell[i]
                        };

                        owner.Spells.Add((Spell)Activator.CreateInstance(type, parameters));
                    }
                    else
                    {
                        object[] parameters = { owner,
                        Convert.ToInt32(spell[i].Element("level").Value),
                        Convert.ToInt32(spell[i].Element("exp").Value)
                        };
                        owner.Spells.Add((Spell)Activator.CreateInstance(type, parameters));
                    }
                }
            }

            /*
            //string spellName = spellData.Name.LocalName;
            //Type type = Type.GetType($"WizardTesting.{spellName}");
            Dictionary<string, string> spellParams = new Dictionary<string, string>();
            foreach (XElement param in spellData.Element("SpellParameters").Elements())
            {
                spellParams[param.Name.LocalName] = param.Value;
            }
            return (Spell)Activator.CreateInstance(type, owner, int.Parse(spellData.Element("level").Value), int.Parse(spellData.Element("exp").Value), spellParams);
            */
        }

        public static XElement SaveSpellData(List<Spell> spellList)
        {
            XElement spells = new XElement("Spells");
            for (int i = 0; i < spellList.Count; i++)
            {
                XElement spellTypeParams = spellList[i].GetSpellTypeParameters();
                if (spellList[i].SpellType == SpellType.Instant)
                {

                }
                else if (spellList[i].SpellType == SpellType.Duration)
                {

                }
                else if (spellList[i].SpellType == SpellType.Upkeep)
                {
                    if (spellList[i].SpellCastEffectType == SpellCastEffectType.ModifyStat)
                    {

                    }
                    else
                    {

                    }
                }
                XElement spellParams = new XElement("SpellParameters");
                foreach (KeyValuePair<string, string> param in spellList[i].SpellParameters)
                {
                    spellParams.Add(new XElement(param.Key, param.Value));
                }
                spells.Add(new XElement(spellList[i].GetType().Name,
                        new XElement("level", spellList[i].Level),
                        new XElement("exp", spellList[i].Exp),
                        new XElement("manaCost", spellList[i].manaCost.BaseValue),
                        new XElement("cooldown", spellList[i].cooldownTimer.MSec),
                        new XElement("castTime", spellList[i].castingTimer.MSec),
                        new XElement("SpellType", spellList[i].SpellType),
                        new XElement("SpellCastEffectType", spellList[i].SpellCastEffectType),
                        new XElement("SpellEffect", spellList[i].castEffect.Method.Name),
                        spellTypeParams,
                        spellParams
                    )
                );
            }
            return spells;
        }

        protected virtual XElement GetSpellTypeParameters()
        {
            XElement spellTypeParams = new XElement("SpellTypeParameters");
            return spellTypeParams;
        }

        public virtual void StartCasting()
        {
            if (!isCasting && !onCooldown)
            {
                isCasting = true;
                onCooldown = true;
                owner.AddMana(-ManaCost);
                owner.StartCasting();
            }
        }

        public virtual void StopCasting()
        {
            isCasting = false;
            castingTimer.ResetToZero();
        }

        public virtual void CastEffect()
        {
            castEffect();
        }

        public virtual void UpkeepEffect()
        {
            upkeepEffect();
        }

        public virtual void EndEffect()
        {
            endEffect();
        }

        public void DoNothing()
        {
            // Used for spells that don't have upkeep or end effects, but need to use the Action delegate.
        }

        public virtual void Update(GameTime gameTime)
        {
            if (isCasting)
            {
                castingTimer.UpdateTimer(gameTime);
                if (castingTimer.Test())
                {
                    castingTimer.ResetToZero();
                    isCasting = false;
                    owner.StopCasting();
                    CastEffect();
                }
            }

            if (onCooldown)
            {
                cooldownTimer.UpdateTimer(gameTime);
                if (cooldownTimer.Test())
                {
                    cooldownTimer.ResetToZero();
                    onCooldown = false;
                }
            }
        }

        public void GainExp(int exp)
        {
            this.exp += exp;
        }

        // Below is the growing list of Spell Effects
        protected Destructible TargetDestructible;
        protected Stat statToModify;
        protected Stat statModifier;
        protected StatModifierType statModifierType;

        protected void AddStatModifier()
        {
            statToModify.AddModifier(statModifier.Value, statModifierType);
        }
        protected void RemoveStatModifier()
        {
            statToModify.RemoveModifier(statModifier.Value, statModifierType);
        }
    }
}

