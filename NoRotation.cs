using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotation : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion rotation;
    public ParticleSystem part;
    void Awake()
    {
        rotation = transform.rotation;
        part = gameObject.GetComponent<ParticleSystem>();
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            part.Stop();
        }
    }
}
