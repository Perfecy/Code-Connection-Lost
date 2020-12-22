using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossDialogue : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dialogue;
    public Boss boss;
    private Sprite img;
    private int phaseCounter = 1;
    private int secCount = 0;
    private Animator playerAnim;
    private Animator bossAnim;
    void Start()
    {
        img = gameObject.GetComponent<Image>().sprite;
        dialogue = GameObject.Find("Canvas").transform.GetChild(6).gameObject;
        Debug.Log(dialogue.name);
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        bossAnim = boss.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (phaseCounter == 1 && boss.healthLeft<=boss.health*0.75f)//если хп босса <= 75% и счетчик = 1;
        {
            //меняем стейт
            bossAnim.SetTrigger("Pause");
            playerAnim.SetTrigger("Pause");
            phaseCounter += 1;
            dialogue.transform.Find("Faceplate").gameObject.transform.Find("Icon").GetComponent<Image>().sprite = img;
            if (gameObject.name == "Boss2Dialogue") //имя объекта для комнаты с боссом Х
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Что, хочешь тут всё 'починить'? Теперь это место принадлежит нам, и у тебя ничего не получится с этим сделать!");
            }
            else if (gameObject.name == "Boss1Dialogue") //имя объекта для комнаты с боссом Х
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("О, ты одолел нашего зеленого друга? Похвально... но дальше меня тебе не пройти! Мы слишком долго захватывали эти миры!");
            }
            else if (gameObject.name == "Boss3Dialogue") //имя объекта для комнаты с боссом Х
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Очередная попытка? Упорство и глупость так тяжело отличить друг от друга... что же ты покажешь на этот раз?");
            }
            dialogue.SetActive(true);
            InvokeRepeating("Counter", 0.1f, 1f);
        }
        else if (phaseCounter == 2 && boss.healthLeft <= boss.health * 0.25f) //если хп босса <= 25% и счетчик = 3;
        {
            phaseCounter = 0;
            //меняем стейт
            bossAnim.SetTrigger("Pause");
            playerAnim.SetTrigger("Pause");
            if (gameObject.name == "Boss2Dialogue") //имя объекта для комнаты с боссом Х
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Не может быть, я не могу проиграть! Только не какому-то боту! Ну ничего... другие отомстят за меня!");
            }
            else if (gameObject.name == "Boss1Dialogue") //имя объекта для комнаты с боссом Х
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Да, кажется я понимаю, чем ты отличаешься от предшественников... Но скоро ты поймешь, что твои старания пойдут прахом...");
            }
            else if (gameObject.name == "Boss3Dialogue") //имя объекта для комнаты с боссом Х
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Твоя победа... ничего не будет значить! Ты спасешь лишь горстку играков с этих уровней, но это только капля в море!");
            }
            dialogue.SetActive(true);
            InvokeRepeating("Counter", 0.1f, 1f);
        }
    }

    private void Counter()
    {
        secCount += 1;
        if (secCount == 6)
        {
            secCount = 0;
            dialogue.SetActive(false);
            //мы меняем стейт
            bossAnim.SetTrigger("UnPause");
            playerAnim.SetTrigger("UnPause");
            CancelInvoke();
        }
    }
}