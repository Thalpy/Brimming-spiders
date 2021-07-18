using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherNodeBaseClass : StateMachine, IWorkNode
{
    [SerializeField] string nodeType;

    [SerializeField] double depletionTime;

    [SerializeField] double standardWorkTime = 10.0;

    [SerializeField] double remainingWorkTime = 10.0;

    [SerializeField] double progress;

    [SerializeField] bool workComplete = false;

    [SerializeField] bool depleted = false;

    [SerializeField] List<Spider> workerList = new List<Spider>();

    [SerializeField] List<Resource> inventory = new List<Resource>();    

    [SerializeField] GameObject owner;

    [SerializeField] GameObject nodeTarget;

    public string NodeType { get => nodeType; set => nodeType = value; }
    public double StandardWorkTime { get => standardWorkTime; set => standardWorkTime = value; }
    public double RemainingWorkTime { get => remainingWorkTime; set => remainingWorkTime = value; }
    public double Progress { get => progress; set => progress = value; }
    public bool WorkComplete { get => workComplete; set => workComplete = value; }
    public List<Spider> WorkerList { get => workerList; set => workerList = value; }
    public List<Resource> Inventory { get => inventory; set => inventory = value; }
    public GameObject Owner { get => owner; set => owner = value; }
    public bool Depleted { get => depleted; set => depleted = value; }

    public double DepletionTime {get => depletionTime; set => depletionTime = value;}
    public GameObject NodeTarget { get => nodeTarget; set => nodeTarget = value; }

    public void Awake()
    {
        owner = gameObject;
        remainingWorkTime = StandardWorkTime;
        nodeTarget = owner.transform.GetChild(0).gameObject;
        SetState(new WorkableState(this));
    }

    public void setTargetTag(string value)
    {
        nodeTarget.tag = value;
    }

#region deprecated
/*
    void Update()
    {
        if (workerList.Count != 0)
        {
            if(RemainingWorkTime <= 0){CompleteWork();}
            else
            {
                foreach(Spider s in WorkerList)
                {
                    RemainingWorkTime -= s.Speed * Time.deltaTime;
                }
            }
        }
    }
    */
#endregion

    public double GetProgress()
    {
        return (100 * RemainingWorkTime / StandardWorkTime);
    }

      public void AddWorker(Spider spider)
    {
        WorkerList.Add(spider);
        spider.Working = true;
    }

    public void RemoveWorker(Spider spider)
    {
        WorkerList.Remove(spider);
        spider.Working = false;
    }

    public void PerformWork(double workQuantity)
    {
        RemainingWorkTime -= workQuantity;
        if (RemainingWorkTime <= 0)
        {
            WorkComplete = true;
        }
        else
        {
            PerformWorkAnim();
        }

    }

    public void PerformWorkAnim()
    {
        Debug.Log("Work anim has not been implemented!");
    }


    public void GiveResourceToWorker(Resource r, Spider s)
    {
        s.AddResourceToInventory(r);
    }

    public Resource YieldResource()
    {
        Resource currentResource = Inventory[0];
        Inventory.RemoveAt(0);
        return currentResource;
    }

    private void CompleteWork()
    {
        while (Inventory.Count > 0 && workerList.Count > 0)
        {
            for(int i = 0; i <= workerList.Count-1; i++)
            {
                Debug.Log($"Completing work, i is {i}");
                if (!workerList[i].InventoryFull){GiveResourceToWorker(YieldResource(), workerList[i]);}
                if (workerList[i].InventoryFull){RemoveWorker(workerList[i]);}
            }
        }

        for(int i = 0; i <= workerList.Count-1; i++)
        {
            RemoveWorker(workerList[i]);
        }               

        DestroyNode();
    }

    public void DestroyNode()
    {
        
        Destroy(this.gameObject);
        DoFinalAnim();
    }

    public void DoFinalAnim()
    {
        Debug.Log("DoFinalAnim method not yet implemented!");
        //Node destruction animation
    }

    public virtual void RepopulateNode()
    {
        Debug.Log("Method not implemented on base class!");
    }
}
