using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembersStarting : MonoBehaviour
{
    public int currentActiveMembers;
    public List<GameObject> membersInRow;
    public SpawnController spawnController;
    public bool rowActive = false;

    void Start() {
        currentActiveMembers = spawnController.activeMembers;
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

    public void UpdateMembers() {
        if (spawnController.activeMembers < membersInRow.Count) {
            membersInRow[spawnController.activeMembers].SetActive(true);
        }
    }

    public void RowSpawned() {
        for (int i = 0; i < spawnController.activeMembers; i++) {
            membersInRow[i].SetActive(true);
        }
    }
}
