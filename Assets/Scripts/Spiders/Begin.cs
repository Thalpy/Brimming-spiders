using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inital spider state - spiders move from this state into the idle state
/// </summary>
public class Begin : State
{
    public Begin(Spider spider) : base(spider)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log($"A new spider was born!, his name is {spider.Id}");           
        
        spider.SetState(new IdleState(spider));

        yield break;

    }


}