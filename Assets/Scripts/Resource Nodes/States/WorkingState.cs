using System.Collections;
using UnityEngine;

internal class WorkingState : NodeState
{


    public WorkingState(GatherNodeBaseClass workNode) : base(workNode)
    {
        
    }

    public override IEnumerator Start()
    {
        //any transition animations should go here
        workNode.StartCoroutine(Working());
        yield break;
    }

    public override IEnumerator Working()
    {
        while (workNode.RemainingWorkTime >= 0)
        {
            //any calls to working animations should go here
            foreach(Spider s in workNode.WorkerList)
            {
                workNode.RemainingWorkTime -= s.Speed * 1/15;
            }
            yield return new WaitForSeconds(1/15);
        }
        workNode.SetState(new WorkDoneState(workNode));        
    }






}