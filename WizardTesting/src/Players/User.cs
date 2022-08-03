using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class User : Player
    {

        public User(int id) : base(id)
        {
            Wizard = new Wizard(new Vector2(100, 300), id);
        }

        public override void Update(GameTime gameTime, Player enemy, World world)
        {
            base.Update(gameTime, enemy, world);
        }

    }
}
