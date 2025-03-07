using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Dash : InstantSpell
    {
        private Stat distance;
        private Vector2 direction;
        public Dash(Creature owner) : base(owner, 100, 5000, 10)
        {
            distance = new Stat(150f);
        }

        public Dash(Creature owner, int level, int exp) : base(owner, 100, 5000, 10, level, exp)
        {
            distance = new Stat(150f);
        }

        public override void StartCasting()
        {
            if (!owner.Velocity.Equals(Vector2.Zero))
            {
                direction = Vector2.Normalize(owner.Velocity);
                base.StartCasting();
            }
        }

        public override void CastEffect()
        {
            owner.TranslatePosition(distance.Value * direction);
        }
    }
}
