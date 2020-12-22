using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupup : MonoBehaviour
{
    [SerializeField] public Transform pfFloatingDamage;

    private FloatingDamage floatingDamage;

    public void Start()
    {
        

        //loatingDamage.Setup(100);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Transform damagePupupTransform = Instantiate(pfFloatingDamage, Vector3.zero, Quaternion.identity);
            floatingDamage = damagePupupTransform.GetComponent<FloatingDamage>();
            //floatingDamage.Setup(399);
        }
    }
}
