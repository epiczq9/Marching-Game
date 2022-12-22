using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IndividualMember : MonoBehaviour
{
    public bool movingDown = true;
    Movement radialMovement;
    bool rotatedDown = false;


    void Start() {
        if (rotatedDown) {
            transform.DORotate(new Vector3(0, 0, 0), 0.5f);
        } else {
            transform.DORotate(new Vector3(0, 180, 0), 0.5f);
        }
        radialMovement = GameObject.FindGameObjectWithTag("RadialArmy").GetComponent<Movement>();
    }


    void Update() {
        if (radialMovement.movingDown) {
            if (!rotatedDown) {
                transform.DORotate(new Vector3(0, 0, 0), 0.5f);
                rotatedDown = true;
            }
        } else {
            if (rotatedDown) {
                transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                rotatedDown = false;
            }
            
        }
    }
}
