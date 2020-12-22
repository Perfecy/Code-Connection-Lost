using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallChest : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterStatsystem cs;
    new Collider2D collider;
    LootManager lootManager;
    int ch = 0;
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
          
            while (ch == 0)
            {
                Instantiate(lootManager.GetRandomSmallConsumable(), transform.position + (transform.up * 0.5f) + (transform.right * 0.5f), Quaternion.identity);
                ch++;
            }

            // влияние на шкалу
            collider.enabled = false;
            Destroy(this);
        }
    }


}
