using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace WizardTesting
{
    public abstract class Impermanent : Destructible
    {
        // Variable that determines when the Impermanent gets destroyed.
        protected bool done;
        public bool Done
        {
            get { return done; }
        }

        protected Spell spell;
        public Spell Spell
        {
            get { return spell; }
        }

        // Timer tracks how long the Impermanent can exist before being destroyed.
        public MTimer Timer;

        public Impermanent(string path, Vector2 position, float scale, Vector2 frameCount, int switchFrame, Spell ownerSpell, int duration) : base(ownerSpell.Owner.OwnerId)
        {
            Sprite = new AnimatedSprite(path, new Vector2(position.X, position.Y), scale, frameCount, switchFrame);
            Sprite.IsActive = true;
            MoveSpeed = new Stat(100f);

            done = false;
            spell = ownerSpell;

            Timer = new MTimer(duration);
        }
        public void SetIsDone()
        {
            done = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Timer.UpdateTimer(gameTime);
            if (Timer.Test())
            {
                done = true;
            }
        }

    }
}
