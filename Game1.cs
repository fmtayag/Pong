using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;
        private int p1_score, p2_score;
        private SpriteFont font;
        private Ball ball;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            p1_score = 0;
            p2_score = 0;
            Window.Title = "Pong by zyenapz";
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D playerTexture = Content.Load<Texture2D>("Paddle");
            Texture2D ballTexture = Content.Load<Texture2D>("Ball");
            font = Content.Load<SpriteFont>("Score");
            ball = new Ball(ballTexture)
            {
                Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                Color = Color.White,
                Graphics = _graphics
            };

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Position = new Vector2(28,50),
                    Color = Color.White,
                    SpeedY = 300f,
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S
                    },
                    Graphics = _graphics
                },
                new Player(playerTexture)
                {
                    Position = new Vector2(_graphics.PreferredBackBufferWidth - 40, _graphics.PreferredBackBufferHeight - 150),
                    Color = Color.White,
                    SpeedY = 300f,
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down
                    },
                    Graphics = _graphics
                },
                ball
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keystate = Keyboard.GetState();

            if(ball.Position.X <= 0)
            {
                p1_score += 1;
            }
            else if(ball.Position.X >= _graphics.PreferredBackBufferWidth)
            {
                p2_score += 1;
            }

            // TODO: Add your update logic here
            foreach (Sprite sprite in _sprites)
                sprite.Update(gameTime, _sprites); 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, Convert.ToString(p1_score), new Vector2(_graphics.PreferredBackBufferWidth / 2 + 200, 50), Color.White);
            _spriteBatch.DrawString(font, Convert.ToString(p2_score), new Vector2(_graphics.PreferredBackBufferWidth / 2 - 200, 50), Color.White);
            foreach (Sprite sprite in _sprites)
                sprite.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
