using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class Level : GameObject
    {
        private int _width;
        private int _height;
        private GameEngine _gameEngine;
        private Random _random = new Random();
        private float enemy_spawn_timer = 0f;
        private float enemy_spawn_interval = 7f;
        public Level(GameEngine game_engine, int width, int height)
        {
            _width = width;
            _height = height;
            _gameEngine = game_engine;
           
 game_engine.AddGameObject(this);

            for (int i = 0; i < 4; i++)
            {
                SpawnEnemy();
            }

        }

        public int Width
        { get { return _width; } }
        public int Height
        { get { return _height; } }
        public override void Update(float elapsed_time) { }

        public override void FixedUpdate(float fixed_elapsed_time) {
            enemy_spawn_timer += fixed_elapsed_time;

            if (enemy_spawn_timer >= enemy_spawn_interval)
            {
                SpawnEnemy();
                enemy_spawn_timer = 0f;
            }
        }

        public override void Render() { }

        public override void HandleInput(ConsoleKey player_command) { }

        private void SpawnEnemy()
        {
            Vector2 position = new Vector2(
                _random.Next(0, _width),
                _random.Next(0, _height)
            );

            new Enemy(_gameEngine, this, position);
        }

    }
}
