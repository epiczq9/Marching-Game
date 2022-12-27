using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickManFormation : MonoBehaviour
{
    public GameObject head;
    public GameObject chestA;
    public GameObject chestB;
    public GameObject armLeft;
    public GameObject forearmLeft;
    public GameObject armRight;
    public GameObject forearmRight;
    public GameObject legLeft;
    public GameObject shinLeft;
    public GameObject legRight;
    public GameObject shinRight;

    public Transform headTransform;
    public Transform chestATransform;
    public Transform chestBTransform;
    public Transform armLeftTransform;
    public Transform forearmLeftTransform;
    public Transform armRightTransform;
    public Transform forearmRightTransform;
    public Transform legLeftTransform;
    public Transform shinLeftTransform;
    public Transform legRightTransform;
    public Transform shinRightTransform;

    void Start() {
        
    }

    void Update() {
        
    }

    public void Phase1() {
        head.transform.DOMove(headTransform.position, 1f);
        chestA.transform.DOMove(chestATransform.position, 1f);
        chestB.transform.DOMove(chestBTransform.position, 1f);
        armLeft.transform.DOMove(armLeftTransform.position, 1f);
        forearmLeft.transform.DOMove(forearmLeftTransform.position, 1f);
        armRight.transform.DOMove(armRightTransform.position, 1f);
        forearmRight.transform.DOMove(forearmRightTransform.position, 1f);
        legLeft.transform.DOMove(legLeftTransform.position, 1f);
        shinLeft.transform.DOMove(shinLeftTransform.position, 1f);
        legRight.transform.DOMove(legRightTransform.position, 1f);
        shinRight.transform.DOMove(shinRightTransform.position, 1f);

    }
}
