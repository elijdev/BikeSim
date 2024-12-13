using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part_Status : MonoBehaviour
{
    public GameObject prefab;
    Transform spawnPoint;
    public string partName;

    void Start()
    {
        
    }
    public void SpawnPart()
    {
        if (GameObject.Find(partName) == null)
        {
            Vector3 position = spawnPoint != null ? spawnPoint.position : Vector3.zero;
            Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;
            Instantiate(prefab, position,rotation);
        }
        else
        {
            Debug.Log("Object already exist");
        }
    }
}
