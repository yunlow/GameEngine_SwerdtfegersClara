using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class LevelComponent : Component
    {
        private int _width;
        private int _height;
        private GameEngine _gameEngine;
        private Random _random = new Random();

        private float enemy_spawn_timer = 0f;
        private float enemy_spawn_interval = 7f;
        private int _spawnCount = 0;    

        private EntityDatabase _entityDatabase;

        public LevelComponent(GameObject game_object,  GameEngine game_engine, EntityDatabase entity_database, int width, int height) : base(game_object)
        {
            _width = width;
            _height = height;
            _gameEngine = game_engine;
            _entityDatabase = entity_database;

            RegisterPrototypes();
        }

        public void RegisterPrototypes()
        {
            GameObject enemy_prototype = new GameObject(_gameEngine, "Enemy");

            _entityDatabase.RegisterEntity("Enemy", enemy_prototype);

        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            enemy_spawn_timer += fixed_elapsed_time;

            if (enemy_spawn_timer >= enemy_spawn_interval)
            {
                SpawnEnemy();
                enemy_spawn_timer = 0f;
            }
        }

        private void SpawnEnemy()
        {
            string enemy_type; float enemy_speed; 
            if (_spawnCount % 3 == 0) 
            { enemy_type = "FastEnemy"; enemy_speed = 15f; } 
            else 
            { enemy_type = "Enemy"; enemy_speed = 5f; }
            _spawnCount++;

            GameObject new_enemy = _entityDatabase.CreateEntity(enemy_type);

            PositionComponent position_component = new_enemy.GetComponent<PositionComponent>();

            if (position_component != null) 
            
            { 
                float random_x = _random.Next(0, _width); 
                float random_y = _random.Next(0, _height); 
                position_component.SetPosition(new Vector2(random_x, random_y)); 
            }
            AiMovementComponent ai_movement = new AiMovementComponent(new_enemy, position_component, this);
            new_enemy.AddComponent(ai_movement);
            _gameEngine.AddGameObject(new_enemy);
        }

        public override Component Clone(GameObject parent_game_object)
        {
          throw new NotImplementedException();
        }
    }
}
