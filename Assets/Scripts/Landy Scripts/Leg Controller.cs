using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
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
    

    }
}
