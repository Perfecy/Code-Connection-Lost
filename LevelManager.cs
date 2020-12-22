using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] all_levels;
    public int current_level = 0;
    //int level_completed = 0;
    int i = 0;
    int n = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // reshuffle(all_levels);
        if (GameObject.Find("MenuController").GetComponent<MainMenu>().flag == false)
        {
            SceneManager.LoadScene(all_levels[current_level]);
            n = 1;
        }
        else
        {
            if (GameObject.Find("MenuController").GetComponent<MainMenu>().number == 1)
            {
                SceneManager.LoadScene(all_levels[23]);
                n = 7;
            }
            else if (GameObject.Find("MenuController").GetComponent<MainMenu>().number == 2)
            {
                SceneManager.LoadScene(all_levels[24]);
                n = 14;
            }
            else if (GameObject.Find("MenuController").GetComponent<MainMenu>().number == 3)
            {
                SceneManager.LoadScene(all_levels[25]);
                n = 21;
            }
        }
        

        //if (PlayerPrefs.HasKey("Comleted Level"))
        //    level_completed = PlayerPrefs.GetInt("Comleted Level");
        //PlayerPrefs.DeleteAll();
    }



    //void reshuffle(string[] texts)
    //{
    //    // Knuth shuffle algorithm :: courtesy of Wikipedia :)
    //    for (int t = 0; t < texts.Length; t++)
    //    {
    //        string tmp = texts[t];
    //        int r = Random.Range(t, texts.Length);
    //        texts[t] = texts[r];
    //        texts[r] = tmp;
    //    }
    //}

    public void NextLevel()
    {
       //Debug.LogError("SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
        
        current_level = current_level + n;

        //level_completed++;
        //PlayerPrefs.SetInt("Comleted Level", level_completed);
        //PlayerPrefs.Save();
        //print("Completed levels:  " + level_completed);
        if (current_level < all_levels.Length)
            SceneManager.LoadScene(all_levels[current_level]);
        else
            SceneManager.LoadScene("main_menu");
    }
}
