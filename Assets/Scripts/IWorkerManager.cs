using System.Collections.Generic;

interface IWorkerManager
{
    Spider GetSpider(string id);

    List<IWorkNode> WorkNodeList {get; set;}

    void AddSpider();

    void LevelUpSpider(string uuid);

    void FeedSpider(string uuid, Resource food);

    void KillSpider(string uuid);    


}