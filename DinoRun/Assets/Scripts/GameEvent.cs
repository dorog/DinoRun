using System;

public class GameEvent
{
    private Action _action;

    public void Subscribe(Action action)
    {
        _action += action;
    }

    public void Call()
    {
        _action?.Invoke();
    }
}
