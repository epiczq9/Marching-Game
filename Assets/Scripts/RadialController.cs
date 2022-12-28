using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadialController : MonoBehaviour
{
    RadialFormation radialFormation;

    public int baseAmount;
    public float baseRadius;
    public int baseRings;
    public float baseRotations;

    public int smileyAmount;
    public float smileyRadius;
    public int smileyRings;
    public float smileyRotations;
    public Transform basePosition;
    public Transform smileyPosition;
    float timerCurrent = 0;
    float timerMax = 4f;
    float lerpValue = 0f;
    bool moveToSmiley = false;
    bool moveToBase = false;
    bool smileyMode = false;

    void Start() {
        radialFormation = GetComponent<RadialFormation>();
        SaveBaseValues();

    }

    private void Update() {
        if (moveToSmiley) {
            if(timerCurrent < timerMax) {
                Debug.Log("TIMER CURRENT: " + timerCurrent);
                lerpValue = timerCurrent / timerMax;

                Debug.Log("LERP CURRENT: " + lerpValue);
                transform.position = Vector3.Lerp(basePosition.position, smileyPosition.position, lerpValue);
                timerCurrent += Time.deltaTime / Time.timeScale;
            } else {
                moveToSmiley = false;
                timerCurrent = 0f;
            }
        }

        if (moveToBase) {
            if (timerCurrent < timerMax) {
                Debug.Log("TIMER CURRENT: " + timerCurrent);
                lerpValue = timerCurrent / timerMax;

                Debug.Log("LERP CURRENT: " + lerpValue);
                transform.position = Vector3.Lerp(smileyPosition.position, basePosition.position, lerpValue);
                timerCurrent += Time.deltaTime / Time.timeScale;
            } else {
                moveToBase = false;
                timerCurrent = 0f;
            }
        }
    }

    void SaveBaseValues() {
        //basePosition.position = transform.position;
        baseAmount = radialFormation._amount;
        baseRadius = radialFormation._radius;
        baseRings = radialFormation._rings;
        baseRotations = radialFormation._rotations;
}

    public void ModifyAmount(int i) {
        radialFormation._amount = i;
    }

    public void ModifyRadius(float i) {
        radialFormation._radius = i;

    }

    public void ModifyRadiusGrowthMultiplier(float i) {
        radialFormation._radiusGrowthMultiplier = i;

    }

    public void ModifyRotations(float i) {
        radialFormation._rotations = i;

    }

    public void ModifyRings(int i) {
        radialFormation._rings = i;

    }

    public void ModifyRingOffset(float i) {
        radialFormation._rotations = i;

    }

    public void ModifyForSmiley() {
        Debug.Log("ENTERED MOD");
        if (!smileyMode) {
            radialFormation._amount = smileyAmount;
            radialFormation._radius = smileyRadius;
            radialFormation._rings = smileyRings;
            radialFormation._rotations = smileyRotations;
            //transform.DOMove(smileyPosition.position, 10f);
            moveToSmiley = true;
            smileyMode = true;
            Debug.Log("SMILEY MOD");
        } else {
            radialFormation._amount = baseAmount;
            radialFormation._radius = baseRadius;
            radialFormation._rings = baseRings;
            radialFormation._rotations = baseRotations;
            //transform.DOMove(smileyPosition.position, 10f);
            moveToBase = true;
            smileyMode = false;

            Debug.Log("BASIC MOD");
        }
    }
}