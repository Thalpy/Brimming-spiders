using System.Collections;
using UnityEngine;

/// <summary>
/// Wander state occurs when spider has nothing else to do - spider will navigate to a random nearby point
/// before returning to the idle state
/// </summary>
internal class WanderState : State
{
    public Vector3 wanderTarget;

    public float wanderDistance;

    public Vector3 currentPosition;
    public WanderState(Spider spider) : base(spider)
    {
        spider.TimeWandering = 3;
    }

    public override IEnumerator Start()
    {
        
        Debug.Log($"Spider {spider.Id} is now wandering!");        
        currentPosition = spider.spiderMovementController.MyTransform.position;
        wanderTarget = currentPosition + new Vector3(Random.Range(-3f,3f), 0f, Random.Range(-3f,3f));
        wanderDistance = Vector3.Distance(currentPosition, wanderTarget);
        spider.StartCoroutine(Wander());
        yield break;

    }
    /// <summary>
    /// Wander co-routine - chooses a random target position for the spider then moves towards it
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Wander()
    {    
        while (wanderDistance >= 0.2f && spider.TimeWandering > 0)
        {
            currentPosition = spider.spiderMovementController.MyTransform.position;
            Debug.Log($"Distance to wander target is {wanderDistance}");
            Debug.Log($"Time on target is {spider.TimeWandering}");
            spider.TimeWandering = spider.TimeWandering - (double) 1/30;        
            spider.spiderMovementController.MoveTowardsPosition(wanderTarget);
            wanderDistance = Vector3.Distance(currentPosition, wanderTarget);
            yield return new WaitForSeconds(1/30);
        }
        spider.SetState(new IdleState(spider));
    }
}