public enum NEvent
{
    Complete,
    Tick
}

public abstract class NodeEvent
{
    public abstract NEvent GetEvent();
}

public class NodeTickEvent : NodeEvent
{
    public override NEvent GetEvent()
    {
        return NEvent.Tick;
    }
}

public class NodeCompleteEvent : NodeEvent
{
    public override NEvent GetEvent()
    {
        return NEvent.Complete;
    }
}