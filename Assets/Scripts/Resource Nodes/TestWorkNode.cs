using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorkNode : MonoBehaviour, IWorkNode
{
    [SerializeField] string nodeType;

    [SerializeField] double standardWorkTime = 10.0;

    [SerializeField] double remainingWorkTime = 10.0;

    [SerializeField] double progress;

    [SerializeField] bool workComplete = false;

    [SerializeField] List<Spider> workerList = new List<Spider>();

    [SerializeField] List<Resource> inventory = new List<Resource>();    

    [SerializeField] GameObject owner;

    public string NodeType { get => nodeType; set => nodeType = value; }
    public double StandardWorkTime { get => standardWorkTime; set => standardWorkTime = value; }
    public double RemainingWorkTime { get => remainingWorkTime; set => remainingWorkTime = value; }
    public double Progress { get => progress; set => progress = value; }
    public bool WorkComplete { get => workComplete; set => workComplete = value; }
    public List<Spider> WorkerList { get => workerList; set => workerList = value; }
    public List<Resource> Inventory { get => inventory; set => inventory = value; }
    public GameObject Owner { get => owner; set => owner = value; }

    void Awake()
    {
        owner = gameObject;
        RemainingWorkTime = StandardWorkTime;


    }

    void Update()
    {
        
        if (workerList.Count == 0 && RemainingWorkTime > 0){return;}
       


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

    public double GetProgress()
    {
        return (100 * RemainingWorkTime / StandardWorkTime);
    }

      public void AddWorker(Spider spider)
    {
        WorkerList.Add(spider);
        spider.Working = true;
        spider.spiderMovementController.MyRigidbody.isKinematic = true;
    }

    public void RemoveWorker(Spider spider)
    {
        WorkerList.Remove(spider);
        spider.Working = false;
        spider.spiderMovementController.MyRigidbody.isKinematic = false;
    }

    private void PerformWork(double workQuantity)
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

    private void PerformWorkAnim()
    {
        Debug.Log("Work anim has not been implemented!");
    }


    private void GiveResourceToWorker(Resource r, Spider s)
    {
        s.AddResourceToInventory(r);
    }

    private Resource YieldResource()
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

    private void DestroyNode()
    {
        
        Destroy(this.gameObject);
        DoFinalAnim();
    }

    private void DoFinalAnim()
    {
        Debug.Log("DoFinalAnim method not yet implemented!");
        //Node destruction animation
    }


}
