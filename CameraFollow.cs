using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject spawn;
    void Start()
    {
        spawn = GameObject.Find("Spawn");
        player = GameObject.Find("Player");
        GetComponent<CinemachineVirtualCamera>().Follow= player.transform;
        player.transform.position = spawn.transform.position;
        
    }
}
