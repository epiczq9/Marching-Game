using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject loadingScreen;
    public List<GameObject> rows;
    public List<GameObject> bandMembers;
    readonly int membersMax = 10;
    public int activeMembers = 0;
    public int activeRows = 0;
    public bool inBase = true;
    
    void Start() {
        Timers.TimersManager.SetTimer(this, 0.15f, StartGame);
    }


    void Update() {
        
    }

    void StartGame() {
        SpawnMember();
        SpawnMember();
        SpawnRow();
        Destroy(loadingScreen);
    }

    public void SpawnMember() {
        /*foreach (GameObject row in rows) {
            row.GetComponent<MembersStarting>().UpdateMembers();
        }*/
        /*if (activeMembers < membersMax) {
            for (int i = 0; i < activeRows; i++) {
                rows[i].GetComponent<MembersStarting>().UpdateMembers();
            }
        }*/

        for (int i = 0; i < activeRows; i++) {
            if (!rows[i].GetComponent<MembersStarting>().IsRowFull()) {
                rows[i].GetComponent<MembersStarting>().UpdateMembers();
                break;
            }

            activeMembers++;
        }
    }

    public void SpawnRow() {
        if (activeRows < rows.Count) {
            rows[activeRows].GetComponent<MembersStarting>().RowSpawned();
            activeRows++;
        }
    }

    public bool AreMembersFull() {
        return (activeMembers == membersMax);
    }

    public bool AreRowsFull() {
        return (activeRows == rows.Count);
    }

    public bool IsEverythingFull() {
        return AreMembersFull() && AreRowsFull();
    }
}
