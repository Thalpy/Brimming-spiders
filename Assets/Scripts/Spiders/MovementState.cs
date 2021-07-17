using System.Collections;
using UnityEngine;

internal class MovementState : State
{
    public MovementState(Spider spider) : base(spider)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log($"Spider {spider.Id} is now moving!");
        spider.StartCoroutine(Move());
        yield break;

    }

    public override IEnumerator Move()
    {
        for(;;)
        {
            float distanceToTarget = Vector3.Distance(spider.spiderMovementController.MyTransform.position, spider.spiderMovementController.TargetTransform.position);
            float targetRadius = spider.spiderMovementController.TargetTransform.GetComponent<SphereCollider>().radius;
            Debug.Log($"Spider {spider.Id}'s distance to target is {distanceToTarget}");
            if (distanceToTarget <= targetRadius+0.5f)
            {
                if(spider.Objective == "Resource")
                {
                    spider.SetState(new GatherState(spider));
                    yield break;
                }
                if(spider.Objective == "Store")
                {
                    spider.SetState(new StoreState(spider));
                    yield break;
                }
            }
            else
            {
                spider.spiderMovementController.RotateAndMoveTowardsTarget();
                yield return new WaitForSeconds(1/30);
            }
        }






            #region deprecated
            /*


            float distanceToTarget = Vector3.Distance(spider.spiderMovementController.MyTransform.position, spider.spiderMovementController.TargetTransform.position);
            float targetRadius = spider.spiderMovementController.TargetTransform.GetComponent<BoxCollider>().size.x;
            Debug.Log($"Spider {spider.Id}'s distance to target is {distanceToTarget}");
            if (distanceToTarget <= targetRadius+0.5f)
            {
                if(spider.Objective == "Resource")
                {
                    spider.SetState(new GatherState(spider));
                    yield break;
                }
                if(spider.Objective == "Store")
                {
                    spider.SetState(new StoreState(spider));
                    yield break;
                }
            }
            else
            {
                spider.spiderMovementController.RotateAndMoveTowardsTarget();
                yield return new WaitForSeconds(1/60);
            }
        }
        */

        #endregion


                
    }
}