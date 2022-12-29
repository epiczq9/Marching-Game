using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFormation : MonoBehaviour
{
    public GameObject peakLeft;
    public GameObject peakRight;
    public GameObject middle;
    public GameObject XLeft;
    public GameObject XRight;

    void Start() {

    }


    void Update() {

    }

    public void FormSmiley() {
        peakLeft.GetComponent<RadialController>().ModifyForStar();
        peakRight.GetComponent<RadialController>().ModifyForStar();
        middle.GetComponent<RadialController>().ModifyForStar();
        XLeft.GetComponent<RadialController>().ModifyForStar();
        XRight.GetComponent<RadialController>().ModifyForStar();
    }
}
