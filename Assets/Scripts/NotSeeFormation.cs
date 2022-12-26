using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Timers;

public class NotSeeFormation : MonoBehaviour {
    public GameObject line0;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;
    public GameObject line5;
    public RadialFormation radialFormation;

    public Transform line0Pos;
    public Transform line1Pos;
    public Transform line2Pos;
    public Transform line3Pos;
    public Transform line4Pos;
    public Transform line5Pos;

    public Transform wholePos;

    void Start() {
        TimersManager.SetTimer(this, 2f, StartFormation);
    }

    void Update() {

    }

    void StartFormation() {
        radialFormation._radius = 300;
        TimersManager.SetTimer(this, 3f, Phase1);
    }

    void Phase1() {
        line0.transform.DOMove(line0Pos.position, 7f);
        line1.transform.DOMove(line1Pos.position, 7f).OnComplete(Phase2);
    }

    void Phase2() {
        line2.transform.DOMove(line2Pos.position, 7f);
        line3.transform.DOMove(line3Pos.position, 7f);
        line4.transform.DOMove(line4Pos.position, 7f);
        line5.transform.DOMove(line5Pos.position, 7f).OnComplete(Phase3);
    }

    void Phase3() {
        radialFormation._radius = 100;
        TimersManager.SetTimer(this, 5f, Phase4);
    }

    void Phase4() {
        transform.DOMove(wholePos.position, 5f).OnComplete(Phase5);
        transform.DORotate(new Vector3(0, 180, 0), 20f);
        CircleWide();
    }

    void Phase5() {
        transform.DOMove(Vector3.zero, 10f);
    }

    void CircleWide() {
        radialFormation.gameObject.GetComponent<ExampleArmy>()._unitSpeed = 3f;
        radialFormation._radius = 105;
        TimersManager.SetTimer(this, 0.5f, CircleThin);
    }

    void CircleThin() {
        radialFormation._radius = 100;
        TimersManager.SetTimer(this, 0.5f, CircleWide);
    }
}
