using GameEngine_SwerdtfegersLucas;

public class RenderManager
{
    private static List<RenderComponent> _renderTable =
        new List<RenderComponent>();

    public static void Register(RenderComponent render_component)
    {
        _renderTable.Add(render_component);
    }

    public static void Render()
    {
        foreach (RenderComponent render_component in _renderTable)
        {
            if (render_component.GetIsActive())
            {
                render_component.Render();
            }
        }
    }
}