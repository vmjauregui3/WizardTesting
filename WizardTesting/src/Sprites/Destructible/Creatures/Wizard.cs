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
        private bool isMobile;
        private MTimer castingTimer;
        private InstantProjectileSpell primarySpell;
        private FireBolt fireBolt;
        private EarthShard earthShard;
        private IceSpike iceSpike;
        private WindSlash windSlash;
        private InstantProjectileSpell lightBeam;
        public Wizard(Vector2 position, int ownerId) : base(ownerId)
        {
            Velocity = Vector2.Zero;
            Scale = 1.5f;
            Sprite = new AnimatedSprite("Sprites/BaseWizard", new Vector2(position.X, position.Y), Scale, new Vector2(4,2), 100);
            //hitDistance = 35f;

            MoveSpeed = 200f;

            isMobile = true;
            castingTimer = new MTimer(5000);

            health = 100f;
            healthMax = health;

            fireBolt = new FireBolt(this);
            primarySpell = fireBolt;
            earthShard = new EarthShard(this);
            iceSpike = new IceSpike(this);
            windSlash = new WindSlash(this);
            lightBeam = new InstantProjectileSpell(this, 1f, "Sprites/Projectiles/LightBeam", 3f, 10000, 600f, 5f);
        }

        public void ControlMovement(GameTime gameTime)
        {
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
                if (Sprite.CurrentFrame.Y == 1)
                { Sprite.CurrentFrame.Y = 0; }
            }
            else
            { Velocity.X = 0; }

            if (Velocity.X != 0 || Velocity.Y != 0)
            { isMobile = true; }
        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            mousePosition = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));

            Sprite.IsActive = true;
            ControlMovement(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.D1))
            {
                primarySpell = fireBolt;
            } 
            else if (InputManager.Instance.KeyPressed(Keys.D2))
            {
                primarySpell = earthShard;
            }
            else if (InputManager.Instance.KeyPressed(Keys.D3))
            {
                primarySpell = iceSpike;
            }
            else if (InputManager.Instance.KeyPressed(Keys.D4))
            {
                primarySpell = windSlash;
            }

            if (MCursor.Instance.LeftClick() && HasMana(fireBolt.ManaCost))
            {
                primarySpell.CastSpell(mousePosition);
            }

            if (InputManager.Instance.KeyDown(Keys.Space) && HasMana(lightBeam.ManaCost))
            {
                isMobile = false;
                lightBeam.CastSpell(mousePosition);
            }

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