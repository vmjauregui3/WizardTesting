using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public abstract class Spell
    {
        protected String name;
        public String Name
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

        protected int manaCost;
        public int ManaCost
        {
            get { return manaCost; }
        }

        protected int damage;
        public int Damage
        {
            get { return damage; }
        }

        protected bool isActive;
        public bool IsActive
        {
            get { return isActive;  }
        }

        protected Creature owner;

        protected MTimer cooldownTimer;
        public int CooldownTimer
        {
            get { return cooldownTimer.MSec; }
        }
        protected MTimer castingTimer;
        public int CastingTimer
        {
            get { return castingTimer.MSec; }
        }

        public Spell(Creature owner, int manaCost, int cooldown, int castTime)
        {
            this.owner = owner;
            this.manaCost = manaCost;
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
            level = 1;
            isActive = false;
            damage = 0;
            exp = 0;
        }

        public Spell(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp)
        {
            this.owner = owner;
            this.manaCost = manaCost;
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
            this.level = level;
            this.exp = exp;
            damage = 0;
            isActive = false;
        }

        public virtual void CastSpell()
        {
            owner.UpdateMana(manaCost);
        }

        public virtual void CastSpell(Vector2 target)
        {
            owner.UpdateMana(manaCost);
        }

        public virtual void Update(GameTime gameTime)
        {
            cooldownTimer.UpdateTimer(gameTime);
            castingTimer.UpdateTimer(gameTime);
            if (cooldownTimer.Test())
            {
                cooldownTimer.ResetToZero();
            }

            if (castingTimer.Test())
            {
                castingTimer.ResetToZero();
            }
        }
    }
}

