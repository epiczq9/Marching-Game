using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Timers;
public class MovementLine : MonoBehaviour
{
    public Transform lowerPos;
    public Transform upperPos;
    Transform unitParent;
    public List<GameObject> bandMemberList;

    float timeToMove = 10f;
    public bool movingDown = true;
    //bool rotatedDown = true;

    SpawnBetweenPoints theLine;

    public bool formationSelected = false;

    void Start() {
        theLine = GetComponent<SpawnBetweenPoints>();
        TimersManager.SetTimer(this, 0.1f, StartGame);
    }

    void Update() {
        RotationCheck();
    }


    void RotationStart() {
        if (movingDown) {
            foreach (GameObject member in theLine.membersList) {
                member.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
                member.GetComponent<IndividualMember>().rotatedDown = true;
            }
        } else {
            foreach (GameObject member in theLine.membersList) {
                member.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                member.GetComponent<IndividualMember>().rotatedDown = false;
            }
        }
    }

    void RotationCheck() {
        if (movingDown) {
            foreach (GameObject member in theLine.membersList) {
                if (!member.GetComponent<IndividualMember>().rotatedDown) {
                    //Debug.Log("Rotate Down");
                    member.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
                    member.GetComponent<IndividualMember>().rotatedDown = true;
                }
            }
        } else {
            foreach (GameObject member in theLine.membersList) {
                if (member.GetComponent<IndividualMember>().rotatedDown) {
                    member.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                    member.GetComponent<IndividualMember>().rotatedDown = false;
                }
            }
        }
    }

    public void StartFormation() {
        formationSelected = true;
    }

    void StartGame() {
        RotationStart();
        if (movingDown) {
            MoveDown();
        } else {
            MoveUp();
        }
    }

    void MoveDown() {
        movingDown = true;
        transform.DOMove(lowerPos.position, timeToMove).SetEase(Ease.Linear).OnComplete(FinishedDown);
    }

    void FinishedDown() {
        if (formationSelected) {
            GetComponent<LineFormation>().Phase1();
        } else {
            MoveUp();
        }
    }

    void MoveUp() {
        movingDown = false;
        transform.DOMove(upperPos.position, timeToMove).SetEase(Ease.Linear).OnComplete(FinishedUp);
    }

    void FinishedUp() {
        if (formationSelected) {
            GetComponent<LineFormation>().Phase1();
        } else {
            MoveDown();
        }
    }
}
