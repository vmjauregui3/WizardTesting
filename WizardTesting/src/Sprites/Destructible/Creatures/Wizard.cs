using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System;
using System.Dynamic;

// Mostly works as a Sprite Only
namespace WizardTesting
{
    public class Wizard : Creature
    {
        private Vector2 mousePosition;
        public float Scale;
        private bool isMobile;
        private bool isCasting;
        private MTimer castingTimer;

        public List<Spell> Spells = new List<Spell>();
        private Spell primarySpell;
        //private InstantProjectileSpell lightBeam; Removed for testing

        private int level;
        public int Level
        {
            get { return level; }
        }
        public Wizard(Vector2 position, int ownerId) : base(ownerId)
        {
            Velocity = Vector2.Zero;
            Scale = 1.5f;
            Sprite = new AnimatedSprite("Sprites/BaseWizard", new Vector2(position.X, position.Y), Scale, new Vector2(4,2), 100);
            //hitDistance = 35f;

            MoveSpeed = 200f;

            isMobile = true;
            isCasting = false;
            castingTimer = new MTimer(5000);

            level = 1;
            healthMax = 1000;
            health = healthMax;

            Spells.Add(new FireBolt(this));
            primarySpell = Spells[0];
            Spells.Add(new EarthShard(this));
            Spells.Add(new IceSpike(this));
            Spells.Add(new WindSlash(this));
            // Removed for testing
            //lightBeam = new InstantProjectileSpell(this, 1f, "Sprites/Projectiles/LightBeam", 3f, 10000, 600f, 5f);
        }

        public Wizard(Vector2 position, int ownerId, float scale, float moveSpeed, int level, int healthMax, int manaMax, int manaRegenMax) : base(ownerId)
        {
            Velocity = Vector2.Zero;
            Scale = scale;
            Sprite = new AnimatedSprite("Sprites/BaseWizard", new Vector2(position.X, position.Y), Scale, new Vector2(4, 2), 100);
            MoveSpeed = moveSpeed;

            isMobile = true;
            isCasting = false;
            castingTimer = new MTimer(5000);

            this.level = level;
            this.healthMax = healthMax;
            this.health = healthMax;
            this.manaMax = manaMax;
            this.mana = manaMax;
            this.manaRegenMax = manaRegenMax;
            this.manaRegen = manaRegenMax;
        }

        
        public void LoadSpells(XElement data)
        {
            List<XElement> spell = (from t in data.Elements() select t).ToList<XElement>();
            for (int i = 0; i < spell.Count; i++)
            {
                String WT = "WizardTesting.";
                if (Type.GetType(Convert.ToString(WT + spell[i].Name, WizardTesting.Culture)).IsSubclassOf(typeof(InstantProjectileSpell)))
                {
                    Object[] parameters = { this,
                    Convert.ToInt32(spell[i].Element("level").Value),
                    Convert.ToInt32(spell[i].Element("exp").Value)
                    };

                    Spells.Add((Spell)Activator.CreateInstance(Type.GetType(Convert.ToString(WT + spell[i].Name, WizardTesting.Culture)), parameters));
                }
            }
            primarySpell = Spells[0];
        }
        

        public void ControlMovement(GameTime gameTime)
        {
            if (InputManager.Instance.KeyDown(Keys.W))
            {
                Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds; 
            }
            else if (InputManager.Instance.KeyDown(Keys.S))
            { 
                Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds; 
            }
            else
            { 
                Velocity.Y = 0; 
            }

            if (InputManager.Instance.KeyDown(Keys.A))
            {
                Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Sprite.CurrentFrame.Y == 0)
                { 
                    Sprite.CurrentFrame.Y = 1; 
                }
            }
            else if (InputManager.Instance.KeyDown(Keys.D))
            {
                Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Sprite.CurrentFrame.Y == 1)
                { 
                    Sprite.CurrentFrame.Y = 0; 
                }
            }
            else
            { Velocity.X = 0; }

            if (Velocity.X != 0 || Velocity.Y != 0)
            { 
                isMobile = true; 
            }
        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            mousePosition = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));

            Sprite.IsActive = true;
            ControlMovement(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.D1))
            {
                primarySpell = Spells[0];
            } 
            else if (InputManager.Instance.KeyPressed(Keys.D2))
            {
                primarySpell = Spells[1];
            }
            else if (InputManager.Instance.KeyPressed(Keys.D3))
            {
                primarySpell = Spells[2];
            }
            else if (InputManager.Instance.KeyPressed(Keys.D4))
            {
                primarySpell = Spells[3];
            }

            if (MCursor.Instance.LeftClick() && HasMana(primarySpell.ManaCost))
            {
                primarySpell.CastSpell(mousePosition);
            }

            /* Removed for testing
            if (InputManager.Instance.KeyDown(Keys.Space) && HasMana(lightBeam.ManaCost))
            {
                isMobile = false;
                lightBeam.CastSpell(mousePosition);
            }
            */

            if (InputManager.Instance.KeyPressed(Keys.H))
            {
                UpdateHealth(-10);
            }

            if (!isMobile)
            { Velocity = Vector2.Zero; }

            if (Velocity.X == 0 && Velocity.Y == 0)
            { Sprite.IsActive = false; }

            Sprite.Position += Velocity;
            base.Update(gameTime, enemy);
        }
    }
}