using System.Collections;
using UnityEngine;

internal class WorkDoneState : NodeState
{


    public WorkDoneState(GatherNodeBaseClass workNode) : base(workNode)
    {

    }

    public override IEnumerator Start()
    {
        //Any transition animations should go here
        workNode.StartCoroutine(WorkDone());
        yield break;
    }

    public override IEnumerator WorkDone()
    {
        while (workNode.Inventory.Count > 0 && workNode.WorkerList.Count > 0)
        {
            //animate()
            for (int i = 0; i <= workNode.WorkerList.Count-1; i ++)
            {
                if (!workNode.WorkerList[i].InventoryFull){workNode.GiveResourceToWorker(workNode.YieldResource(), workNode.WorkerList[i]);}
                if (workNode.WorkerList[i].InventoryFull){workNode.RemoveWorker(workNode.WorkerList[i]);}
            }
            yield return new WaitForSeconds(1/15);
        }
        for(int i = 0; i <= workNode.WorkerList.Count-1; i++)
        {
            workNode.RemoveWorker(workNode.WorkerList[i]);
        }  
        workNode.SetState(new DepletedState(workNode));        
    }


}