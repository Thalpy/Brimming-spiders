using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IWorkNode : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private string nodeType;
    [SerializeField] private double standardWorkTime;
    [SerializeField] private double remainingWorkTime;
    [SerializeField] private bool workComplete;
    [SerializeField] private List<Spider> workerList = new List<Spider>();
    [SerializeField] private List<Resource> inventory = new List<Resource>{new Resource(), new Resource(), new Resource(), new Resource()};
    [SerializeField] GameObject owner; // reference to the owning game object

    public string NodeType { get => nodeType; set => nodeType = value; } // The type of node that we have - this will allow us to assign different animations etc.

    public double StandardWorkTime { get => standardWorkTime; set => standardWorkTime = value; } // the amount of time that a level 1 minion will require to complete this task

    public double RemainingWorkTime { get => remainingWorkTime; set => remainingWorkTime = value; } // the amount of time left for completion of this node - we can use this to calculate work progress

    
    public bool WorkComplete { get => workComplete; set => workComplete = value; }

    public List<Spider> WorkerList { get => workerList; set => workerList = value; }

    public List<Resource> Inventory { get => inventory; set => inventory = value; }
    public GameObject Owner { get => owner; set => owner = value; }

    

    public double GetProgress()
    {
        return (100 * RemainingWorkTime / StandardWorkTime);
    }


    public virtual void Awake()
    {
        Owner = gameObject;
        RemainingWorkTime = StandardWorkTime;


    }

    void Update()
    {
        if(remainingWorkTime <= 0){CompleteWork();}
        else
        {
            foreach(Spider s in WorkerList)
            {
                remainingWorkTime -= s.Speed * Time.deltaTime;
            }
        }
    }

    public virtual void AddWorker(Spider spider)
    {
        WorkerList.Add(spider);
        spider.Working = true;
    }

    public virtual void RemoveWorker(Spider spider)
    {
        WorkerList.Remove(spider);
        spider.Working = false;
    }

    public virtual void PerformWork(double workQuantity)
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

    public virtual void PerformWorkAnim()
    {
        throw new NotImplementedException();
    }


    public virtual void GiveResourceToWorker(Resource r, Spider s)
    {
        s.AddResourceToInventory(r);
    }

    public virtual Resource YieldResource()
    {
        Resource currentResource = Inventory[0];
        Inventory.RemoveAt(0);
        return currentResource;
    }

    public virtual void CompleteWork()
    {
        while (Inventory.Count > 0)
        {
            foreach (Spider s in WorkerList)
            {
                if (!s.InventoryFull){GiveResourceToWorker(YieldResource(), s);}
            }
        }

        for(int i =0; i <= WorkerList.Count; i++)
        {
            RemoveWorker(WorkerList[i]);
        }

        DestroyNode();
    }

    public virtual void DestroyNode()
    {
        
        Destroy(this.gameObject);
        DoFinalAnim();
    }

    public virtual void DoFinalAnim()
    {
        Debug.Log("DoFinalAnim method not yet implemented!");
        //Node destruction animation
    }








}
