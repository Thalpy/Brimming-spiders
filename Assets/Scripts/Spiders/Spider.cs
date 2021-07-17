using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spider : StateMachine
{
    [SerializeField] private int spiderLevel;
    [SerializeField] private int maxInventorySize;
    [SerializeField] private double speed;
    [SerializeField] private bool working;
    [SerializeField] private bool inventoryFull;
    [SerializeField] private List<Resource> inventory;

    [SerializeField] private string id;

    [SerializeField] IWorkNode workNode;

    [SerializeField] double storageTime = 2.0;

    [SerializeField] private string objective;

    public SpiderMovementController spiderMovementController;

    public SpiderObjectiveFinder spiderObjectiveFinder;

    SphereCollider myCollider;

    // Start is called before the first frame update
    public int SpiderLevel { get => spiderLevel; set => spiderLevel = value; }

    public int MaxInventorySize { get => maxInventorySize; set => maxInventorySize = value; }

    public double Speed { get => speed; set => speed = value; }

    public bool Working { get => working; set => working = value; }

    public bool InventoryFull { get => inventoryFull; set => inventoryFull = value; }

    public List<Resource> Inventory { get => inventory; set => inventory = value; }
    public string Objective { get => objective; set => objective = value; }
    public double StorageTime { get => storageTime; set => storageTime = value; }
    public string Id { get => id; set => id = value; }


    void Start()
    {
        speed = 1;
        spiderObjectiveFinder = new SpiderObjectiveFinder();
        spiderMovementController = GetComponent<SpiderMovementController>();
        id = Guid.NewGuid().ToString();
        SetState(new Begin(this));

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddResourceToInventory(Resource r)
    {
        Inventory.Add(r);
        if (Inventory.Count == maxInventorySize)
        {
            InventoryFull = true;
        }
    }

    public Resource GetResourceFromInventory()
    {
        Resource currentResource = Inventory[0];
        Inventory.RemoveAt(0);
        return currentResource;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Resource")        
        {
            Debug.Log("Hey this is a Resource!");
            workNode =  collision.gameObject.GetComponent<IWorkNode>();
            workNode.AddWorker(this);
        }
        if (collision.gameObject.tag == "Store")        
        {
            Debug.Log("Hey this is a Store!");
            workNode =  collision.gameObject.GetComponent<IWorkNode>();
            workNode.AddWorker(this);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<IWorkNode>() == workNode)
        {
            Debug.Log("Now leaving the work node...");
            workNode.RemoveWorker(this);
            working = false;

        }
    }

    public void DoIdleAnim()
    {
        Debug.Log("Idle animation is not yet implemented!");
    }

    public void DoWorkingAnim()
    {
        Debug.Log("Working animation is not yet implemented!");
    }


    
}
