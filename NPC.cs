using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject dialogue;
    private Sprite img;
    void Start()
    {
        img = gameObject.GetComponent<Image>().sprite;
        dialogue = GameObject.Find("Canvas").transform.GetChild(6).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialogue.transform.Find("Faceplate").gameObject.transform.Find("Icon").GetComponent<Image>().sprite = img;
            if (gameObject.name == "NPC Dancer")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Ура, ты снова здесь! Ну, в этот раз не подведи! Нам уже надоело тут торчать, если честно...");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Red Mage 1")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Привет! Я видел, как гоблин прятал что-то наверху... Вроде бы ценное!");
            }
            else if (gameObject.name == "NPC Boy")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Спасибо тебе - эта тупая птица утащила меня аж сюда! Не надо было выбирать такого маленького персонажа...");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Girl")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Одно мученье, эта кукла вообще не наносит урон врагам! Спустись вниз, может ты доберешься до местных сокровищ");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Girl Bard")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("За юность мы пьем, прошлым дням наш по... а, не та игра... Проходи, не задерживайся! Или это тоже где-то было...");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Grandma")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Внук посоветовал поиграть, грибы пособирать спустилась вот... Ты деда моего не видел, кстати?");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Fisher")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Что я тут пытаюсь поймать? А не твое дело! Пойди лучше с тем гоблином разберись, он надоел камнями бросаться");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Blue Mage 3")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Кстати, следи за соединением! Чем его меньше, тем больше урона ты получаешь! Если его будет мало, ты будешь получать урон и умрешь!");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Dedulya")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Она меня даже тут в покое не может оставить! Еле слинял... Кстати, глянь, что там внизу - у меня уже спина не та");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Miner")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Как хорошо после смены на руднике в жаркий летний день прийти домой и поиграть в любимую игру...");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Gladiator")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Жуки... Ненавижу жуков! Хоть панцыри уних ценные, но 40.000 штук собрать... Ненавижу жуков!");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC InnKeeper")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Ты не видел моего охранника? Сказал жуков побьет и вернется, я его тут уже вечность жду!");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Ded Pivo")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Не видел нашего друга? Мы решили пересидеть тут, пока ты со всем не разберешься, наняли ему охранника, а их всё нет...");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Red Mage 2")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Впереди жуткое место! Мы попробуем миновать его телепортацией... Готов? Укроемся в пещере и попробуем");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Blue Mage 1")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Красного куда-то не туда занесло... А, нет - это нас не туда занесло! Надо скорее выбираться отсюда");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Girl Adv")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("А те неплох! Немногие добираются сюда. У меня был напарник, но мы разделились и теперь я не знаю, где он...");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Farmer")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("На самом деле я Адский Демон тьмы! Просто не того персонажа с вилами выбрал... Чего ты смеешься, я само зло!");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Inn Keeper 2")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("О, и ты тут? Ребята сказали, что ты был у них чуть раньше чем я. Красиво тут, правда? Хоть и опасно");
                Debug.Log(dialogue.name);
            }
            else if (gameObject.name == "NPC Boy Adv")
            {
                dialogue.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("Интересно, есть ли там что-то, за этим бескрайним лавовым морем... Жаль моя напарница не видит, как тут красиво");
                Debug.Log(dialogue.name);
            }

                dialogue.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogue.SetActive(false);
        }
    }
}
