using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour
{
    public GameObject formationButton;
    public GameObject addRowButton;
    public GameObject increaseSpeedButton;
    public GameObject addMemberButton;

    ButtonBehaviour buttonBehaviour;
    GameController gameController;
    SpawnController spawnController;

    void Start() {
        buttonBehaviour = GetComponent<ButtonBehaviour>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawnController = GameObject.FindGameObjectWithTag("SpawnController").GetComponent<SpawnController>();
    }

    
    void Update() {
        SetupFormationButton();
        SetupAddRowButton();
        SetupSpeedButton();
        SetupAddMemberButton();
    }

    void ActivateButton(GameObject buttonObj) {
        buttonObj.GetComponent<Button>().interactable = true;
    }

    void DeactivateButton(GameObject buttonObj) {
        buttonObj.GetComponent<Button>().interactable = false;
    }

    void SetupFormationButton() {
        if (gameController.money >= buttonBehaviour.formationPrice && spawnController.activeRows >= 4 && spawnController.AreMembersFull() && spawnController.inBase) {
            ActivateButton(formationButton);
        } else {
            DeactivateButton(formationButton);
        }
    }

    void SetupAddRowButton() {
        if (gameController.money >= buttonBehaviour.addRowPrice && spawnController.inBase && !spawnController.AreRowsFull()) {
            ActivateButton(addRowButton);
        } else {
            DeactivateButton(addRowButton);
        }
    }

    void SetupSpeedButton() {
        if (gameController.money >= buttonBehaviour.increaseSpeedPrice && spawnController.inBase) {
            ActivateButton(increaseSpeedButton);
        } else {
            DeactivateButton(increaseSpeedButton);
        }
    }

    void SetupAddMemberButton() {
        if (gameController.money >= buttonBehaviour.addMemberPrice && spawnController.inBase && !spawnController.AreMembersFull()) {
            ActivateButton(addMemberButton);
        } else {
            DeactivateButton(addMemberButton);
        }
    }
}
