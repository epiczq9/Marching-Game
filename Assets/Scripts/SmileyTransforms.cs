using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyTransforms : MonoBehaviour
{
    public GameObject formation;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.position = formation.transform.position;
    }
}
