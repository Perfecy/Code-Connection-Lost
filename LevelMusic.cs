using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource swamp;
    public AudioSource swampBoss;
    public AudioSource mines;
    public AudioSource minesBoss;
    public AudioSource hell;
    public AudioSource hellBoss;

    public LevelManager levelManager;

    int s = 0;
    int sb = 0;
    int m = 0;
    int mb = 0;
    int h = 0;
    int hb = 0;

    void Start()
    {
        swamp.loop = true;
        swamp.Play();
        levelManager = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.current_level > 6 && levelManager.current_level < 8)
        {
            if(sb == 0)
            {
                swamp.Stop();
                swampBoss.loop = true;
                swampBoss.Play();
                sb++;
            }
            
        }
        else if(levelManager.current_level > 7 && levelManager.current_level < 14)
        {
            if(m == 0)
            {
                swampBoss.Stop();
                mines.loop = true;
                mines.Play();
                m++;
            }
            
        }
        else if (levelManager.current_level > 13 && levelManager.current_level < 15)
        {
            if(mb == 0)
            {
                mines.Stop();
                minesBoss.loop = true;
                minesBoss.Play();
                mb++;
            }
            
        }
        else if (levelManager.current_level > 14 && levelManager.current_level < 21)
        {
            if(h == 0)
            {
                minesBoss.Stop();
                hell.loop = true;
                hell.Play();
                h++;
            }
            
        }
        else if (levelManager.current_level > 20 && levelManager.current_level < 22){
            
            if(hb == 0)
            {
                hell.Stop();
                hellBoss.loop = true;
                hellBoss.Play();
                hb++;
            }
        }
        else
        {
            hellBoss.Stop();
        }
    }
}
