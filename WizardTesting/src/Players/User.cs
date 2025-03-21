﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class User : Player
    {
        // User Player represents the user's authority and defines their ability to interact with the game.
        public List<Spell> Spells = new List<Spell>();

        // Contains the UI overlay for the user to better understand game variables.
        public UI UI;

        // Constructor defines the user's Player id to create their Wizard.
        public User(int id, XElement data) : base(id, data)
        {
            // Creates the UI Overlay.
            UI = new UI();

            // The Wizard is the user's representation in the game world.

            //Wizard = new Wizard(new Vector2(100, 300), id);
            //Buildings.Add(new Tower(new Vector2(0, 0), id));

            if (data.Element("Wizard") != null)
            {
                XElement wizard = data.Element("Wizard");
                Wizard = new Wizard(
                    this,
                    new Vector2(Convert.ToInt32(wizard.Element("Position").Element("x").Value, WizardTesting.Culture), Convert.ToInt32(data.Element("Wizard").Element("Position").Element("y").Value, WizardTesting.Culture)),
                    Convert.ToSingle(wizard.Element("Scale").Value, WizardTesting.Culture),
                    Convert.ToSingle(wizard.Element("MoveSpeed").Value, WizardTesting.Culture),
                    Convert.ToInt32(wizard.Element("level").Value, WizardTesting.Culture),
                    Convert.ToInt32(wizard.Element("healthMax").Value, WizardTesting.Culture),
                    Convert.ToInt32(wizard.Element("manaMax").Value, WizardTesting.Culture),
                    Convert.ToInt32(wizard.Element("manaRegenMax").Value, WizardTesting.Culture)
                    );

                Wizard.LoadSpells(wizard.Element("Spells"));
            }
        }

        // Updates their Player.
        public override void Update(GameTime gameTime, World world)
        {
            base.Update(gameTime, world);
            UI.Update(this, world);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            UI.Draw(spriteBatch);
        }

    }
}
