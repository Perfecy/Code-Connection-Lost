using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Learning : MonoBehaviour
{
    private GameObject learning;
    void Start()
    {
        learning = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "Learn Shoot")
            {
                learning.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Этого не достать... Попробуй ПКМ, чтобы выстрелить!");
            }
            else if (gameObject.name == "Learn Connection")
            {
                learning.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Когда рядом опасное место, соединение нарушается и ты видишь такой эффект!");
            }

            learning.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            learning.SetActive(false);
            Destroy(gameObject);
        }
    }
}
