using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialController : MonoBehaviour
{
    RadialFormation radialFormation;
    

    void Start() {
        radialFormation = GetComponent<RadialFormation>();
    }

    
    
    public void ModifyAmount(int i) {
        radialFormation._amount += i;
    }

    public void ModifyRadius(int i) {
        radialFormation._radius += i;

    }

    public void ModifyRadiusGrowthMultiplier(int i) {
        radialFormation._radiusGrowthMultiplier += i;

    }

    public void ModifyRotations(int i) {
        radialFormation._rotations += i;

    }

    public void ModifyRings(int i) {
        radialFormation._rings += i;

    }

    public void ModifyRingOffset(int i) {
        radialFormation._rotations += i;

    }
}