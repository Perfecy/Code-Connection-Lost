using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpikeTS : MonoBehaviour
{

    public CharacterStatsystem cs;
    new Collider2D collider;
    LootManager lootManager;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        cs = GameObject.Find("PlayerViking").GetComponent<PlayerStats>();
        lootManager = GameObject.Find("GameManager").GetComponent<LootManager>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("Open");
            if (cs.connectionLoss >= 5)
            {
                cs.connectionLoss -= 5;
            }

            Instantiate(lootManager.GetRandomWeapon(), transform.position + (transform.up * 0.5f) + (transform.right * 0.5f), Quaternion.identity);

            // влияние на шкалу
            collider.enabled = false;
        }
    }


}
