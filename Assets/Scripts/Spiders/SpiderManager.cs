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

    private void ProcessKillList()
    {
        foreach (Spider s in spiderKillList)
        {
            Destroy(s.gameObject);
        }
        spiderKillList = new List<Spider>();

    }

    private void ProcessLevelUpSpiderList()
    {
        foreach(Spider s in levelUpSpiderList)
        {
            s.SpiderLevel += 1;
        }
        levelUpSpiderList = new List<Spider>();        
    }

    private void ProcessIdleSpiderList()
    {
        List<Spider> newlyActiveSpiders = new List<Spider>();
        foreach(Spider s in idleSpiderList)
        {
             string currentSpiderObjective = s.Objective;
             foreach(IWorkNode w in workNodeList)
             {
                 if (w.NodeType == currentSpiderObjective)
                 {
                     newlyActiveSpiders.Add(s);
                     break;
                 }
             }
        }
        foreach(Spider s in newlyActiveSpiders)
        {
            idleSpiderList.Remove(s);
            spiderList.Add(s);
        }

        foreach(Spider s in idleSpiderList)
        {
            s.DoIdleAnim();
        }

    }
}
