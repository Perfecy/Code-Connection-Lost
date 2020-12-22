using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    int level;
    GameObject camera1;
    private void Start()
    {
        camera1 = GameObject.FindGameObjectWithTag("Camera");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sdfdsfsdfsd");
        Debug.Log("sdfdsfsdfsd");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.tag);
            //SceneManager.LoadScene(1);
             Scene sceneToLoad = SceneManager.GetSceneByName("Test2");
             SceneManager.LoadScene(1, LoadSceneMode.Single);
           //  SceneManager.MoveGameObjectToScene(collision.gameObject, sceneToLoad);
           DontDestroyOnLoad(collision.gameObject);
           //DontDestroyOnLoad(camera1); 
        }
    }
    public void NextLevel()
    {

        
        SceneManager.LoadScene(2);
    }

}
