using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingDamage : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    System.Random rnd;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        //textMesh.color = new Color32(255, 0, 0, 0);
    }

    // Start is called before the first frame update
    public void Setup(int damageAmount, int type)
    {
        textMesh.SetText(damageAmount.ToString());
        if(type == 0)
        {
            textMesh.color = new Color32(250, 165, 165, 255);
        }
        else if(type == 1)
        {
            textMesh.color = new Color32(0, 255, 0, 255);
        }
        else if (type == 2)
        {
            textMesh.color = new Color32(0, 64, 255, 255);
        }
        else if (type == 3)
        {
            textMesh.color = new Color32(255, 0, 0, 255);
        }
        else if (type == 4)
        {
            textMesh.color = new Color32(178, 0, 255, 255);
        }
        //textMesh.color = new Color32(255, 0, 0, 255);
        textColor = textMesh.color;
        disappearTimer = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {

        float movSpeed = 1.5f;
        transform.position += new Vector3(0, movSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;

        if(disappearTimer <= 0)
        {
            float dissapearSpeed = 1f;
            textColor.a -= dissapearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
