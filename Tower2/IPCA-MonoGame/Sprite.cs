using System;
using Genbox.VelcroPhysics.Dynamics;
using Genbox.VelcroPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IPCA.MonoGame
{
    // Game Object child
    // represents a game object that has a texture
    public class Sprite : GameObject
    {
        public enum Direction
        {
            Left,
            Right,
        }
        protected Direction _direction = Direction.Right;
        public Direction direction => _direction;
        //As we are not using Hyperlap, we need sizemult in order to correctly scale sprites in relation to one another;
        //128f = Player/platform
        //16f = Brick;
        private float sizemult; 


        // TODO: we should not duplicate textures on each instance
        protected Texture2D _texture;
        public Sprite(string name, Texture2D texture, Vector2 position, Vector2 size, float sizemult,
            bool offset = false) : base(name, position)
        {
            this.sizemult = sizemult;
            _texture = texture;
            _size = size;  // TODO: HARDCODED!
            if (offset)
                    _position = position + new Vector2(_size.X, _size.Y) / 2f; // Anchor in the middle
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Vector2 pos = Camera.Position2Pixels(_position);
            Vector2 anchor = _texture.Bounds.Size.ToVector2() / 2f;

            Vector2 scale = Camera.Length2Pixels(_size) / sizemult; // TODO: HARDCODED!
            scale.Y = scale.X;  // FIXME! TODO: HACK HACK HACK

            spriteBatch.Draw(_texture, pos, null, Color.White,
                _rotation, anchor, scale,
                _direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
                0);

            base.Draw(spriteBatch, gameTime);
        }
    }
}