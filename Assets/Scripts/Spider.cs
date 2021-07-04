using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private int spiderLevel;
    [SerializeField] private int maxInventorySize;
    [SerializeField] private double speed;
    [SerializeField] private bool working;
    [SerializeField] private bool inventoryFull;
    [SerializeField] private List<Resource> inventory;

    [SerializeField] IWorkNode workNode;

    [SerializeField] private string objective;

    [SerializeField] SpiderMovementController spiderMovementController;

    [SerializeField] SpiderObjectiveFinder spiderObjectiveFinder;

    SphereCollider myCollider;

    // Start is called before the first frame update
    public int SpiderLevel { get => spiderLevel; set => spiderLevel = value; }

    public int MaxInventorySize { get => maxInventorySize; set => maxInventorySize = value; }

    public double Speed { get => speed; set => speed = value; }

    public bool Working { get => working; set => working = value; }

    public bool InventoryFull { get => inventoryFull; set => inventoryFull = value; }

    public List<Resource> Inventory { get => inventory; set => inventory = value; }
    public string Objective { get => objective; set => objective = value; }

    void Start()
    {
        speed = 1.0;
        spiderObjectiveFinder = new SpiderObjectiveFinder();
        spiderMovementController = GetComponent<SpiderMovementController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (working == false)
        {
            spiderObjectiveFinder.Objective = objective;
            Transform targetTransform = spiderObjectiveFinder.GetObjectiveTransform(GetComponent<Transform>());
            spiderMovementController.TargetTransform = targetTransform;
            spiderMovementController.RotateAndMoveTowardsTarget();

        }
        if(inventory.Count == MaxInventorySize)
        {
            inventoryFull = true;
        }

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
    }

    
}
