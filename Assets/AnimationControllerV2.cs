using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerV2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Butt;
    [SerializeField] GameObject LeftFang;
    [SerializeField] GameObject RightFang;
    [SerializeField] GameObject RightLeg1;
    [SerializeField] GameObject RightLeg2;
    [SerializeField] GameObject RightLeg3;
    [SerializeField] GameObject RightLeg4;
    [SerializeField] GameObject LeftLeg1;
    [SerializeField] GameObject LeftLeg2;
    [SerializeField] GameObject LeftLeg3;
    [SerializeField] GameObject LeftLeg4;

    GameObject[,] Legs;

    [SerializeField] GameObject Target;




    void Start()
    {
        Legs = new GameObject[,] { { RightLeg1, RightLeg2, RightLeg3, RightLeg4 }, { LeftLeg1, LeftLeg2, LeftLeg3, LeftLeg4 } };
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLeg(Legs[1, 0], Target.transform.position);
        
        
    }

    [SerializeField] float RY = 0;
    [SerializeField] float RX = 0;
    [SerializeField] float EX = 0;

    public float Offset = 90;
    
    
    void UpdateLeg(GameObject Leg, Vector3 Target)
    {

        
        Vector3 LegPos = Leg.transform.position;
        Vector3 TargetVector = Target - Leg.transform.position;

        RY = -90 +Vector3.Angle(new Vector2(TargetVector.x, TargetVector.z) , new Vector2(1, 0));

        Leg.transform.localEulerAngles = new Vector3(-90,RY,0);

        RX = Offset - Vector3.Angle(new Vector2(Mathf.Sqrt(TargetVector.x* TargetVector.x+ TargetVector.z* TargetVector.z), TargetVector.y), new Vector2(0, 1));

     

        Leg.transform.localEulerAngles = new Vector3(-90 + RX -EX, RY, 0);

        Leg.transform.GetChild(0).localEulerAngles = new Vector3( EX, 0, 0);

        Leg.transform.GetChild(0).GetChild(0).localEulerAngles = new Vector3(EX, 0, 0);


    }


}
