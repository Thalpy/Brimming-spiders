using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Idle state - when a spider is between tasks it will be in this state
/// </summary>
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

/// <summary>
/// Idle method - spider decides what to do based upon available objectives
/// </summary>
/// <returns></returns>
    public override IEnumerator Idle()
    {
        for(;;)
        {
            if(spider.Objective == null && spider.Inventory.Count > 0) //If the spider can't find matching resources and has stuff in the inventory, should store them
            {                
                spider.Objective = "Store";
                spider.SetState(new SeekState(spider));
                yield break;
            }
            else if(spider.InventoryFull == true) // If the spider's inventory is true, it should store the items
            {
                spider.Objective = "Store";
                spider.SetState(new SeekState(spider));
                yield break;
            }
            else if(spider.Objective == null && spider.Inventory.Count == 0 && spider.Working == false) // if the spider has nothing in the inventory and no objective and is not working, it should wander
            {                
                spider.SetState(new WanderState(spider));
                yield break;
            }
            else if(spider.Objective != null) //if the spider has an objective, it should find a matching target.
            {                
                spider.SetState(new SeekState(spider));
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
        
    }

}