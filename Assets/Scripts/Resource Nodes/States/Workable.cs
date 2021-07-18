using System.Collections;
using UnityEngine;

public class WorkableState : NodeState
{

    public WorkableState(GatherNodeBaseClass workNode) : base(workNode)
    {

    }

    public override IEnumerator Start()
    {
        //transitionAnimation()
        workNode.Depleted = false;
        workNode.setTargetTag("Resource");
        workNode.RepopulateNode();
        workNode.StartCoroutine(Workable());
        yield break;
        
    }

    public override IEnumerator Workable()
    {
        while (workNode.WorkerList.Count == 0)
        {
            //animate()
            yield return new WaitForSeconds(1/15);
        }
        workNode.SetState(new WorkingState(workNode));

    }

    


    
}