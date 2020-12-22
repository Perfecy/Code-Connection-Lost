using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpbarnorotation : MonoBehaviour
{

    Transform enemy;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GetComponentInParent<Transform>();
        //Quaternion.LookRotation(Vector3.up, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<RectTransform>().rotation = new Vector3(0,-180,0);
        //  var rotation = Quaternion.LookRotation(Vector3.up, Vector3.forward);
        transform.Rotate(0, -180, 0, Space.World);
    }
}
