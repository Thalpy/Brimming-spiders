using System.Collections;
using UnityEngine;

internal class WanderState : State
{
    public WanderState(Spider spider) : base(spider)
    {
    }

    public override IEnumerator Start()
    {
        
        Debug.Log($"Spider {spider.Id} is now wandering!");
        spider.StartCoroutine(Wander());
        yield return null;

    }

    public override IEnumerator Wander()
    {
        Vector3 currentPosition = spider.spiderMovementController.MyTransform.position;
        Vector3 targetPosition = currentPosition + new Vector3(Random.Range(-1f,1f), 0f, Random.Range(-1f,1f));
        while (Vector3.Distance(targetPosition, currentPosition) > 0.5f)
        {
            spider.spiderMovementController.MyTransform.LookAt(targetPosition);
            spider.spiderMovementController.MyRigidbody.AddRelativeForce(Vector3.forward * (float)spider.Speed, ForceMode.Force);
            yield return new WaitForSeconds(1/60);
        }
        spider.SetState(new IdleState(spider));
        yield break;
    }
}