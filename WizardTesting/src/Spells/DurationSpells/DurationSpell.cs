using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WizardTesting
{
    public class DurationSpell : Spell
    {
        protected bool isActive;

        protected MTimer activeTimer;

        public DurationSpell(Creature owner, int manaCost, int cooldown, int castTime, int duration) : base(owner, manaCost, cooldown, castTime)
        {
            isActive = false;
            activeTimer = new MTimer(duration);
            SpellType = SpellType.Duration;
        }

        public DurationSpell(Creature owner, int manaCost, int cooldown, int castTime, int duration, int level, int exp) : base(owner, manaCost, cooldown, castTime, level, exp)
        {
            isActive = false;
            activeTimer = new MTimer(duration);
            SpellType = SpellType.Duration;
        }

        public DurationSpell(Creature owner, XElement spellData) : base(owner, spellData)
        {
            SpellTypeParameters = spellData.Element("SpellTypeParameters").Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);
            activeTimer = new MTimer(Convert.ToInt32(SpellTypeParameters["duration"]));
            isActive = false;
            SpellType = SpellType.Duration;
        }

        protected override XElement GetSpellTypeParameters()
        {
            XElement spellTypeParams = new XElement("SpellTypeParameters",
                new XElement("duration", activeTimer.MSec)
            );

            return spellTypeParams;
        }

        public override void StartCasting()
        {
            if (!isActive)
            {
                base.StartCasting();
            }
        }

        public override void CastEffect()
        {
            isActive = true;
            base.CastEffect();
        }

        public override void EndEffect()
        {
            isActive = false;
            base.EndEffect();
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                activeTimer.UpdateTimer(gameTime);
                if (activeTimer.Test())
                {
                    activeTimer.ResetToZero();
                    EndEffect();
                }
            }
            base.Update(gameTime);
        }

    }
}
