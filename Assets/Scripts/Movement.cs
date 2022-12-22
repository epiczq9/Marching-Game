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

    float timeToMove = 5f;
    public bool movingDown = true;

    ExampleArmy exampleArmy;

    float tapTimerCurrent = 0;
    float tapTimerMax = 2f;
    bool spedUp = false;

    void Start() {
        exampleArmy = GetComponent<ExampleArmy>();
        TimersManager.SetTimer(this, 0.1f, StartGame);
    }

    void Update() {
        TapCheck();

        SpeedUpCheck();
    }

    void TapCheck() {
        if (Input.GetButtonDown("Fire1")) {
            tapTimerCurrent = 0;
            if (!spedUp) {
                spedUp = true;
                //exampleArmy._unitSpeed *= 2;
                Time.timeScale *= 2;
            }
        }
    }

    void SpeedUpCheck() {
        if (spedUp) {
            if (tapTimerCurrent < tapTimerMax) {
                tapTimerCurrent += Time.deltaTime;
            } else {
                spedUp = false;
                //exampleArmy._unitSpeed /= 2;
                Time.timeScale /= 2;
            }
        }
    }

    void StartGame() {
        unitParent = GameObject.FindGameObjectWithTag("UnitParent").transform;
        MoveDown();
    }

    void MoveDown() {
        movingDown = true;
        transform.DOMove(lowerPos.position, timeToMove).SetEase(Ease.Linear).OnComplete(MoveUp);
    }

    void MoveUp() {
        movingDown = false;
        transform.DOMove(upperPos.position, timeToMove).SetEase(Ease.Linear).OnComplete(MoveDown);
    }

    void RotateAllMembersUp() {
        foreach (Transform bandMember in unitParent) {
            bandMember.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
        }
    }

    void RotateAllMembersDown() {
        
    }
}
