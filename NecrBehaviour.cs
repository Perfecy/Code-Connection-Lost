using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecrBehaviour : MonoBehaviour
{
    #region Public Variables


    public float attackDistance; //Minimum distance for attack
    private float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public float speed;
    public GameObject player;
    public float sneerDistance;
    public float distance;
    public bool cooldown;
    public GameObject bullet;
    public Transform ShootPoint;
    public float bulletSpeed = 5f;
    public GameObject zomb;
    public GameObject scel;
    [HideInInspector]
    public int scelCount;
    [HideInInspector]
    public int zombCount;
    public Transform SpawnPoint;
    public GameObject acid;
    private Vector3 acidPos;
    int acidCounter=0; 
    int acidIter=1;
    public GameObject acidArena;
    Transform[] arrArena;
    #endregion

    #region Private Variables

    private Animator anim;
    //Store the distance b/w enemy and player
    private bool attackMode;
    //Check if Player is in range
    //Check if Enemy is cooling after attack
    private float intTimer;
    private Transform playerPos;
    private bool sneered = true;
   
    
    private bool isLeft;
    
    #endregion

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
        moveSpeed = speed;
        playerPos = player.transform;
        
        acidPos = transform.position;
       
    }

    void Update()
    {
        
        Flip();
        distance = Vector2.Distance(transform.position, playerPos.position);
        Debug.Log(transform.GetComponent<Boss>().healthLeft);
        

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            cooldown = false;
        }
        //if (attackDistance <= distance)
        //{
        //    anim.SetBool("canWalk", true);
        //    moveSpeed = speed;
        //}
        //else
        //{
        //    anim.SetBool("canWalk", false);
        //    //EnemyLogic();
        //    moveSpeed = 0f;
        //}

        if ( acidIter> 7)
        {
            Debug.LogWarning("OOPs");
            //StopAllCoroutines();
        }

    }





    void Attack()
    {
        //timer = intTimer; //Reset Timer when Player enter Attack Range
        if (timer <= 0)
        {
            attackMode = true; //To check if Enemy can still attack or not

            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true);
        }


    }





    public void TriggerCooling()
    {
        cooldown = true;
        timer = intTimer;

    }


    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > playerPos.position.x)
        {
            rotation.y = 180;
            isLeft = true;
        }
        else
        {
            isLeft = false;
            rotation.y = 0;
        }

       
        transform.eulerAngles = rotation;
    }

    public void Shoot()
    {
        Vector2 targetPos = playerPos.position;

        Vector2 Direction = targetPos - (Vector2)ShootPoint.position;
        //Quaternion lookDir = new Quaternion();
        //lookDir = Quaternion.LookRotation(Direction);

        float rotZ = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        //Debug.Log(lookDir);
        //GameObject BulletIns = Instantiate(bullet, ShootPoint.position, transform.rotation) ;
        GameObject BulletIns = Instantiate(bullet, ShootPoint.position, Quaternion.Euler(0f, 0f, rotZ ));
        BulletIns.GetComponent<Rigidbody2D>().velocity = new Vector2(Direction.x, Direction.y).normalized * bulletSpeed;
        
        
    }

    
    public void SummonScel()
    {
        Instantiate(scel, SpawnPoint.position, transform.rotation);
    }


    public void SummonZomb()
    {
        Instantiate(zomb, SpawnPoint.position, transform.rotation);

    }
    public void AcidAttack()
    {

         acidArena.GetComponent<AcidArena>().Spawn();
        //StartCoroutine(AcidCoroutine());
    }

    IEnumerator AcidCoroutine()
    {
        System.Random rnd = new System.Random();
        //acidPos.y -= 2.5f;
        arrArena = acidArena.GetComponentsInChildren<Transform>();
        //foreach (Transform child in arrArena)
        //{
        //    yield return new WaitForSeconds(0.5f);
        //    child.gameObject.SetActive(true);
        //    acidCounter++;
        //    Debug.Log(acidCounter);
        //}
        acidIter = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log(acidIter);
            arrArena[acidIter].gameObject.SetActive(true);
            acidIter++;
        }
        //while (true)
        //{
        //    yield return new WaitForSeconds(0.5f);
        //    //acidPos.position.x += acidStep;
        //    //acidPos.x *= acidIter;
        //    //Instantiate(acid, acidPos, Quaternion.identity);
        //    //acidPos.x += rnd.Next(1, 3);
        //    //acidIter *= -1;
        //    //acidCounter++;
        //}
    }
}
