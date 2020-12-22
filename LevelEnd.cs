using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    public GameObject gameManager;
    public GameObject eventSystem;
    private int ch;
    public Animator Fade;
 
    private void Start()
    {
        ch = 0;
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("PlayerViking");
        eventSystem = GameObject.Find("EventSystem");
        gameManager = GameObject.Find("GameManager");
        Fade = GameObject.Find("CrossFade").GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ch == 0) 
        {
            ch++;
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(gameManager);
            DontDestroyOnLoad(eventSystem);
            gameManager.GetComponent<Inventory>().items.Clear();
            // GameObject.FindObjectOfType<LevelManager>().NextLevel();
            StartCoroutine(LoadLevel());

        }
    }

    IEnumerator LoadLevel()
    {
        Fade.SetTrigger("Start");
       // player.GetComponent<PlayerMovement>().horizontalMove = 0;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CharacterController2D>().enabled = false;
       // player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.3f);
        if (player.GetComponent<PlayerStats>().connectionLoss < 10)
        {
            player.GetComponent<PlayerStats>().connectionLoss = 0;
        }
        else
        {
            player.GetComponent<PlayerStats>().connectionLoss -= 10;
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController2D>().enabled = true;
        GameObject.FindObjectOfType<LevelManager>().NextLevel();
        Fade.ResetTrigger("Start");
        Fade.SetTrigger("End");
    }
}
