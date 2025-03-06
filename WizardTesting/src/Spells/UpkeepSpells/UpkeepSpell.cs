using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class UpkeepSpell : Spell
    {
        protected bool needsUpkeep;
        public bool NeedsUpkeep
        {
            get { return needsUpkeep; }
        }
        protected MTimer upkeepTimer = new MTimer(1000);
        public UpkeepSpell(Creature owner, int manaCost, int cooldown, int castTime) : base(owner, manaCost, cooldown, castTime)
        {
            needsUpkeep = false;
        }

        public UpkeepSpell(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp) : base(owner, manaCost, cooldown, castTime, level, exp)
        {
            needsUpkeep = false;
        }

        public override void EndEffect()
        {
            needsUpkeep = false;
            base.EndEffect();
        }

        public void Upkeep(GameTime gameTime)
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
