using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Animator anim;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    private int damage;

    public AudioSource audioData;
    public AudioSource spellAudio;
    public AudioSource spellAudio2;
    public int modificator;
    bool flag=true;
    public int canUseMeleeSkill = 0;
    // Update is called once per frame

    public GameObject learning;

    private int kostyl = 0;

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                timeBtwAttack = startTimeBtwAttack;

                if (anim.GetBool("IsJumping") == true)
                {
                    anim.SetTrigger("JumpAttack");
                    audioData.Play(1);
                    anim.SetBool("CanJumpAttack", true);
                }
                else
                {
                    anim.SetTrigger("Attack");
                    audioData.Play(1);
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                timeBtwAttack = startTimeBtwAttack;
                if (gameObject.GetComponent<PlayerStats>().mana.GetValue() - gameObject.GetComponent<PlayerStats>().manaLoss >= 20 && canUseMeleeSkill > 0)
                {
                    gameObject.GetComponent<PlayerStats>().manaLoss += 20;
                    if (modificator == 0)
                    {
                        if (anim.GetBool("IsJumping") == true)
                        {
                            anim.SetTrigger("JumpMeleeSkill");
                            anim.SetBool("CanJumpAttack", true);
                           // gameObject.GetComponent<PlayerStats>().manaLoss += 5;
                        }
                        else
                        {
                            anim.SetTrigger("MeleeSkill");
                          //  gameObject.GetComponent<PlayerStats>().manaLoss += 5;
                        }
                    }
                    else if (modificator == 1)
                    {
                        if (anim.GetBool("IsJumping") == true)
                        {
                            anim.SetTrigger("PoisonJumpMeleeSkill");
                            anim.SetBool("CanJumpAttack", true);
                           // gameObject.GetComponent<PlayerStats>().manaLoss += 5;
                        }
                        else
                        {
                            anim.SetTrigger("PoisonMeleeSkill");
                           // gameObject.GetComponent<PlayerStats>().manaLoss += 5;
                        }
                    }
                    else if (modificator == 2)
                    {
                        if (anim.GetBool("IsJumping") == true)
                        {
                            anim.SetTrigger("FrostJumpMeleeSkill");
                            anim.SetBool("CanJumpAttack", true);
                        }
                        else
                        {
                            anim.SetTrigger("FrostMeleeSkill");
                        }
                    }
                    else if (modificator == 3)
                    {
                        if (anim.GetBool("IsJumping") == true)
                        {
                            anim.SetTrigger("FireJumpMeleeSkill");
                            anim.SetBool("CanJumpAttack", true);
                        }
                        else
                        {
                            anim.SetTrigger("FireMeleeSkill");
                        }
                    }
                    else if (modificator == 4)
                    {
                        if (anim.GetBool("IsJumping") == true)
                        {
                            anim.SetTrigger("ShadowJumpMeleeSkill");
                            anim.SetBool("CanJumpAttack", true);
                        }
                        else
                        {
                            anim.SetTrigger("ShadowMeleeSkill");
                        }
                    }
                }
                else
                {
                    Debug.Log("OutOfMana");
                }
                
                
            }
        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (canUseMeleeSkill == 1)
        {
            ShowLearning();
            canUseMeleeSkill += 1;
        }

    }

    public void ShowLearning()
    {
        learning.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Tы нашел зачарованное оружие! Нажми F, чтобы использовать новое умение.");
        learning.SetActive(true);
        InvokeRepeating("Costyl", 0.1f, 1f);
    }

    public void Costyl()
    {
        kostyl += 1;
        if (kostyl == 6)
        {
            kostyl = 0;
            learning.SetActive(false);
            CancelInvoke();
        }
    }

    public void DealRawDamage(int multip)
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);

        damage = gameObject.GetComponent<PlayerStats>().damage.GetValue();
        if(multip > 0)
        {
            damage = damage / multip;
        }

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            //Debug.Log(enemiesToDamage);
            if (enemiesToDamage[i].TryGetComponent<Enemy>(out Enemy enemy) == true)
            {
                enemiesToDamage[i].GetComponent<Enemy>().RawHit(damage, 0);
            }
            else if (enemiesToDamage[i].TryGetComponent<Boss>(out Boss boss) == true)
            {
                enemiesToDamage[i].GetComponent<Boss>().RawHit(damage, 0);
            }
            else if (enemiesToDamage[i].TryGetComponent<NecrZomb>(out NecrZomb necrZomb) == true)
            {
                enemiesToDamage[i].GetComponent<NecrZomb>().RawHit(damage, 0);
            }
            else if (enemiesToDamage[i].TryGetComponent<NecrScel>(out NecrScel necrScel) == true)
            {
                enemiesToDamage[i].GetComponent<NecrScel>().RawHit(damage, 0);
            }
            else if (enemiesToDamage[i].TryGetComponent<FlyingEnemy>(out FlyingEnemy flyingEnemy) == true)
            {
                enemiesToDamage[i].GetComponent<FlyingEnemy>().RawHit(damage, 0);
            }
        }
    }
    public void DealDamage(int type)
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        Color32 toCheck = new Color32(255, 255, 255, 255);
        if (flag)
        {
            S1();
            flag = false;
        }
        else
        {
            flag = true;
            S2();
        }


        if (type == 1)
        {
            damage = gameObject.GetComponent<PlayerStats>().poisonDamage.GetValue();
        }
        else if (type == 2)
        {
            damage = gameObject.GetComponent<PlayerStats>().frostDamage.GetValue();
        }
        else if (type == 3)
        {
            damage = gameObject.GetComponent<PlayerStats>().fireDamage.GetValue();
        }
        else if (type == 4)
        {
            damage = gameObject.GetComponent<PlayerStats>().shadowDamage.GetValue();
        }

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            //Debug.Log(enemiesToDamage);
            if (enemiesToDamage[i].TryGetComponent<Enemy>(out Enemy enemy) == true)
            {
                if(enemiesToDamage[i].GetComponent<Enemy>().affected == false)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage, type);
                } 
            }
            else if (enemiesToDamage[i].TryGetComponent<FlyingEnemy>(out FlyingEnemy flyingEnemy) == true)
            {
                if (enemiesToDamage[i].GetComponent<FlyingEnemy>().affected == false)
                {
                    enemiesToDamage[i].GetComponent<FlyingEnemy>().TakeDamage(damage, type);
                }
            }
            else if (enemiesToDamage[i].TryGetComponent<NecrScel>(out NecrScel necrScel) == true)
            {
                if (enemiesToDamage[i].GetComponent<NecrScel>().affected == false)
                {
                    enemiesToDamage[i].GetComponent<NecrScel>().TakeDamage(damage, type);
                }
            }
            else if (enemiesToDamage[i].TryGetComponent<NecrZomb>(out NecrZomb necrZomb) == true)
            {
                if (enemiesToDamage[i].GetComponent<NecrZomb>().affected == false)
                {
                    enemiesToDamage[i].GetComponent<NecrZomb>().TakeDamage(damage, type);
                }
            }
            else if (enemiesToDamage[i].TryGetComponent<Boss>(out Boss boss) == true)
            {
                if (enemiesToDamage[i].GetComponent<Boss>().affected == false)
                {
                    enemiesToDamage[i].GetComponent<Boss>().TakeDamage(damage, type);
                }
            }
        }
    }

    public void DealMeleeSkillDamage(int type)
    {

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
      
        if (type == 0)
        {
            damage = gameObject.GetComponent<PlayerStats>().damage.GetValue();
        }
        else if(type == 1)
        {
            damage = gameObject.GetComponent<PlayerStats>().poisonDamage.GetValue();
        }
        else if (type == 2)
        {
            damage = gameObject.GetComponent<PlayerStats>().frostDamage.GetValue();
        }
        else if (type == 3)
        {
            damage = gameObject.GetComponent<PlayerStats>().fireDamage.GetValue();
        }
        else if (type == 4)
        {
            damage = gameObject.GetComponent<PlayerStats>().shadowDamage.GetValue();
        }

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if (enemiesToDamage[i].TryGetComponent<Enemy>(out Enemy enemy) == true)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage*3/4, type);
            }
            else if (enemiesToDamage[i].TryGetComponent<FlyingEnemy>(out FlyingEnemy flyingEnemy) == true)
            {
                enemiesToDamage[i].GetComponent<FlyingEnemy>().TakeDamage(damage*3/4, type);
            }
            else if (enemiesToDamage[i].TryGetComponent<Boss>(out Boss boss) == true)
            {
                enemiesToDamage[i].GetComponent<Boss>().TakeDamage(damage * 3 / 4, type);
            }
            else if (enemiesToDamage[i].TryGetComponent<NecrZomb>(out NecrZomb necrZomb) == true)
            {
                enemiesToDamage[i].GetComponent<NecrZomb>().TakeDamage(damage * 3 / 4, type);
            }
            else if (enemiesToDamage[i].TryGetComponent<NecrScel>(out NecrScel necrScel) == true)
            {
                enemiesToDamage[i].GetComponent<NecrScel>().TakeDamage(damage * 3 / 4, type);
            }

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void JumpAttackOff()
    {
        anim.SetBool("CanJumpAttack", false);
        anim.ResetTrigger("JumpAttack");
    }

    public void S1()
    {
        spellAudio.Play();
    }
    public void S2()
    {
        spellAudio2.Play();
    }
}
