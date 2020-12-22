using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
//using static Unity.Mathematics.Random;
//using Unity.Mathematics;
public class LootManager : MonoBehaviour
{
    //using Unity.Mathematics;
    //private int value;
    public GameObject[] lootDrop;
    // Start is called before the first frame update

    public GameObject GetRandomItem()
    {

        System.Random rnd = new System.Random();

        int value = rnd.Next(0, lootDrop.Length);
        return lootDrop[value];

    }

    public GameObject GetItemForEnemy()
    {
        GameObject empty = new GameObject();
        System.Random rnd = new System.Random((int)Time.time);

        int value = rnd.Next(0, Time.frameCount);
        value = value % 5;
        if (value < 2)
        {
            return empty;
        }
        else if (value < 3)
        {
            return GetRandomGear();

        }
        else
        {
            return GetRandomSmallConsumable();
        }



    }




    public GameObject GetItem(int index)
    {
        return lootDrop[index];
    }

    public GameObject GetRandomGear()
    {
        System.Random rnd = new System.Random(Time.frameCount % 20);
        int value = rnd.Next(0, 40);
        value = value / 10;
        int x = 0;
        int y = 0;
        if (GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level < 7)
        {
            if (value == 0)
            {
                x = 0;
                y = 8;
            }
            else if (value == 1)
            {
                x = 8;
                y = 15;
            }
            else if (value == 2)
            {
                x = 15;
                y = 22;
            }
            else if (value == 3)
            {
                x = 22;
                y = 29;
            }
        }
        else if (GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level < 14)
        {
            if (value == 0)
            {
                x = 35;
                y = 43;
            }
            else if (value == 1)
            {
                x = 43;
                y = 50;
            }
            else if (value == 2)
            {
                x = 50;
                y = 57;
            }
            else if (value == 3)
            {
                x = 57;
                y = 64;
            }
        }
        else if (GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level < 22)
        {
            if (value == 0)
            {
                x = 64;
                y = 71;
            }
            else if (value == 1)
            {
                x = 71;
                y = 78;
            }
            else if (value == 2)
            {
                x = 78;
                y = 86;
            }
            else if (value == 3)
            {
                x = 86;
                y = 93;
            }
        }


        value = rnd.Next(x, y);

        return lootDrop[value];
    }

    public GameObject GetRandomSmallConsumable()
    {
        System.Random rnd = new System.Random((int)Time.time);
        int x = rnd.Next(Time.frameCount);
        x = x % 4;
        int value = 0;
        if (x == 0)
        {
            value = 29;
        }
        else if (x == 1)
        {
            value = 30;
        }
        else if (x == 2)
        {
            value = 31;
        }
        else
        {
            value = 30;
        }


        return lootDrop[value];
    }

    public GameObject GetRandomBigConsumable()
    {
        System.Random rnd = new System.Random((int)Time.time);

        int value = rnd.Next(32, 35);
        return lootDrop[value];
    }

    public GameObject GetRandomWeapon()//11,12,13,22,23,24,25,26,27
    {
        System.Random rnd = new System.Random((int)Time.frameCount);
        int w = 0;
        int value = rnd.Next(1, 64);
        if (value < 8)
        {
            w = 4;
        }
        else if (value < 15)
        {
            w = 9;
        }
        else if (value < 22)
        {
            w = 10;
        }
        else if (value < 29)
        {
            w = 15;
        }
        else if (value < 36)
        {
            w = 20;
        }
        else if (value < 43)
        {
            w = 21;
        }
        else if (value < 50)
        {
            w = 26;
        }
        else if (value < 57)
        {
            w = 27;
        }
        else
        {
            w = 28;
        }

        return lootDrop[w];
    }


    public List<GameObject> GetGearForBoss()
    {
        List<GameObject> Loot = new List<GameObject>();
        // System.Random rnd = new System.Random((int)Time.time);
        GameObject b = new GameObject();
        while (Loot.Count != 3)
        {
            Debug.Log("asdas");
            b = GetRandomGearForBoss();
            if (!Loot.Contains(b))
            {
                Loot.Add(b);
            }

        }



        return Loot;
    }
    public GameObject GetRandomGearForBoss()
    {
        System.Random rnd = new System.Random();
        int value = rnd.Next(0, 40);
        value = value / 10;
        int x = 0;
        int y = 0;

        if (GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level < 7)
        {
            if (value == 0)
            {
                x = 0;
                y = 8;
            }
            else if (value == 1)
            {
                x = 8;
                y = 15;
            }
            else if (value == 2)
            {
                x = 15;
                y = 22;
            }
            else if (value == 3)
            {
                x = 22;
                y = 29;
            }
        }
        else if (GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level < 14)
        {
            if (value == 0)
            {
                x = 35;
                y = 43;
            }
            else if (value == 1)
            {
                x = 43;
                y = 50;
            }
            else if (value == 2)
            {
                x = 50;
                y = 57;
            }
            else if (value == 3)
            {
                x = 57;
                y = 64;
            }
        }
        else if (GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>().current_level < 22)
        {
            if (value == 0)
            {
                x = 64;
                y = 71;
            }
            else if (value == 1)
            {
                x = 71;
                y = 78;
            }
            else if (value == 2)
            {
                x = 78;
                y = 86;
            }
            else if (value == 3)
            {
                x = 86;
                y = 93;
            }
        }


        value = rnd.Next(x, y);

        return lootDrop[value];

    }
}
