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
        Worth(other.gameObject);
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

    void Worth(GameObject member) {
        if (member.transform.parent.GetComponent<RadialController>().smileyMode) {
            member.GetComponent<MemberWorth>().ChangeWorth(2);
        } else if (member.transform.parent.GetComponent<RadialController>().starMode) {
            member.GetComponent<MemberWorth>().ChangeWorth(3);
        } else if (member.transform.parent.GetComponent<RadialController>().circleMode) {
            member.GetComponent<MemberWorth>().ChangeWorth(4);
        } else {
            member.GetComponent<MemberWorth>().ChangeWorth(1);
        }
    }

}
