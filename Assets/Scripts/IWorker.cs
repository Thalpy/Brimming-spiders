using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IWorker
{
    int MaxInventorySize {get; set;}
    double Speed {get; set;}
    bool Working {get; set;}
    bool InventoryFull {get; set;}
    List<Resource> Inventory {get; set;}
    string Objective {get; set;}
    void AddResourceToInventory(Resource r);
    Resource GetResourceFromInventory();

}