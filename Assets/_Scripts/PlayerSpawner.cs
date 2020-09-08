using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    void Awake()
    {
        Instantiate(playerPrefab, new Vector3(0, -3, 0), Quaternion.identity);
    }
   
}
