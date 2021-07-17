using System.Collections;
using UnityEngine;

internal class SeekState : State
{
    public SeekState(Spider spider) : base(spider)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log($"The spider {spider.Id} is now in the seek state!");
        spider.StartCoroutine(Seek());
        yield break;
        
    }

    public override IEnumerator Seek()
    {
        //check if there are any objectives in the world that match the spiders current objective
        //if there are, switch to the move state.
        //if there aren't swtich to the idle state.

        spider.spiderObjectiveFinder.Objective = spider.Objective;
        Transform targetTransform = spider.spiderObjectiveFinder.GetObjectiveTransform(spider.GetComponent<Transform>());
        if (targetTransform == null)
        {
            spider.SetState(new WanderState(spider));
            yield break;
        }
        else
        {
            spider.spiderMovementController.TargetTransform = targetTransform;
            spider.SetState(new MovementState(spider));
            yield break;
        }

    }
    





}