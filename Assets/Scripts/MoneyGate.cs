using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGate : MonoBehaviour
{
    GameController gameController;
    ButtonBehaviour buttonBehaviour;
    public List<GameObject> cheerleadersList;
    int money;

    private void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        buttonBehaviour = GameObject.FindGameObjectWithTag("ButtonBehaviour").GetComponent<ButtonBehaviour>();
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        money = other.gameObject.GetComponent<MemberWorth>().worth;
        //buttonBehaviour.UpdateText();
        other.gameObject.GetComponent<UISpawn>().SpawnPointUI();
        foreach (GameObject cheerleader in cheerleadersList) {
            cheerleader.GetComponent<CheerleaderBehaviour>().Cheer();
        }
    }

    public void AddPoints() {
        gameController.money += money;
        buttonBehaviour.UpdateText();
    }


}
