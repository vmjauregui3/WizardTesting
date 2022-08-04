using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class User : Player
    {
        // User Player represents the user's authority and defines their ability to interact with the game.

        // Constructor defines the user's Player id to create their Wizard.
        public User(int id) : base(id)
        {
            // The Wizard is the user's representation in the game world.
            Wizard = new Wizard(new Vector2(100, 300), id);

            Buildings.Add(new Tower(new Vector2(0, 0), id));
        }

        // Updates their Player.
        public override void Update(GameTime gameTime, Player enemy, World world)
        {
            base.Update(gameTime, enemy, world);
        }

    }
}
