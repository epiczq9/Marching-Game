using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Timers;

public class Movement : MonoBehaviour
{
    public Transform lowerPos;
    public Transform upperPos;
    Transform unitParent;
    public List<GameObject> bandMemberList;

    float timeToMove = 10f;
    public bool movingDown = true;
    bool rotatedDown = true;

    ExampleArmy exampleArmy;

    float tapTimerCurrent = 0;
    float tapTimerMax = 2f;
    bool spedUp = false;

    void Start() {
        exampleArmy = GetComponent<ExampleArmy>();
        TimersManager.SetTimer(this, 0.1f, StartGame);


    }

    void Update() {
        //RotationCheck();
    }


    void RotationStart() {
        if (movingDown) {
            foreach (Transform member in exampleArmy._parent) {
                member.DORotate(new Vector3(0, 0, 0), 0.5f);
                member.GetComponent<IndividualMember>().rotatedDown = true;
            }
        } else {
            foreach (Transform member in exampleArmy._parent) {
                member.DORotate(new Vector3(0, 180, 0), 0.5f);
                member.GetComponent<IndividualMember>().rotatedDown = false;
            }
        }
    }

    void RotationCheck() {
        if (movingDown) {
            foreach (Transform member in exampleArmy._parent) {
                if (!member.GetComponent<IndividualMember>().rotatedDown) {
                    //Debug.Log("Rotate Down");
                    member.DORotate(new Vector3(0, 0, 0), 0.5f);
                    member.GetComponent<IndividualMember>().rotatedDown = true;
                }
            }
        } else {
            foreach (Transform member in exampleArmy._parent) {
                if (member.GetComponent<IndividualMember>().rotatedDown) {
                    member.DORotate(new Vector3(0, 180, 0), 0.5f);
                    member.GetComponent<IndividualMember>().rotatedDown = false;
                }
            }
        }
    }

    void StartGame() {
        RotationStart();
        unitParent = GameObject.FindGameObjectWithTag("UnitParent").transform;
        if (movingDown) {
            MoveDown();
        } else {
            MoveUp();
        }
    }

    void MoveDown() {
        movingDown = true;
        transform.DOMove(lowerPos.position, timeToMove).SetEase(Ease.Linear).OnComplete(MoveUp);
    }

    void MoveUp() {
        movingDown = false; 
        transform.DOMove(upperPos.position, timeToMove).SetEase(Ease.Linear).OnComplete(MoveDown);
    }
}
