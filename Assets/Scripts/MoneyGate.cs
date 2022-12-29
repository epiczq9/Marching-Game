using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGate : MonoBehaviour
{
    GameController gameController;
    ButtonBehaviour buttonBehaviour;

    private void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        buttonBehaviour = GameObject.FindGameObjectWithTag("ButtonBehaviour").GetComponent<ButtonBehaviour>();
    }
    private void OnTriggerEnter(Collider other) {
        gameController.money += other.gameObject.GetComponent<MemberWorth>().worth;
        buttonBehaviour.UpdateText();
        other.gameObject.GetComponent<UISpawn>().SpawnPointUI();
    }


}
