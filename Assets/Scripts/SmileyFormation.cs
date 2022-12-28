using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyFormation : MonoBehaviour
{
    List<GameObject> radialFormations;
    List<Transform> smileyTransforms;
    public GameObject bigCircle;
    public GameObject eyeLeft;
    public GameObject eyeRight;
    public GameObject smile;

    void Start() {

    }


    void Update() {
        
    }

    public void FormSmiley() {
        bigCircle.GetComponent<RadialController>().ModifyForSmiley();
        eyeLeft.GetComponent<RadialController>().ModifyForSmiley();
        eyeRight.GetComponent<RadialController>().ModifyForSmiley();
        smile.GetComponent<RadialController>().ModifyForSmiley();
}
}
