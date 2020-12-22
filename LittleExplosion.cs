using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LittleExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boomArea;
    public AudioSource audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("Boom");
        }
    }

    public void Boom()
    {
        
        Destroy(gameObject);
    }

    public void Damage()
    {
        boomArea.SetActive(true);
        audio.Play();
    }
    
}
