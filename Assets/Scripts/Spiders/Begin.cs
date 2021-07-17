using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : State
{
    public Begin(Spider spider) : base(spider)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log($"A new spider was born!, his name is {spider.Id}");
        yield break;


    }


}