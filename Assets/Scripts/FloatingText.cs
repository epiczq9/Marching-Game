using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;
using DG.Tweening;
using TMPro;

public class FloatingText : MonoBehaviour {

    MoneyGate moneyGate;
    public Transform popupFinishPos;

    void Start() {
        moneyGate = GameObject.FindGameObjectWithTag("MoneyGate").GetComponent<MoneyGate>();
        popupFinishPos = GameObject.FindGameObjectWithTag("PopUpFinish").transform;
        PopUpMove();
    }

    private void Update() {

    }

    private void LateUpdate() {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }


    void PopUpMove() {
        Sequence popUpSequence = DOTween.Sequence();
        popUpSequence.Append(transform.DOMoveY(8.17f, 1f));
        popUpSequence.Append(transform.DOMove(popupFinishPos.position, 1f).SetEase(Ease.InCubic)).OnComplete(AddPoints);
    }

    void AddPoints() {
        DestroyText();
        moneyGate.AddPoints();
    }
    void DestroyText() {
        Destroy(gameObject);
    }

}
