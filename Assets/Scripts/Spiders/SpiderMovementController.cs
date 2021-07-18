using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMovementController : MonoBehaviour
{


    [SerializeField] Transform targetTransform;
    [SerializeField] Transform myTransform;

    [SerializeField] Rigidbody myRigidbody;

    [SerializeField] Spider mySpider;

    [SerializeField] bool atTarget;

    public NavMeshAgent agent;

    public Transform TargetTransform { get => targetTransform; set => targetTransform = value; }
    public Transform MyTransform { get => myTransform; set => myTransform = value; }
    public Rigidbody MyRigidbody { get => myRigidbody; set => myRigidbody = value; }
    public Spider MySpider { get => mySpider; set => mySpider = value; }
    public bool AtTarget { get => atTarget; set => atTarget = value; }

    void Awake()
    {
        mySpider = GetComponent<Spider>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    public void RotateAndMoveTowardsTarget()
    {
        if(targetTransform == null){return;}
        if(Vector3.Distance(MyTransform.position, TargetTransform.position) > 0)
        {
            agent.destination = TargetTransform.position;
        }

    }

    public void MoveTowardsPosition(Vector3 pos)
    {
        if(pos == null){return;}
        if(Vector3.Distance(MyTransform.position, pos) > 0)
        {
            agent.destination = pos;
        }
    }


    #region deprecated
    /*
    public void RotateAndMoveTowardsTarget()
    {
        if(targetTransform == null){return;}
        if(Vector3.Distance(MyTransform.position, TargetTransform.position) > 0)
        {
            MyTransform.LookAt(TargetTransform);
            MyRigidbody.AddRelativeForce(Vector3.forward * (float)MySpider.Speed, ForceMode.Force);
        }
        else
        {
            MyRigidbody.velocity = Vector3.zero;
        }        
        
    }

    */

    #endregion

}
