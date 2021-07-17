using System.Collections;
using UnityEngine;

/// <summary>
/// In the seek state, spiders check to see if there are any matching targets.
/// </summary>
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
        if (targetTransform == null) //If the spider can't find a matching target, it should go for a wander
        {
            spider.SetState(new WanderState(spider));
            yield break;
        }
        else //If the spider finds an objective it should switch to the movement state and navigate towards it.
        {
            spider.spiderMovementController.TargetTransform = targetTransform;
            spider.SetState(new MovementState(spider));
            yield break;
        }

    } 



    





}