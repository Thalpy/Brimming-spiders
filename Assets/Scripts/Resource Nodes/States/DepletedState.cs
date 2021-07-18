using System.Collections;
using UnityEngine;

internal class DepletedState : NodeState
{
    public DepletedState(GatherNodeBaseClass workNode) : base(workNode)
    {
    }

    public override IEnumerator Start()
    {
        workNode.Depleted = true;
        //transitionAnimation()
        workNode.setTargetTag("Untagged");
        workNode.StartCoroutine(Depleted());
        yield break;
    }

    public override IEnumerator Depleted()
    {
        double remainingTimeInState = workNode.DepletionTime;
        while (remainingTimeInState > 0)
        {
            remainingTimeInState -= Time.deltaTime;
            yield return new WaitForSeconds(1/15);
        }

        workNode.SetState(new WorkableState(workNode));
    }



    
}