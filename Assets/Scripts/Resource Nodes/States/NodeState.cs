using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeState : IStateful
{
    protected GatherNodeBaseClass workNode;

    public NodeState(GatherNodeBaseClass workNode)
    {
        this.workNode = workNode;
    }

    public virtual IEnumerator Workable()
    {
        yield break;
    }

    public virtual IEnumerator Working()
    {
        yield break;
    }

    public virtual IEnumerator Depleted()
    {
        yield break;
    }

    public virtual IEnumerator WorkDone()
    {
        yield break;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    
}
