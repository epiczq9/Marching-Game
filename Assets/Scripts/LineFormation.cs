using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineFormation : MonoBehaviour
{
    public Transform newPosition;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Phase1() {
        transform.DOMove(newPosition.position, 10f);
    }
}
