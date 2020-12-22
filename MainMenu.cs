using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject level_manager_prefab;
    public bool flag = false;
    public int number = 0;

    private void Start()
    {
        if (GameObject.FindObjectOfType<LevelManager>())
            Destroy(GameObject.FindObjectOfType<LevelManager>().gameObject);
    }

    public void NewGame()
    {
        Instantiate(level_manager_prefab);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Scenario1()
    {
        number = 1;
        flag = true;
        Instantiate(level_manager_prefab);
    }
    public void Scenario2()
    {
        number = 2;
        flag = true;
        Instantiate(level_manager_prefab);
    }
    public void Scenario3()
    {
        number = 3;
        flag = true;
        Instantiate(level_manager_prefab);
    }
}
