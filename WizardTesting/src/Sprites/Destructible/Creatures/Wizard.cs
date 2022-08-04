using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

// Mostly works as a Sprite Only
namespace WizardTesting
{
    public class Wizard : Creature
    {
        private Vector2 mousePosition;
        public float Scale;
        public Wizard(Vector2 position, int ownerId) : base(ownerId)
        {
            Velocity = Vector2.Zero;
            Scale = 1.5f;
            Sprite = new AnimatedSprite("Sprites/BaseWizard", new Vector2(position.X, position.Y), Scale, new Vector2(4,2), 100);
            //hitDistance = 35f;

            health = 100f;
            healthMax = health;
        }


        public override void Update(GameTime gameTime, Player enemy)
        {
            mousePosition = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));

            Sprite.IsActive = true;
            if (InputManager.Instance.KeyDown(Keys.W))
            { Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds; }
            else if (InputManager.Instance.KeyDown(Keys.S))
            { Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds; }
            else
            { Velocity.Y = 0; }

            if (InputManager.Instance.KeyDown(Keys.A))
            {
                Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Sprite.CurrentFrame.Y == 0)
                { Sprite.CurrentFrame.Y = 1; }
            }
            else if (InputManager.Instance.KeyDown(Keys.D))
            {
                Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if ( Sprite.CurrentFrame.Y == 1)
                { Sprite.CurrentFrame.Y = 0; }
            }
            else
            { Velocity.X = 0; }

            if (Velocity.X == 0 && Velocity.Y == 0)
            { Sprite.IsActive = false; }

            if (MCursor.Instance.LeftClick() && mana >= 5)
            {
                GameCommands.PassProjectile(new FireBolt("Sprites/Projectiles/FireBolt", new Vector2(Sprite.Position.X + Sprite.SourceRect.Width/2, Sprite.Position.Y), this, mousePosition));
                mana -= 5;
            }

            Sprite.Position += Velocity;
            base.Update(gameTime, enemy);
        }
    }
}