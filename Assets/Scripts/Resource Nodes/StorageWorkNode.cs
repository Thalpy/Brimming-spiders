using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StorageWorkNode : MonoBehaviour, IWorkNode
{
    [SerializeField] string nodeType;

    [SerializeField] double standardWorkTime = 2.0;

    [SerializeField] double remainingWorkTime = 2.0;

    [SerializeField] double progress;

    [SerializeField] bool workComplete = false;

    [SerializeField] List<Spider> workerList = new List<Spider>();

    [SerializeField] List<Resource> inventory = new List<Resource>();    

    [SerializeField] GameObject owner;
    public string NodeType {get; set;}
    public double StandardWorkTime {get; set;}
    public double RemainingWorkTime {get; set;}
    public bool WorkComplete {get; set;}
    public List<Spider> WorkerList {get; set;}
    public List<Resource> Inventory { get; set;}
    public GameObject Owner { get; set;}


    public void AddWorker(Spider spider)
    {
        
        workerList.Add(spider);
        spider.Working = true;
    }

    public double GetProgress()
    {
        return (100 * RemainingWorkTime / StandardWorkTime);
    }

    public void RemoveWorker(Spider spider)
    {
        workerList.Remove(spider);
        spider.Working = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Owner = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(workerList.Count != 0)
        {
            ProcessDoneWorkers();
            StorageTick();    
        }
        
        
    }

    private void StorageTick()
    {
        for(int i = 0; i <= workerList.Count - 1; i ++)
        {
            Spider currentWorker = workerList[i];
            currentWorker.StorageTime -= Time.deltaTime;
        }
    }

    private void GetResourceFromSpider(Spider s)
    {
        inventory.AddRange(s.Inventory);
        s.Inventory = new List<Resource>();
        s.InventoryFull = false;
    }

    private void ProcessDoneWorkers()
    {
        if (workerList.Count != 0)
        {
            for(int i = 0; i <= workerList.Count - 1; i ++)
            {
                Spider currentWorker = workerList[i];
                if(currentWorker.StorageTime <= 0)
                {
                    GetResourceFromSpider(currentWorker);
                    currentWorker.Objective = "Resource";
                    RemoveWorker(currentWorker);
                }

            }
        }
    }
}
