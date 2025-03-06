﻿using Microsoft.Xna.Framework;
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

        protected Stat manaCost;
        public int ManaCost
        {
            get { return (int)Math.Round(manaCost.Value, 4); }
        }

        protected Stat upkeepCost;
        public int UpkeepCost
        {
            get { return (int)Math.Round(upkeepCost.Value, 4); }
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
        public int CooldownTimer
        {
            get { return cooldownTimer.MSec; }
        }

        protected bool isCasting;
        public bool IsCasting
        {
            get { return isCasting; }
        }
        protected MTimer castingTimer;
        public int CastingTimer
        {
            get { return castingTimer.MSec; }
        }

        protected bool isActive;
        public bool IsActive
        {
            get { return isActive; }
        }
        protected MTimer upkeepTimer = new MTimer(1000);

        public Spell(Creature owner, int manaCost, int cooldown, int castTime)
        {
            this.owner = owner;
            this.manaCost = new Stat(manaCost);
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
            level = 1;
            onCooldown = false;
            isCasting = false;
            isActive = false;
            exp = 0;
        }

        public Spell(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp)
        {
            this.owner = owner;
            this.manaCost = new Stat(manaCost);
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
            this.level = level;
            this.exp = exp;
            onCooldown = false;
            isCasting = false;
            isActive = false;
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

        public virtual void CastEffect()
        {

        }

        public virtual void QuickCast(Vector2 target)
        {
            StartCasting();
        }

        public virtual void UpkeepEffect()
        {
            
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

            if (isActive)
            {
                upkeepTimer.UpdateTimer(gameTime);
                if (upkeepTimer.Test())
                {
                    if(owner.HasMana(UpkeepCost))
                    {
                        owner.AddMana(-UpkeepCost);
                        UpkeepEffect();
                    }
                    else
                    {
                        isActive = false;
                    }
                    upkeepTimer.ResetToZero();
                }
            }
        }

        public void GainExp(int exp)
        {
            this.exp += exp;
        }
    }
}

