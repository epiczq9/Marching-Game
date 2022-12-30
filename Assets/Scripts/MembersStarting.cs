using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembersStarting : MonoBehaviour
{
    public int currentActiveMembers = 2;
    public List<GameObject> membersInRow;
    public SpawnController spawnController;
    ButtonBehaviour buttonBehaviour;
    public bool rowActive = false;

    void Start() {
        buttonBehaviour = GameObject.FindGameObjectWithTag("ButtonBehaviour").GetComponent<ButtonBehaviour>();
        currentActiveMembers = 2;
        Timers.TimersManager.SetTimer(this, 0.1f, InitializeMembers);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void InitializeMembers() {
        foreach (Transform member in transform) {
            membersInRow.Add(member.gameObject);
        }
        foreach (GameObject memberInList in membersInRow) {
            memberInList.SetActive(false);
        }
        /*for (int i = 0; i < spawnController.activeMembers; i++) {
            if (rowActive) {
                membersInRow[i].SetActive(true);
            }
        }*/
    }

    public bool IsRowFull() {
        return currentActiveMembers == 10;
    }

    public void SpawnMembers() {
        if (currentActiveMembers < membersInRow.Count) {
            membersInRow[currentActiveMembers].SetActive(true);
            buttonBehaviour.UpdateText();
        }
    }

    public void UpdateMembers() {
        /*if (spawnController.activeMembers < membersInRow.Count) {
            membersInRow[spawnController.activeMembers].SetActive(true);
        }*/

        if (currentActiveMembers < membersInRow.Count) {
            membersInRow[currentActiveMembers].SetActive(true);
            currentActiveMembers++;
        }
    }

    /*public void RowSpawned() {
        for (int i = 0; i < spawnController.activeMembers; i++) {
            membersInRow[i].SetActive(true);
        }
    }*/

    public void RowSpawned() {
        for (int i = 0; i < currentActiveMembers; i++) {
            membersInRow[i].SetActive(true);
        }
    }
}
