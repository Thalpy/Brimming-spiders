using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpiderObjectiveFinder 
{
    [SerializeField] string objective;

    [SerializeField] List<Transform> targets;

    public string Objective { get => objective; set => objective = value; }



    private void FindObjectivesInRadius(Transform spiderCenter)
    {
        //cast out a virtual sphere collider
        //for each collider, see if it was a matching objective
        //if it was then return the related transform
        targets = new List<Transform>();
        Collider[] detectedColliders = Physics.OverlapSphere(spiderCenter.position, 100f);
        foreach (var detectedCollider in detectedColliders)
        {
            if (detectedCollider.gameObject.tag == objective)
            {
                Transform targetTransform = detectedCollider.gameObject.GetComponent<Transform>();
                targets.Add(targetTransform);
            }
        }
    }

    private Transform GetNearestObjective(Transform spiderCenter)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = spiderCenter.position;
        foreach(Transform potentialTarget in targets)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;

    }

    public Transform GetObjectiveTransform(Transform spiderCenter)
    {
        FindObjectivesInRadius(spiderCenter);
        return GetNearestObjective(spiderCenter);
    }
}

