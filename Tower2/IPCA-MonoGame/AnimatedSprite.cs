using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IPCA.MonoGame
{
    public class AnimatedSprite : Sprite
    {
        protected List<Texture2D> _textures;
        protected int _currentTexture = 0;
        private bool _cycled = false;


        private int _fps = 10;
        private double _delay => 1.0f / _fps;
        private double _timer = 0f;
        
        public AnimatedSprite(string name, Vector2 position, Vector2 size, float sizemult, Texture2D[] textures) : 
            base(name, textures[0], position, size, sizemult)
        {
            _textures = textures.ToList();
        }

        public override void Update(GameTime gameTime)
        {

            _timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > _delay)
            {
                _currentTexture = (_currentTexture + 1) % _textures.Count;
                _timer = 0.0;
                _texture = _textures[_currentTexture];
            }
            
            base.Update(gameTime);
        }
    }
}