using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulSpider : MonoBehaviour
{
    protected enum SpiderFSM
    {
        Working,
        Moving,
        Idle,
    }


    public void OnNotify(NEvent nEvent)
    {

    }  




}