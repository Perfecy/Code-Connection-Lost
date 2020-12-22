using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    // Start is called before the first frame update
    public JointMotor2D motor;
    // Update is called once per frame
    float intTimer = 1;
    float timer=1;
    private GameObject player;
    private bool boosted;

    private void Start()
    {
        motor = gameObject.GetComponent<HingeJoint2D>().motor;
        motor.motorSpeed = gameObject.GetComponent<HingeJoint2D>().motor.motorSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if ((gameObject.GetComponent<Rigidbody2D>().rotation >90 && timer <= 0) || (gameObject.GetComponent<Rigidbody2D>().rotation < -90 && timer <=0))
        //&& gameObject.GetComponent<Rigidbody2D>().angularVelocity == 0)
        {
            // motor.motorSpeed = gameObject.GetComponent<HingeJoint2D>().motor.motorSpeed;
            timer = intTimer;
            Debug.Log(motor.motorSpeed);
            motor.motorSpeed = motor.motorSpeed * -1;
            gameObject.GetComponent<HingeJoint2D>().motor = motor; //gameObject.GetComponent<HingeJoint2D>().motor.motorSpeed *-1;
        }

        if (player.GetComponent<PlayerStats>().connectionLoss > 20 && !boosted)
        {
            motor.motorSpeed = motor.motorSpeed * 1.3f;
            boosted = true;
        }
    }
}
