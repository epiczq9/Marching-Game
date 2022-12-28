using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappingMechanic : MonoBehaviour
{
    public float currentTimescale;
    float tapTimerCurrent = 0f;
    readonly float tapTimerMax = 1.5f;
    bool spedUp = false;

    void Start() {
        
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
                Time.timeScale *= 2f;
            }
        }
    }

    void SpeedUpCheck() {
        if (spedUp) {
            if (tapTimerCurrent < tapTimerMax) {
                tapTimerCurrent += Time.deltaTime / Time.timeScale;
            } else {
                spedUp = false;
                //exampleArmy._unitSpeed /= 2;
                Time.timeScale /= 2f;
            }
        }
    }
}
