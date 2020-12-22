using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerViking");
        cam = GameObject.Find("CM vcam1");
        cam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        player.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
