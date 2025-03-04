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

        protected int manaCostBase;

        protected int manaCost;
        public int ManaCost
        {
            get { return manaCost; }
        }

        protected int upkeepCost;
        public int UpkeepCost
        {
            get { return upkeepCost; }
        }

        protected int upkeepCostBase;

        // Not sure all spells have damage
        protected int damage;
        public int Damage
        {
            get { return damage; }
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

        public Spell(Creature owner, int manaCost, int cooldown, int castTime)
        {
            this.owner = owner;
            this.manaCost = manaCost;
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
            level = 1;
            onCooldown = false;
            isCasting = false;
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
            onCooldown = false;
            isCasting = false;
            isActive = false;
        }

        public virtual void StartCasting()
        {
            if (!IsCasting)
            {
                isCasting = true;
                owner.UpdateMana(manaCost);
                owner.StartCasting();
                onCooldown = true;
            }
        }

        public virtual void QuickCast(Vector2 target)
        {
            StartCasting();
        }

        public virtual void CastEffect()
        {

        }

        public virtual void UpkeepSpell()
        {
            owner.UpdateMana(upkeepCost);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (IsCasting)
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
    }
}

