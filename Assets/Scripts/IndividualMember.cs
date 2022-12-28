using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IndividualMember : MonoBehaviour
{
    public bool movingDown = true;
    public bool rotatedDown = false;

    GameObject exampleArmy;

    CheckMovingDown checkMD;

    void Start() {
        //  StartRotation();
    }


    void Update() {
        //LookForward();
    }

    void StartRotation() {
        //checkMD = transform.parent.GetComponent<CheckMovingDown>();
        //rotatedDown = checkMD.movingDown;
        if (rotatedDown) {
            transform.DORotate(new Vector3(0, 0, 0), 0.5f);
        } else {
            transform.DORotate(new Vector3(0, 180, 0), 0.5f);
        }
    }

    public void LookForward() {
        //exampleArmy = transform.parent.GetComponent<CheckMovingDown>().exampleArmy;
        exampleArmy = transform.parent.gameObject;
        Debug.Log(exampleArmy.transform.forward);
        Quaternion newRotation = Quaternion.LookRotation(exampleArmy.transform.forward, Vector3.up);
        transform.rotation = newRotation;
    }
}
