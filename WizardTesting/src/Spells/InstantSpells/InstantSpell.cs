using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace WizardTesting
{
    public class InstantSpell : Spell
    {
        public InstantSpell(Creature owner, int manaCost, int cooldown, int castTime) : base(owner, manaCost, cooldown, castTime)
        {
            SpellType = SpellType.Instant;
        }

        public InstantSpell(Creature owner, int manaCost, int cooldown, int castTime, int level, int exp) : base(owner, manaCost, cooldown, castTime, level, exp)
        {
            SpellType = SpellType.Instant;
        }

        public InstantSpell(Creature owner, XElement spellData) : base(owner, spellData)
        {
            SpellTypeParameters = spellData.Element("SpellTypeParameters").Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);
            SpellType = SpellType.Instant;
        }
    }
}
