using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidArena : MonoBehaviour
{
    // Start is called before the first frame update
    public float starDel;
    private float delay=0.5f;
    private bool flag=false;
    private Transform[] arr;
    int i = 0;
    void Start()
    {
        delay = starDel;
        arr = gameObject.transform.GetComponentsInChildren<Transform>(true);
        //foreach (Transform child in arr)
        //{
        //    Debug.Log(child.name);
        //}
        //Debug.Log(transform.childCount);
        //foreach (Transform g in transform.GetComponentsInChildren<Transform>(true))
        //{
        //    Debug.Log(g.name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

        if(flag && delay <= 0)
        {
            delay = starDel;
            arr[i].gameObject.SetActive(true);
            i++;
            if (i > 7)
            {
                flag = false;
            }
        }


    }

    public void Spawn()
    {
        flag = true;
    }
}
