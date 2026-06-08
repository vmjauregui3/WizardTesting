using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace WizardTesting
{
    public class InstantProjectileSpell : InstantSpell
    {
        protected string path;
        protected float spriteScale;

        protected Stat duration;
        public int Duration
        {
            get { return (int)Math.Round(duration.Value, 4); }
        }
        protected Stat speed;
        public float Speed
        {
            get { return speed.Value; }
        }

        protected Stat damage;
        public int Damage
        {
            get { return (int)Math.Round(damage.Value, 4); }
        }

        public Vector2 Target;

        public InstantProjectileSpell(Creature owner, int manaCost, string path, float spriteScale, int duration, float speed, int damage) : base(owner, manaCost, 50, 50)
        {
            this.path = path;
            this.spriteScale = spriteScale;
            this.duration = new Stat(duration);
            this.speed = new Stat(speed);
            this.damage = new Stat(damage);
            SpellType = SpellType.Projectile;
            castEffect = CreateProjectile;
            SpellParameters = new Dictionary<string, string>
            {
                ["path"] = path,
                ["spriteScale"] = spriteScale.ToString(),
                ["duration"] = this.duration.Value.ToString(),
                ["speed"] = this.speed.Value.ToString(),
                ["damage"] = this.damage.Value.ToString()
            };
        }

        public InstantProjectileSpell(Creature owner, int manaCost, string path, float spriteScale, int duration, float speed, int damage, int level, int exp) : base(owner, manaCost, 50, 50, level, exp)
        {
            this.path = path;
            this.spriteScale = spriteScale;
            this.duration = new Stat(duration);
            this.speed = new Stat(speed);
            this.damage = new Stat(damage);
            SpellType = SpellType.Projectile;
            castEffect = CreateProjectile;
            SpellParameters = new Dictionary<string, string>
            {
                ["path"] = path,
                ["spriteScale"] = spriteScale.ToString(),
                ["duration"] = this.duration.Value.ToString(),
                ["speed"] = this.speed.Value.ToString(),
                ["damage"] = this.damage.Value.ToString()
            };
        }

        public InstantProjectileSpell(Creature owner, XElement spellData) : base(owner, spellData)
        {
            SpellTypeParameters = spellData.Element("SpellTypeParameters").Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);
            path = SpellTypeParameters["path"];
            spriteScale = Convert.ToSingle(SpellTypeParameters["spriteScale"]);
            this.duration = new Stat(Convert.ToInt32(SpellTypeParameters["duration"]));
            this.speed = new Stat(Convert.ToSingle(SpellTypeParameters["speed"]));
            this.damage = new Stat(Convert.ToInt32(SpellTypeParameters["damage"]));
            SpellType = SpellType.Projectile;
        }

        protected override XElement GetSpellTypeParameters()
        {
            XElement spellTypeParams = new XElement("SpellTypeParameters",
                new XElement("path", path),
                new XElement("spriteScale", spriteScale),
                new XElement("duration", duration.Value),
                new XElement("speed", speed.Value),
                new XElement("damage", damage.Value)
            );
            return spellTypeParams;
        }
        protected override void CreateProjectile()
        {
            Vector2 position = new Vector2(owner.Sprite.Position.X, owner.Sprite.Position.Y);
            Vector2 direction = Vector2.Normalize(owner.SpellTarget - position);
            Projectile projectile = new Projectile(path, position, spriteScale, new Vector2(1, 1), 0, this, Duration, direction, Speed, Damage);
            GameCommands.PassProjectile(projectile);
        }
    }
}
