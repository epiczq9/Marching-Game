using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISpawn : MonoBehaviour {

    public GameObject pointsPopUpPrefab;
    public Transform popupPos;
    public void SpawnPointUI() {
        int points = GetComponent<MemberWorth>().worth;
        GameObject popup = Instantiate(pointsPopUpPrefab, popupPos);
        popup.GetComponent<TMP_Text>().text = "+" + points.ToString();
    }
}
