using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public GameObject skillShot;
    public List<GameObject> skillShot;

    public Animator anim;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private float gravity;

    public AudioSource audioData;
    public AudioSource spellAudio;
    public string upgrade;
    public int canUseRangedSkill = 0;

    public GameObject learning;

    private int kostyl;

    void Update()
    {
        gravity = anim.GetFloat("Gravity");
        if (timeBtwAttack <= 0 && gravity > 2)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                timeBtwAttack = startTimeBtwAttack;
                if (anim.GetBool("IsJumping") == false)
                {
                    if (gameObject.GetComponent<PlayerStats>().mana.GetValue() - gameObject.GetComponent<PlayerStats>().manaLoss >= 10)
                    {
                        anim.SetTrigger("Launch");
                        gameObject.GetComponent<PlayerStats>().manaLoss += 10;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                timeBtwAttack = startTimeBtwAttack;
                if(anim.GetBool("IsJumping") == false && canUseRangedSkill > 0)
                {
                    if (gameObject.GetComponent<PlayerStats>().mana.GetValue() - gameObject.GetComponent<PlayerStats>().manaLoss >= 25)
                    {
                        anim.SetTrigger("RangeSkill");
                        gameObject.GetComponent<PlayerStats>().manaLoss += 25;
                    }
                    else
                    {
                        Debug.Log("OutOfMana");
                    }
                } 
            }
        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if(canUseRangedSkill == 1)
        {
            ShowLearning();
            canUseRangedSkill += 1;
        }
    }

    public void ShowLearning()
    {
        learning.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Tы нашел зачарованное кольцо! Нажми E, чтобы использовать заклинание.");
        learning.SetActive(true);
        InvokeRepeating("Costyl", 0.1f, 1f);
    }

    public void Costyl()
    {
        kostyl += 1;
        //Debug.Log(kostyl);
        if(kostyl == 6)
        {
            kostyl = 0;
            learning.SetActive(false);
            CancelInvoke();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        audioData.Play(1);
    }

    void Skillshot()
    {
        if (upgrade == "Poison")
        {
            //skillShot.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
            Instantiate(skillShot[1], firePoint.position, firePoint.rotation);
            spellAudio.Play(1);
        }
        else if (upgrade == "Frost")
        {
            //skillShot.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 0, 255);
            Instantiate(skillShot[2], firePoint.position, firePoint.rotation);
            spellAudio.Play(1);
        }
        else if (upgrade == "Fire")
        {
            //skillShot.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 255);
            Instantiate(skillShot[3], firePoint.position, firePoint.rotation);
            spellAudio.Play(1);
        }
        else if (upgrade == "Shadow")
        {
            //skillShot.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Instantiate(skillShot[4], firePoint.position, firePoint.rotation);
            spellAudio.Play(1);
        }
        else
        {
            //skillShot.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Instantiate(skillShot[0], firePoint.position, firePoint.rotation);
        }
    }
}
