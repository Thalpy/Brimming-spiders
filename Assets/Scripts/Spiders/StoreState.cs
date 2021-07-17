using System.Collections;
using UnityEngine;
internal class StoreState : State
{
    public StoreState(Spider spider) : base(spider)
    {
        
    }

    public override IEnumerator Start()
    {
        Debug.Log($"Spider {spider.Id} is now in the store state");
        spider.Working = true;
        spider.StartCoroutine(Store());
        yield break;
    }

    public override IEnumerator Store()
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