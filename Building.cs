using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class Building : GameObject
    {
        private Vector2 _position = new Vector2(0, 0);
        private float _elapsedTime = 0f;

        private GameEngine _gameEngine;
        private string _renderGraphic = "B";
        
        private StateMachine _stateMachine;

        public Building(GameEngine game_engine, int construction_time) : base(game_engine)
        {
            _stateMachine = new StateMachine();
            _gameEngine = game_engine;
            game_engine.AddGameObject(this);
            _stateMachine.SetInitialState(new BuildingUnderConstructionState(_stateMachine, this, construction_time));
        }
        public override void SetActive(bool is_active)
        {  
           this.SetActive(is_active);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }
        public Vector2 GetPosition()
        {
            return _position;
        }
        public string GetRenderGraphic()
        {
            return _renderGraphic;
        }



        public override void FixedUpdate(float fixed_elapsed_time)
        {
            _stateMachine.FixedUpdate(fixed_elapsed_time);
        }

        public override void Update(float elapsed_time) 
        { 
            _stateMachine.Update(elapsed_time);
        }

        public override void HandleInput(ConsoleKey handle_input)
        {
        
        }

        public override void Render()
        {
            _stateMachine.Render();

        }
    }
}
