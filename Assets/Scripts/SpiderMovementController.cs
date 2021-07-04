using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovementController : MonoBehaviour
{


    [SerializeField] Transform targetTransform;
    [SerializeField] Transform myTransform;

    [SerializeField] Rigidbody myRigidbody;

    [SerializeField] Spider mySpider;

    public Transform TargetTransform { get => targetTransform; set => targetTransform = value; }
    public Transform MyTransform { get => myTransform; set => myTransform = value; }
    public Rigidbody MyRigidbody { get => myRigidbody; set => myRigidbody = value; }
    public Spider MySpider { get => mySpider; set => mySpider = value; }

    void Awake()
    {
        mySpider = GetComponent<Spider>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void RotateAndMoveTowardsTarget()
    {
        if(targetTransform == null){return;}
        if(Vector3.Distance(MyTransform.position, TargetTransform.position) > 0)
        {
            MyTransform.LookAt(TargetTransform);
            MyRigidbody.AddRelativeForce(Vector3.forward * (float)MySpider.Speed, ForceMode.Force);
        }
    }

}
