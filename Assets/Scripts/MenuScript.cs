using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class MenuScript : MonoBehaviour {

    /**
    * 
    */

    public Button[] levelSelectbuttons = new Button[10];
    public Button fruit1, fruit2, player;

    public Image trophy;

    public Sprite[] spriteArray = new Sprite[18], playerRun = new Sprite[6];
    public Sprite playerReact1, playerReact2, playerReact3;

    public Text[] highScores = new Text[10];
    public Text message;

    public Customer customer;

    public GameObject levelBtnList;

    System.Random rnd = new System.Random();
    private int levelsPlayed, nrOfTrophies = 0;

    // Use this for initialization
    void Start ()
    {
        levelsPlayed = customer.levelsPlayed;

        if (levelsPlayed == 0)
            levelBtnList.SetActive(false);
        else
            message.text = "";

        ActivateLevelButtons();

        // Fixes scroll sensitivity on scrollrect. (Buttons were register drag instead of push).
        if (Application.isMobilePlatform)
        {
            ScrollRect scrolRect = GameObject.Find("Panel").GetComponent<ScrollRect>();
            scrolRect.scrollSensitivity = 0.5f;
            scrolRect.elasticity = 0.05f;
            scrolRect.decelerationRate = 0.2f;
        }
    }

    public void StartLevel ()
    {
        // Play button starts next level up to lvl 23.
        if (levelsPlayed != 23 && nrOfTrophies != 23)
            SceneManager.LoadScene(levelsPlayed + 1);
        // When all the lvls are played, Play button starts next level with score under 500.
        else if (levelsPlayed == 23 && nrOfTrophies != 23) {
            for (int i = 0; i < 23; i++)
                if (customer.levelScore[i] < 500) {
                    SceneManager.LoadScene(i + 1);
                    break;
                }
        }
        // Else start level 1.
        else
            SceneManager.LoadScene(1);
    }

    public void LevelSelect()
    {
        switch (EventSystem.current.currentSelectedGameObject.transform.GetChild(0).name)
        {
            case "1":
                SceneManager.LoadScene(1);
                break;
            case "2":
                SceneManager.LoadScene(2);
                break;
            case "3":
                SceneManager.LoadScene(3);
                break;
            case "4":
                SceneManager.LoadScene(4);
                break;
            case "5":
                SceneManager.LoadScene(5);
                break;
            case "6":
                SceneManager.LoadScene(6);
                break;
            case "7":
                SceneManager.LoadScene(7);
                break;
            case "8":
                SceneManager.LoadScene(8);
                break;
            case "9":
                SceneManager.LoadScene(9);
                break;
            case "10":
                SceneManager.LoadScene(10);
                break;
            case "11":
                SceneManager.LoadScene(11);
                break;
            case "12":
                SceneManager.LoadScene(12);
                break;
            case "13":
                SceneManager.LoadScene(13);
                break;
            case "14":
                SceneManager.LoadScene(14);
                break;
            case "15":
                SceneManager.LoadScene(15);
                break;
            case "16":
                SceneManager.LoadScene(16);
                break;
            case "17":
                SceneManager.LoadScene(17);
                break;
            case "18":
                SceneManager.LoadScene(18);
                break;
            case "19":
                SceneManager.LoadScene(19);
                break;
            case "20":
                SceneManager.LoadScene(20);
                break;
            case "21":
                SceneManager.LoadScene(21);
                break;
            case "22":
                SceneManager.LoadScene(22);
                break;
            case "23":
                SceneManager.LoadScene(23);
                break;
            case "24":
                SceneManager.LoadScene(24);
                break;
            case "25":
                SceneManager.LoadScene(25);
                break;
            case "26":
                SceneManager.LoadScene(26);
                break;
            case "27":
                SceneManager.LoadScene(27);
                break;
            case "28":
                SceneManager.LoadScene(28);
                break;
            case "29":
                SceneManager.LoadScene(29);
                break;
            case "30":
                SceneManager.LoadScene(30);
                break;
        }
    }

    public void ExitPress()
    {
        customer.Save("QuitGame", 1);
        Application.Quit();
    }

    private void ActivateLevelButtons()
    {
        // Disable level select buttons.
        for (int i = 22; i >= levelsPlayed; i--)
        {
            levelSelectbuttons[i].gameObject.SetActive(false);
            highScores[i].gameObject.SetActive(false);
        }

        // Enable score for played levels.
        for (int i = 0; i < levelsPlayed; i++)
        {
            highScores[i].GetComponent<Text>().text = customer.levelScore[i].ToString("#");

            // Place a trophy on levelBtn when score is over...
            if (customer.levelScore[i] >= 500)
            {
                Image trophyCopy = Instantiate(trophy, new Vector2(levelSelectbuttons[i].transform.position.x + 72.9f, levelSelectbuttons[i].transform.position.y - 60.8f), Quaternion.identity) as Image;

                trophyCopy.transform.SetParent(levelSelectbuttons[i].transform, true);  // Set levelSelectButton as parent to the newly instantiated image object.
                trophyCopy.gameObject.SetActive(true);                                  // Set active because its starts as passive.
                trophyCopy.transform.SetSiblingIndex(1);                                // Change sibling order so it appears behind the score.
                trophyCopy.GetComponent<Image>().SetNativeSize();                       // Sets correct size on sprite.
                nrOfTrophies++;
            }
        }
    }

    public void ChangeFruitSprite()
    {
        fruit1.GetComponent<Image>().sprite = spriteArray[rnd.Next(0, 17)]; // Change sprite randomly.
        fruit1.GetComponent<Image>().SetNativeSize();                       // Sets correct size on sprite.
    }

    public void ChangePlayerSprite()
    {
        StartCoroutine(ChangePlayerSpriteRoutine());
    }

    public IEnumerator ChangePlayerSpriteRoutine()
    {
        int randomNr = rnd.Next(0, 100);
        // Player runs.
        if (randomNr < 33) {
            for (int i = 0; i < 6; i++) {
                player.GetComponent<Image>().sprite = playerRun[i];
                yield return new WaitForSeconds(0.075f);
            }
            player.GetComponent<Image>().sprite = playerReact1;
        }
        // Player looks surprised.
        else if (randomNr < 66) {
            player.GetComponent<Image>().sprite = playerReact3;
            yield return new WaitForSeconds(1f);
            player.GetComponent<Image>().sprite = playerReact1;
        }
        // Player shows peace sign.
        else {
            player.GetComponent<Image>().sprite = playerReact2;
            yield return new WaitForSeconds(1f);
            player.GetComponent<Image>().sprite = playerReact1;
        }
    }
}
