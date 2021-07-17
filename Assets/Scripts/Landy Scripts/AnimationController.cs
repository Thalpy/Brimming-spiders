using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Butt;
    public GameObject LeftFang;
    public GameObject RightFang;
    public GameObject RightLeg1;
    public GameObject RightLeg2;
    public GameObject RightLeg3;
    public GameObject RightLeg4;
    public GameObject LeftLeg1;
    public GameObject LeftLeg2;
    public GameObject LeftLeg3;
    public GameObject LeftLeg4;
    
    GameObject[,] Legs;

    [SerializeField] float[] LegMagnitude = { 0, 0, 0, 0 };
    public float LegR1 = 35f;
    public float LegR2 = 40f;
    public float LegR3 = 40f;
    
    void Start()
    {
        Legs = new GameObject[,] { { RightLeg1, RightLeg2, RightLeg3, RightLeg4 }, { LeftLeg1, LeftLeg2, LeftLeg3, LeftLeg4 } };
        



    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= 3; i++)
        {
            Legs[1, i].transform.localEulerAngles = new Vector3(LegR1+45f, LegR2, LegR3 * 1.5f - LegR3 * i);
            Legs[1, i].transform.GetChild(0).localEulerAngles = new Vector3(LegR1 * 1.5f, 0, 0);
            Legs[1, i].transform.GetChild(0).GetChild(0).localEulerAngles = new Vector3(LegR1 * 2f, 0, 0);
            LegMagnitude[i] = Vector3.Distance(Legs[1, i].transform.position, Legs[1, i].transform.GetChild(0).GetChild(0).GetChild(0).position);

        }



        for (int i = 0; i <= 3; i++)
        {
            Legs[0, i].transform.localEulerAngles = new Vector3(-LegR1, LegR1 - i * LegR1 / 3f * 2f, 0);
            Legs[0, i].transform.GetChild(0).localEulerAngles = new Vector3(LegR1 * 1.5f, 0, 0);
            Legs[0, i].transform.GetChild(0).GetChild(0).localEulerAngles = new Vector3(LegR1 * 2f, 0, 0);
        }
    }
}
