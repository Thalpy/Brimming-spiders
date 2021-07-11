using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : MonoBehaviour, IWorkerManager
{


    [SerializeField] List<Spider> spiderList;

    [SerializeField] List<Spider> spiderKillList;

    [SerializeField] List<Spider> idleSpiderList;

    [SerializeField] List<Spider> levelUpSpiderList;
    [SerializeField] List<IWorkNode> workNodeList;

   
    private Spider currentSpider;
    private Resource[] resourceNodes;
    
    public List<IWorkNode> WorkNodeList { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public List<Spider> IdleSpiderList { get => idleSpiderList; set => idleSpiderList = value; }

    public void AddSpider()
    {
        throw new System.NotImplementedException();
    }

    public void FeedSpider(string uuid, Resource food)
    {
        throw new System.NotImplementedException();
    }

    public Spider GetSpider(string id)
    {
        Spider result = null;
        foreach(Spider s in spiderList)
        {
            if (s.Id == id) {result = s;}
        }
        return result;
    }

    public void KillSpider(string uuid)
    {
        Spider target = GetSpider(uuid);
        spiderKillList.Add(target); 
        spiderList.Remove(target);
    }

    public void LevelUpSpider(string uuid)
    {
        throw new System.NotImplementedException();
    }
}
