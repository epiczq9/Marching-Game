using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public int addMemberPrice = 0;
    public int addRowPrice = 0;
    public int increaseSpeedPrice = 0;
    public int formationPrice = 0;

    public Text formationPriceText;
    public Text addRowPriceText;
    public Text increaseSpeedPriceText;
    public Text addMemberPriceText;
    public Text moneyText;

    public SpawnController spawnController;
    public GameController gameController;
    public FormTheFormations theFormations;
    private void Start() {
        UpdateText();
    }

    private void Update() {
        
    }
    public void FormationButton() {
        if (spawnController.AreMembersFull()) {
            spawnController.inBase = false;
            if (spawnController.activeRows == 4) {
                theFormations.FormSmiley();
            } else if (spawnController.activeRows == 5) {
                theFormations.FormStar();
            } else if (spawnController.AreRowsFull()) {
                theFormations.FormCircles();
            }
        }
        gameController.money -= formationPrice;
        formationPrice = (int)(formationPrice * 1.3f);
        UpdateText();
    }

    public void StarFormationButton() {
        theFormations.FormStar();
        gameController.money -= formationPrice;
        formationPrice = (int)(formationPrice * 1.3f);
        UpdateText();
    }

    public void AddRowButton() {
        spawnController.SpawnRow();
        gameController.money -= addRowPrice;
        addRowPrice = (int)(addRowPrice * 1.2f);
        UpdateText();
    }

    public void IncreaseSpeedButton() {
        Time.timeScale *= 2f;
        gameController.money -= increaseSpeedPrice;
        increaseSpeedPrice = (int)(increaseSpeedPrice * 2f);
        UpdateText();
    }
    public void AddMemberButton() {
        spawnController.SpawnMember();
        gameController.money -= addMemberPrice;
        addMemberPrice = (int)(addMemberPrice * 1.2f);
        UpdateText();
    }



    public void UpdateText() {
        if (spawnController.AreRowsFull()) {
            addRowPriceText.text = "MAX";
        } else {
            addRowPriceText.text = addRowPrice.ToString();
        }

        if (spawnController.AreMembersFull()) {
            addMemberPriceText.text = "MAX";
        } else {
            addMemberPriceText.text = addMemberPrice.ToString();
        }

        increaseSpeedPriceText.text = increaseSpeedPrice.ToString();
        formationPriceText.text = formationPrice.ToString();
        moneyText.text = gameController.money.ToString();
    }
}
