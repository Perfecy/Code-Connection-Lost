using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcientBehaviour : MonoBehaviour
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
    public Transform[] pos;
    public int curPos;
    public GameObject pike;
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
    private int countThorn;
    private bool isLeft;
    public GameObject ThornPos;
    public GameObject Thorn;
    private Vector3[] thornPoses;
    #endregion

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
        moveSpeed = speed;
        playerPos = player.transform;
        curPos = 0;
        countThorn = 0;
        

        List<Vector3> termsList = new List<Vector3>();
        foreach (Transform i in ThornPos.transform.GetComponentsInChildren<Transform>(true))
        {
            termsList.Add(i.position);
            //Debug.Log(i.gameObject.name);
        }
        thornPoses = termsList.ToArray();
        
    }

    void Update()
    {

        Flip();
      //  distance = Vector2.Distance(transform.position, playerPos.position);
     //   Debug.Log(transform.GetComponent<Boss>().healthLeft);


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

       

    }



    public void ThornAttack()
    {
        InvokeRepeating("Thorns", 0.2f, 0.5f);
        countThorn = 0;
    }

    public void Thorns()
    {
        countThorn++;
        Instantiate(Thorn, thornPoses[countThorn], Quaternion.AngleAxis(90, Vector3.forward));
        if(countThorn > 6)
        {
            CancelInvoke();
        }
    }

    public void PikeAttack()
    {
        Vector3 pikepos = playerPos.position;
        pikepos.y = transform.position.y-2.2f;
        Instantiate(pike, pikepos, Quaternion.identity);
    }

    public void TriggerCooling()
    {
        cooldown = true;
        timer = intTimer;

    }


    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (!anim.GetBool("Move"))
        {


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
        }
        else
        {

            if (transform.position.x > pos[curPos % 4].position.x)
            {
                rotation.y = 180;
                isLeft = true;
            }
            else
            {
                isLeft = false;
                rotation.y = 0;
            }
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
        GameObject BulletIns = Instantiate(bullet, ShootPoint.position, Quaternion.Euler(0f, 0f, rotZ));
        BulletIns.GetComponent<Rigidbody2D>().velocity = new Vector2(Direction.x, Direction.y).normalized * bulletSpeed;


    }
    public void AddPos()
    {
        curPos++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos[curPos % 4].position, transform.position);
    }
}


    
   