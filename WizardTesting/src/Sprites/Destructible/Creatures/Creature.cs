using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public abstract class Creature : Destructible
    {
        public Creature(int ownderId) : base(ownderId)
        {
            MoveSpeed = 100.0f;
        }
    }
}
