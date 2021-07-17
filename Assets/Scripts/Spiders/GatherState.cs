using System.Collections;
using UnityEngine;

internal class GatherState : State
{
    public GatherState(Spider spider) : base(spider)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log($"Spider {spider.Id} is now in the Gather state!");
        spider.spiderMovementController.MyRigidbody.velocity = Vector3.zero;
        spider.Working = true;
        spider.StartCoroutine(Gather());
        yield break;
    }

    public override IEnumerator Gather()
    {
        while(true)
        {
            if (spider.Working == false)
            {
                Debug.Log("Spider has finished working!");
                spider.SetState(new IdleState(spider));
                yield break;            
            }
            yield return new WaitForSeconds(0.2f);

        }
        
    }
}