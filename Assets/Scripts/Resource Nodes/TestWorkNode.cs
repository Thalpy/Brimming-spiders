using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorkNode : GatherNodeBaseClass
{

    
    
    public override void RepopulateNode()
    {
        Inventory = new List<Resource>{
            new Resource("poo", 1),
            new Resource("poo", 1),
            new Resource("poo", 1),
            new Resource("poo", 1),
        };
        RemainingWorkTime = StandardWorkTime;
    }
    


}
