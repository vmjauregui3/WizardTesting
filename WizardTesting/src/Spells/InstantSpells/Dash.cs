using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Dash : InstantSpell
    {
        public Dash(Creature owner) : base(owner, 100, 5000, 10)
        {
            spellValuePrimary = new Stat(150f);
            targetDestructible = owner;
            SpellCastEffectType = SpellCastEffectType.Translate;
            castEffect = TranslateTargetDestructible;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString()
            };
        }

        public Dash(Creature owner, int level, int exp) : base(owner, 100, 5000, 10, level, exp)
        {
            spellValuePrimary = new Stat(150f);
            targetDestructible = owner;
            SpellCastEffectType = SpellCastEffectType.Translate;
            castEffect = TranslateTargetDestructible;
            SpellParameters = new Dictionary<string, string>
            {
                ["target"] = "owner",
                ["spellValuePrimary"] = spellValuePrimary.Value.ToString()
            };
        }
    }
}
