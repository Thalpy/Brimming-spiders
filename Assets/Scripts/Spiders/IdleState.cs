using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class IdleState : State
{
    public IdleState(Spider spider) : base(spider)
    {
        
    }

    public override IEnumerator Start()
    {
        Debug.Log($"Spider {spider.Id} is now in the Idle State!");

        spider.StartCoroutine(this.Idle());

        yield return null;

    }

    public override IEnumerator Idle()
    {
        for(;;)
        {
            if(spider.Objective == null && spider.Inventory.Count > 0)
            {                
                spider.Objective = "Store";
                spider.SetState(new SeekState(spider));
                yield break;
            }
            else if(spider.InventoryFull == true)
            {
                spider.Objective = "Store";
                spider.SetState(new SeekState(spider));
                yield break;
            }
            else if(spider.Objective == null && spider.Inventory.Count == 0 && spider.Working == false)
            {                
                spider.SetState(new WanderState(spider));
                yield break;
            }
            else if(spider.Objective != null)
            {                
                spider.SetState(new SeekState(spider));
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
        
    }

}