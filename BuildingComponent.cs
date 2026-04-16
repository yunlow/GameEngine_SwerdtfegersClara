using GameEngine_SwerdtfegersLucas;
using System;
using System.Collections.Generic;
using System.Text;

public class BuildingComponent : Component
{
    private float _time_left;
    private RenderComponent _render;

    public BuildingComponent(
        GameObject game_object,
        RenderComponent render
    )
        : base(game_object)
    {
        _time_left = 10f;
        _render = render;
    }

    public override void Update(float elapsed_time)
    {
        
    }

    public override void FixedUpdate(float fixed_elapsed_time)
    {
        _time_left -=fixed_elapsed_time;

        _render.Render();
    }

    public override Component Clone(GameObject parent_game_object)
    {
        return new BuildingComponent(parent_game_object, _render);
    }
    public void Render() { }
    public void ProcessInput() { }
}