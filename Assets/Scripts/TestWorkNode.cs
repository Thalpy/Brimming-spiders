using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorkNode : IWorkNode 
{
    [SerializeField] string nodeType;

    [SerializeField] double standardWorkTime = 10.0;

    [SerializeField] double remainingWorkTime = 10.0;

    [SerializeField] double progress;

    [SerializeField] bool workComplete = false;

    [SerializeField] List<Spider> workerList = new List<Spider>();

    [SerializeField] List<Resource> inventory = new List<Resource>();    




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
