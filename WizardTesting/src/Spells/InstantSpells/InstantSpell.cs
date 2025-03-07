using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class InstantSpell : Spell
    {
        public InstantSpell(Creature owner, int manaCost, int cooldown, int castTime) : base(owner, manaCost, cooldown, castTime)
        {

        }

        public InstantSpell(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp) : base(owner, manaCost, cooldown, castTime, level, exp)
        {

        }
    }
}
