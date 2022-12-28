using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBetweenPoints : MonoBehaviour
{
    public GameObject memberPrefab;
    public Transform pointA;
    public Transform pointB;
    Vector3 instantiatePosition;
    float lerpValue = 0;
    float distance = 0;
    public int numMember = 0;
    int segmentsToCreate;
    public List<GameObject> membersList;

    private void Start() {
        InstantiateSegments();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire2") && membersList.Count == 0) {
            InstantiateSegments();
        }

        if(membersList.Count != 0) {
            Move();
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
    void InstantiateSegments() {
        //Here we calculate how many segments will fit between the two points
        segmentsToCreate = Mathf.RoundToInt(Vector3.Distance(pointA.position, pointB.position));

        Debug.Log(segmentsToCreate);
        //As we'll be using vector3.lerp we want a value between 0 and 1, and the distance value is the value we have to add
        distance = 1f / segmentsToCreate;

        Debug.Log(distance);
        for (int i = 0; i < segmentsToCreate; i++) {
            //We increase our lerpValue
            lerpValue += distance;
            //Get the position
            instantiatePosition = Vector3.Lerp(pointA.position, pointB.position, lerpValue);
            //Instantiate the object
            GameObject newMember = Instantiate(memberPrefab, instantiatePosition, transform.rotation);
            newMember.transform.parent = transform;
            newMember.transform.eulerAngles = Vector3.zero;
            membersList.Add(newMember);
        }
        //SpawnMember();
    }

    void SpawnMember() {
        lerpValue += distance * numMember;
        instantiatePosition = Vector3.Lerp(pointA.position, pointB.position, lerpValue);
        GameObject newMember = Instantiate(memberPrefab, instantiatePosition, transform.rotation);
        newMember.transform.parent = transform;
        newMember.transform.eulerAngles = Vector3.zero;
        membersList.Add(newMember);
    }

    void Move() {
        lerpValue = 0;
        for (int i = 0; i < membersList.Count; i++) {
            lerpValue += distance;
            membersList[i].transform.position = Vector3.Lerp(pointA.position, pointB.position, lerpValue);
        }
    }
}
