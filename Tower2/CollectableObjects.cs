using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genbox.VelcroPhysics.Dynamics;
using IPCA.MonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Tower2
{
    public class Coin : AnimatedSprite
    {
        private Game1 game;
        private BreakableBody body;
        public Coin(Game1 game, Vector2 position, bool offset = false) :
            base("coin", position, new Vector2(0.25f, 0.25f), 16f, Enumerable.Range(1, 8).Select(n => game.Content.Load<Texture2D>($"Coin/Coin {n}")).ToArray())
        {
            this.game = game;
            AddRectangleBody(this.game.Services.GetService<World>(), _size.X, _size.Y);
            Body.BodyType = BodyType.Kinematic;
            Body.IsSensor = true;
            Body.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "platform" || b.GameObject().Name == "spikes")
                {
                    Body.Position += Vector2.UnitY;
                }
            };
        }

    }

    public class Crystal : AnimatedSprite
    {
        private Game1 game;
        public Crystal(Game1 game, Vector2 position) :
            base("crystal", position, new Vector2(0.25f, 0.25f), 16f, Enumerable.Range(1, 8).Select(n => game.Content.Load<Texture2D>($"crystal/crystal {n}")).ToArray())
        {
            this.game = game;
            AddRectangleBody(this.game.Services.GetService<World>(), _size.X, _size.Y);
            Body.BodyType = BodyType.Kinematic;
            Body.IsSensor = true;
            Body.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "platform" || b.GameObject().Name == "spikes")
                {
                    Body.Position += Vector2.UnitY;
                }
            };
        }
    }

    public class RedHeart : Sprite
    {
        private Game1 game;

        public RedHeart(Game1 game, Vector2 position) :
            base("redheart", game.Content.Load<Texture2D>("HealthHeart"), position, new Vector2(0.4f, 0.4f), 32f)
        {
            this.game = game;
            AddRectangleBody(this.game.Services.GetService<World>(), _size.X, _size.Y);
            Body.BodyType = BodyType.Kinematic;
            Body.IsSensor = true;

            Body.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "platform" || b.GameObject().Name == "spikes")
                {
                    Body.Position += Vector2.UnitY;
                }
            };

        }

    }

    public class ManaHeart : Sprite
    {
        private Game1 game;

        public ManaHeart(Game1 game, Vector2 position) :
            base("manaheart", game.Content.Load<Texture2D>("ManaHeart"), position, new Vector2(0.4f, 0.4f), 32f)
        {
            this.game = game;
            AddRectangleBody(this.game.Services.GetService<World>(), _size.X, _size.Y);
            Body.BodyType = BodyType.Kinematic;
            Body.IsSensor = true;

            Body.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "platform" || b.GameObject().Name == "spikes")
                {
                    Body.Position += Vector2.UnitY;
                }
            };
        }
    }

    public class Hourglass : Sprite
    {
        private Game1 game;

        public Hourglass(Game1 game, Vector2 position) :
            base("hourglass", game.Content.Load<Texture2D>("Sand clock png"), position, new Vector2(0.4f, 0.8f), 760f)
        {
            this.game = game;
            AddRectangleBody(this.game.Services.GetService<World>(), _size.X, _size.Y);
            Body.BodyType = BodyType.Kinematic;
            Body.IsSensor = true;

            Body.OnCollision = (a, b, contact) =>
            {
                if (b.GameObject().Name == "platform" || b.GameObject().Name == "spikes")
                {
                    Body.Position += Vector2.UnitY;
                }
            };
        }

    }


}
