using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    BoxFormation boxFormation;
    void Start() {
        boxFormation = GetComponent<BoxFormation>();
    }


    void Update() {
        
    }

    public void IncreaseUnitWidth() {
        boxFormation._unitWidth++;
    }
    public void IncreaseUnitDepth() {
        boxFormation._unitDepth++;
    }
    public void DecreaseUnitWidth() {
        boxFormation._unitWidth--;
    }
    public void DecreaseUnitDepth() {
        boxFormation._unitDepth--;
    }
}
