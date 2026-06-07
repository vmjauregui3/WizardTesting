using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WizardTesting
{
    public abstract class UpkeepSpell : Spell
    {
        protected Stat upkeepCost;
        public int UpkeepCost
        {
            get { return (int)Math.Round(upkeepCost.Value, 4); }
        }

        protected bool needsUpkeep;
        public bool NeedsUpkeep
        {
            get { return needsUpkeep; }
        }
        protected MTimer upkeepTimer = new MTimer(1000);
        public UpkeepSpell(Creature owner, int manaCost, int cooldown, int castTime, int upkeepCost) : base(owner, manaCost, cooldown, castTime)
        {
            this.upkeepCost = new Stat(upkeepCost);
            needsUpkeep = false;
            SpellType = SpellType.Upkeep;
        }

        public UpkeepSpell(Creature owner, int manaCost, int cooldown, int castTime, int upkeepCost, int level, int exp) : base(owner, manaCost, cooldown, castTime, level, exp)
        {
            this.upkeepCost = new Stat(upkeepCost);
            needsUpkeep = false;
            SpellType = SpellType.Upkeep;
        }

        public UpkeepSpell(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp) : base(owner, manaCost, cooldown, castTime, level, exp)
        {
            needsUpkeep = false;
            SpellType = SpellType.Upkeep;
        }

        public UpkeepSpell(Creature owner, XElement spellData) : base(owner, spellData)
        {
            SpellTypeParameters = spellData.Element("SpellTypeParameters").Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);
            upkeepCost = new Stat(Convert.ToInt32(SpellTypeParameters["upkeepCost"]));
            upkeepTimer = new MTimer(Convert.ToInt32(SpellTypeParameters["upkeepTimer"]));
            needsUpkeep = false;
            SpellType = SpellType.Upkeep;
        }

        protected override XElement GetSpellTypeParameters()
        {
            XElement spellTypeParams = new XElement("SpellTypeParameters",
                new XElement("upkeepCost", upkeepCost.Value),
                new XElement("upkeepTimer", upkeepTimer.MSec)
            );

            return spellTypeParams;
        }

        public override void StartCasting()
        {
            if (!needsUpkeep)
            {
                base.StartCasting();
            }
            else
            {
                EndEffect();
                upkeepTimer.ResetToZero();
            }
        }

        public override void CastEffect()
        {
            needsUpkeep = true;
            base.CastEffect();
        }

        public override void EndEffect()
        {
            needsUpkeep = false;
            base.EndEffect();
        }

        public override void Update(GameTime gameTime)
        {
            if (needsUpkeep)
            {
                upkeepTimer.UpdateTimer(gameTime);
                if (upkeepTimer.Test())
                {
                    if (owner.HasMana(UpkeepCost))
                    {
                        owner.AddMana(-UpkeepCost);
                        UpkeepEffect();
                    }
                    else
                    {
                        EndEffect();
                    }
                    upkeepTimer.ResetToZero();
                }
            }
            base.Update(gameTime);
        }

    }
}
