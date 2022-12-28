using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CubeSpawn : MonoBehaviour
{
    public PathCreator path;
    public PathCreator path2;
    public GameObject cubePrefab;
    public Transform cubeSpawnPos;
    public int members;

    public List<GameObject> cubeList;
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            SpawnCube();
        }
        if (Input.GetButtonDown("Jump")) {
            SwitchPaths(path2, cubeList[0]);
        }
    }

    public void SpawnCube() {
        GameObject cube = Instantiate(cubePrefab);
        cube.GetComponent<PathCreation.Examples.PathFollower>().pathCreator = path;
        if (cubeList.Count == 0) {
            cube.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled = 0;
        } else {
            cube.GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled =
            cubeList[cubeList.Count - 1].GetComponent<PathCreation.Examples.PathFollower>().distanceTravelled - NextCubePosition();
        }
        cubeList.Add(cube);
    }

    float NextCubePosition() {
        return path.path.length / members;
    }

    public void SwitchPaths(PathCreator newPath, GameObject cube) {
        cube.GetComponent<PathCreation.Examples.PathFollower>().pathCreator = newPath;
    }
}
