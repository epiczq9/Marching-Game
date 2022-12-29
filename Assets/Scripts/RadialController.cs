using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadialController : MonoBehaviour {
    RadialFormation radialFormation;
    SpawnController spawnController;

    public int baseAmount;
    public float baseRadius;
    public int baseRings;
    public float baseRotations;

    public int smileyAmount;
    public float smileyRadius;
    public int smileyRings;
    public float smileyRotations;

    public int circleAmount;
    public float circleRadius;
    public int circleRings;
    public float circleRotations;

    public Transform basePosition;
    public Transform smileyPosition;
    public Transform starPosition;
    public Transform circlePosition;

    float timerCurrent = 0;
    float timerMax = 4f;
    float lerpValue = 0f;
    float formationTimer = 15f;

    bool moveToSmiley = false;
    bool moveToStar = false;
    bool moveToCircle = false;
    bool moveToBase = false;

    bool smileyMode = false;
    bool starMode = false;
    bool circleMode = false;

    void Start() {
        radialFormation = GetComponent<RadialFormation>();
        spawnController = GameObject.FindGameObjectWithTag("SpawnController").GetComponent<SpawnController>();
        SaveBaseValues();

    }

    private void Update() {
        if (moveToSmiley) {
            if (timerCurrent < timerMax) {
                Debug.Log("TIMER CURRENT: " + timerCurrent);
                lerpValue = timerCurrent / timerMax;

                Debug.Log("LERP CURRENT: " + lerpValue);
                transform.position = Vector3.Lerp(basePosition.position, smileyPosition.position, lerpValue);
                timerCurrent += Time.deltaTime / Time.timeScale;
            } else {
                transform.position = smileyPosition.position;
                moveToSmiley = false;
                timerCurrent = 0f;
                Timers.TimersManager.SetTimer(this, formationTimer / Time.timeScale, ReturnToBase);
            }
        }

        if (moveToStar) {
            if (timerCurrent < timerMax) {
                Debug.Log("TIMER CURRENT: " + timerCurrent);
                lerpValue = timerCurrent / timerMax;

                Debug.Log("LERP CURRENT: " + lerpValue);
                transform.position = Vector3.Lerp(basePosition.position, starPosition.position, lerpValue);
                transform.eulerAngles = Vector3.Lerp(basePosition.eulerAngles, starPosition.eulerAngles, lerpValue);
                timerCurrent += Time.deltaTime / Time.timeScale;
            } else {
                starMode = true;
                transform.position = starPosition.position;
                transform.eulerAngles = starPosition.eulerAngles;
                moveToStar = false;
                timerCurrent = 0f;
                Timers.TimersManager.SetTimer(this, formationTimer / Time.timeScale, ReturnToBase);
            }
        }

        if (moveToCircle) {
            if (timerCurrent < timerMax) {
                Debug.Log("TIMER CURRENT: " + timerCurrent);
                lerpValue = timerCurrent / timerMax;

                Debug.Log("LERP CURRENT: " + lerpValue);
                transform.position = Vector3.Lerp(basePosition.position, circlePosition.position, lerpValue);
                timerCurrent += Time.deltaTime / Time.timeScale;
            } else {
                transform.position = circlePosition.position;
                moveToCircle = false;
                timerCurrent = 0f;
                Timers.TimersManager.SetTimer(this, formationTimer / Time.timeScale, ReturnToBase);
            }
        }

        if (moveToBase) {
            if (timerCurrent < timerMax) {
                Debug.Log("TIMER CURRENT: " + timerCurrent);
                lerpValue = timerCurrent / timerMax;

                Debug.Log("LERP CURRENT: " + lerpValue);
                if (smileyMode) {
                    transform.position = Vector3.Lerp(smileyPosition.position, basePosition.position, lerpValue);
                } else if (starMode) {
                    transform.position = Vector3.Lerp(starPosition.position, basePosition.position, lerpValue);
                    transform.eulerAngles = Vector3.Lerp(starPosition.eulerAngles, basePosition.eulerAngles, lerpValue);
                } else if (circleMode) {
                    transform.position = Vector3.Lerp(circlePosition.position, basePosition.position, lerpValue);
                }
                timerCurrent += Time.deltaTime / Time.timeScale;
            } else {
                transform.position = basePosition.position;
                transform.eulerAngles = basePosition.eulerAngles;
                if (!GetComponent<ExampleArmy>().enabled) {
                    GetComponent<ExampleArmy>().enabled = true;
                }
                moveToBase = false;
                timerCurrent = 0f;
                smileyMode = false;
                starMode = false;
                circleMode = false;
                spawnController.inBase = true;
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

    void ReturnToBase() {
        radialFormation._amount = baseAmount;
        radialFormation._radius = baseRadius;
        radialFormation._rings = baseRings;
        radialFormation._rotations = baseRotations;
        moveToBase = true;
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
        } /*else {
            radialFormation._amount = baseAmount;
            radialFormation._radius = baseRadius;
            radialFormation._rings = baseRings;
            radialFormation._rotations = baseRotations;
            //transform.DOMove(smileyPosition.position, 10f);
            moveToBase = true;
            //smileyMode = false;

            Debug.Log("BASIC MOD");
        }*/
    }

    public void ModifyForStar() {
        Debug.Log("ENTERED STAR");
        if (!starMode) {
            GetComponent<ExampleArmy>().enabled = false;
            //transform.DOMove(smileyPosition.position, 10f);
            moveToStar = true;
            starMode = true;
            Debug.Log("STAR MOD");
        } /*else {
            //GetComponent<ExampleArmy>().enabled = true;
            //transform.DOMove(smileyPosition.position, 10f);
            moveToBase = true;

            Debug.Log("BASIC MOD");
        }*/
    }

    public void ModifyForCircles() {
        if (!circleMode) {
            radialFormation._amount = circleAmount;
            radialFormation._radius = circleRadius;
            radialFormation._rings = circleRings;
            radialFormation._rotations = circleRotations;
            //transform.DOMove(smileyPosition.position, 10f);
            moveToCircle = true;
            circleMode = true;

            Debug.Log("CIRCLE MOD");
        } /*else {
            radialFormation._amount = baseAmount;
            radialFormation._radius = baseRadius;
            radialFormation._rings = baseRings;
            radialFormation._rotations = baseRotations;
            //transform.DOMove(smileyPosition.position, 10f);
            moveToBase = true;
            //smileyMode = false;

            Debug.Log("BASIC MOD");
        }*/
    }
}