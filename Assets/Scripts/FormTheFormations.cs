using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormTheFormations : MonoBehaviour
{
    List<GameObject> radialFormations;
    List<Transform> smileyTransforms;
    public GameObject army0;
    public GameObject army1;
    public GameObject army2;
    public GameObject army3;
    public GameObject army4;
    public GameObject army5;


    void Start() {

    }


    void Update() {
        
    }

    public void FormSmiley() {
        army2.GetComponent<RadialController>().ModifyForSmiley();
        army3.GetComponent<RadialController>().ModifyForSmiley();
        army4.GetComponent<RadialController>().ModifyForSmiley();
        army5.GetComponent<RadialController>().ModifyForSmiley();
    }

    public void FormStar() {
        army1.GetComponent<RadialController>().ModifyForStar();
        army2.GetComponent<RadialController>().ModifyForStar();
        army3.GetComponent<RadialController>().ModifyForStar();
        army4.GetComponent<RadialController>().ModifyForStar();
        army5.GetComponent<RadialController>().ModifyForStar();
    }

    public void FormCircles() {
        army0.GetComponent<RadialController>().ModifyForCircles();
        army1.GetComponent<RadialController>().ModifyForCircles();
        army2.GetComponent<RadialController>().ModifyForCircles();
        army3.GetComponent<RadialController>().ModifyForCircles();
        army4.GetComponent<RadialController>().ModifyForCircles();
        army5.GetComponent<RadialController>().ModifyForCircles();
    }
}
