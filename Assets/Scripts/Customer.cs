using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Customer : MonoBehaviour {

    public GameObject talkBubble, fruit, text, level;

    public Player p;
    public ProgressBar q;
    public RandomStartFruit rndStartFruit;
    public Blender b;

    private SpriteRenderer spriteRenderer;
    public Sprite[] customerSprite = new Sprite[16];

    System.Random rnd = new System.Random();

    public string currentLevel;

    public bool isRetryLevel, isRetryClicked;

    public int levelsPlayed;

    public float[] levelScore = new float[30];
    public float averageScore, currentlyPlayingLvl;

    StaticDataStore data = new StaticDataStore();

    void Start ()
    {
        // Load stored player data from file.
        Load();

        // START WITH EVERY LEVEL AVAILABLE.
/*        if (levelsPlayed == 0)
        {
            int k = 23;
            for (int i = 0; i <= k; i++)
                levelScore[i] = rnd.Next(250, 550);
            levelsPlayed = k;
        } */

        // Initiate spriterenderer and random select a sprite for customer on start.
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = customerSprite[rnd.Next(0, 16)];

        try {
            currentLevel = level.GetComponent<TextMesh>().text;
            fruit.SetActive(false);
            talkBubble.SetActive(false);
        } catch (UnassignedReferenceException) { }

        StartCoroutine(StartUp());

        //Debug.Log("levelsPlayed: " + levelsPlayed);
    }

    public void Action(string action)
    {
        StartCoroutine(Behaviour(action));
    }

    private IEnumerator StartUp()
    {
        // Show advertisement. Not for main menu and first level. Also set frequency.
       if (SceneManager.GetActiveScene().buildIndex != 0 && levelsPlayed != 0 && Advertisement.IsReady() && rnd.Next(1, 100) <= 15)
            Advertisement.Show();

        // Wait for advertisement to finish.
        while (Advertisement.isShowing)
        {
            yield return new WaitForSeconds(1f);

            if (!Advertisement.isShowing)
                break;
        }

        switch (currentLevel)
        {
            // StartUp LEVEL 1:
            case "Level 1":
                
                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.30f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Hi smoothie \n chef!";

                    yield return new WaitForSeconds(2f);

                    MoveDialogAndText(0.25f, 0.45f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.05f, -0.10f);
                text.GetComponent<TextMesh>().text = " \n Min 4x";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(4.673f);
//                q.SetCounterSpeed(0.01f);

            break;

            // StartUp LEVEL 2:
            case "Level 2":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.05f, -0.10f);
                text.GetComponent<TextMesh>().text = " \n Min 4x";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(4.490f);

            break;

            // StartUp LEVEL 3:
            case "Level 3":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    MoveDialogAndText(-0.25f, -0.40f);
                    text.GetComponent<TextMesh>().text = " Any of \n these two..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.30f, 0f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.10f, -0.10f);
                text.GetComponent<TextMesh>().text = " \n Min 5x";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(4.126f);

            break;

            // StartUp LEVEL 4:
            case "Level 4":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.10f, -0.10f);
                text.GetComponent<TextMesh>().text = " \n Min 6x";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(5.615f);

                break;

            // StartUp LEVEL 5:
            case "Level 5":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.45f, 0f);
                    text.GetComponent<TextMesh>().text = " I'm allergic \n to smoothies";

                    yield return new WaitForSeconds(3f);

                    //MoveDialogAndText(0.20f, 0.35f);
                    MoveDialogAndText(0.10f, 0.40f);
                    text.GetComponent<TextMesh>().text = " I only want \n a strawberry \n on the glass";

                    yield return new WaitForSeconds(4f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.15f, -0.15f);
                text.GetComponent<TextMesh>().text = " Empty \n +";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(6.104f);

            break;

            // StartUp LEVEL 6:
            case "Level 6":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.10f, -0.10f);
                text.GetComponent<TextMesh>().text = " Min 5x \n +";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(3.580f);

                break;

            // StartUp LEVEL 7:
            case "Level 7":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.10f, -0.10f);
                text.GetComponent<TextMesh>().text = " Min 6x \n +";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(2.476f);

            break;

            // StartUp LEVEL 8:
            case "Level 8":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    MoveDialogAndText(-0.45f, -0.80f);
                    text.GetComponent<TextMesh>().text = " Exactly..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.10f, 0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.25f, -0.20f);
                text.GetComponent<TextMesh>().text = " \n 5x ";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(3.142f);

            break;

            // StartUp LEVEL 9:
            case "Level 9":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.25f, -0.20f);
                text.GetComponent<TextMesh>().text = " \n 7x ";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.657f);

            break;

            // StartUp LEVEL 10:
            case "Level 10":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    MoveDialogAndText(-0.20f, -0.45f);
                    text.GetComponent<TextMesh>().text = " Any Orange \n fruit";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.35f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.20f, 0f);
                text.GetComponent<TextMesh>().text = " \n 6x    +  ";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(2.032f);

            break;

            // StartUp LEVEL 11:
            case "Level 11":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.20f, 0f);
                text.GetComponent<TextMesh>().text = " \n 6x    +  ";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.928f);

            break;

            // StartUp LEVEL 12:
            case "Level 12":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.10f, 0.10f);
                text.GetComponent<TextMesh>().text = " \n      +  ";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.436f);

            break;

            // StartUp LEVEL 13:
            case "Level 13":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.15f, 0.10f);
                text.GetComponent<TextMesh>().text = " \n      +  ";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.636f);

            break;

            // StartUp LEVEL 14:
            case "Level 14":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                //MoveDialogAndText(-0.15f, 0f);
                MoveDialogAndText(0.15f, 0.10f);
                text.GetComponent<TextMesh>().text = " \n      +  ";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.122f);

            break;

            // StartUp LEVEL 15:
            case "Level 15":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n like..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.30f, 0.20f);
                text.GetComponent<TextMesh>().text = "";
                fruit.SetActive(true);

                p.CanMove(true);

                // TextMesh override, change text when picking up fruit. From --> To.
                p.ChangeNameOnFruit("Lime", "Avocado");

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.169f);

            break;

            // StartUp LEVEL 16:
            case "Level 16":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n like..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.30f, 0.50f);
                text.GetComponent<TextMesh>().text = "";
                fruit.SetActive(true);

                p.CanMove(true);

                // TextMesh override, change text when picking up fruit. From --> To.
                p.ChangeNameOnFruit("Watermelon", "Tomato slice");

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.376f);

            break;

            // StartUp LEVEL 17:
            case "Level 17":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n like..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.30f, 0.50f);
                text.GetComponent<TextMesh>().text = "";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.994f);

            break;

            // StartUp LEVEL 18:
            case "Level 18":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.15f, -0.15f);
                text.GetComponent<TextMesh>().text = " \n 9x   +";
                fruit.SetActive(true);

                p.CanMove(true);

                // TextMesh override, change text when picking up fruit. From --> To.
                p.ChangeNameOnFruit("Blueberry", "Blue Apple");

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.330f);

            break;

            // StartUp LEVEL 19:
            case "Level 19":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.15f, -0.15f);
                text.GetComponent<TextMesh>().text = " \n 9x   +";
                fruit.SetActive(true);

                p.CanMove(true);

                // TextMesh override, change text when picking up fruit. From --> To.
                p.ChangeNameOnFruit("Blueberry", "Blue Apple");

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.187f);

            break;

            // StartUp LEVEL 20:
            case "Level 20":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(0.35f, -0.10f);
                text.GetComponent<TextMesh>().text = " \n Min 10x";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(0.957f);

            break;

            // StartUp LEVEL 21:
            case "Level 21":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.20f, -0.10f);
                text.GetComponent<TextMesh>().text = " \n 6x";
                fruit.SetActive(true);

                p.CanMove(true);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.870f);

            break;

            // StartUp LEVEL 22:
            case "Level 22":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                //MoveDialogAndText(-0.20f, 0.50f); MUST CHANGE !!!
                MoveDialogAndText(-0.20f, 0.35f);
                text.GetComponent<TextMesh>().text = " 3x \n 3x \n 3x";
                fruit.SetActive(true);

                p.CanMove(true);

                // TextMesh override, change text when picking up fruit. From --> To.
                p.ChangeNameOnFruit("Cherry", "Blue Apple");

                // FruitColor override, change color on fruit. Name and new RGB values.
                b.ChangeColorOnFruit("Cherry", 0, 0, 255);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.069f);

            break;

            // StartUp LEVEL 23:
            case "Level 23":

                // Initial dialog when level is started. This section is skipped when there is a retry.
                if (!isRetryLevel)
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.55f, 0.40f);
                    text.GetComponent<TextMesh>().text = " Can you make \n me a smoothie \n with..";

                    yield return new WaitForSeconds(3f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.55f, -0.40f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }
                // Dialog when there is a retry.
                else
                {
                    talkBubble.SetActive(true);
                    MoveDialogAndText(0.15f, -0.05f);
                    text.GetComponent<TextMesh>().text = " Let's try \n again?";

                    // Initiate and wait for player to press ready for retry.
                    p.ReadyForRetryClick();
                    while (!isRetryClicked)
                        yield return new WaitForSeconds(1.0f);

                    talkBubble.SetActive(false);
                    MoveDialogAndText(-0.15f, 0.05f);
                    text.GetComponent<TextMesh>().text = "";

                    yield return new WaitForSeconds(0.5f);
                }

                talkBubble.SetActive(true);
                MoveDialogAndText(-0.20f, 0.50f);
                text.GetComponent<TextMesh>().text = "";
                fruit.SetActive(true);

                p.CanMove(true);

                // TextMesh override, change text when picking up fruit. From --> To.
                p.ChangeNameOnFruit("Banana", "Lerange");
                p.ChangeNameOnFruit("Carrot", "Gramon");
                p.ChangeNameOnFruit("Kiwi", "Limon");

                // FruitColor override, change color on fruit. Name and new RGB values.
                b.ChangeColorOnFruit("Banana", 255, 191, 0);
                b.ChangeColorOnFruit("Carrot", 255, 159, 0);
                b.ChangeColorOnFruit("Kiwi", 213, 255, 0);

                // How fast the score is decreasing.
                q.SetCounterSpeed(1.000f);

            break;
        }
    }

    private IEnumerator Behaviour(string action)
    {
        switch (currentLevel)
        {
            // Behaviour TRAINING:
            case "Training":

                switch (action)
                {
                    case "Time":
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(0);
                        break;
                    case "Spilled":
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(26);
                        break;
                }
            break;

            // Behaviour LEVEL 1:
            case "Level 1":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 0);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(1);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, 0f);
                        if (q.score > levelScore[0] && levelScore[0] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(0f, 0.45f);
                        text.GetComponent<TextMesh>().text = " CONGRATZ! \n your first \n smoothie!";
                        yield return new WaitForSeconds(3.0f);
                        MoveDialogAndText(0f, -0.35f);
                        text.GetComponent<TextMesh>().text = " It looks \n very good!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 0);
                        SceneManager.LoadScene(2);
                        break;
                }
            break;

            // Behaviour LEVEL 2:
            case "Level 2":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 1);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(2);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, 0.10f);
                        if (q.score > levelScore[1] && levelScore[1] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        text.GetComponent<TextMesh>().text = " Thank you \n very much!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 1);
                        SceneManager.LoadScene(3);
                        break;
                }
            break;

            // Behaviour LEVEL 3:
            case "Level 3":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 2);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(3);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, 0.10f);
                        if (q.score > levelScore[2] && levelScore[2] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.20f, -0.35f);
                        text.GetComponent<TextMesh>().text = " Awesome!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 2);
                        SceneManager.LoadScene(4);
                        break;
                }
            break;

            // Behaviour LEVEL 4:
            case "Level 4":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 3);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(4);
                        break;
                    case "Spilled":
                        Save("isPlayed", 3);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, 0.05f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(4);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, 0.10f);
                        if (q.score > levelScore[3] && levelScore[3] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Great! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 3);
                        SceneManager.LoadScene(5);
                        break;
                }
            break;

            // Behaviour LEVEL 5:
            case "Level 5":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 4);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.05f, 0f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(5);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 4);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.65f, 0.15f);
                        text.GetComponent<TextMesh>().text = " That is not \n a strawberry";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(5);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 4);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.10f, 0.05f);
                        text.GetComponent<TextMesh>().text = " On the \n glass!";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(5);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.45f, 0.15f);
                        if (q.score > levelScore[4] && levelScore[4] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.20f, -0.40f);
                        text.GetComponent<TextMesh>().text = " Perfect!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 4);
                        SceneManager.LoadScene(6);
                        break;
                }
            break;

            // Behaviour LEVEL 6:
            case "Level 6":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 5);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(6);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 5);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, 0.05f);
                        text.GetComponent<TextMesh>().text = " That is not \n a kiwi";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(6);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, 0.10f);
                        if (q.score > levelScore[5] && levelScore[5] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Great! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 5);
                        SceneManager.LoadScene(7);
                        break;
                }
            break;

            // Behaviour LEVEL 7:
            case "Level 7":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 6);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(7);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 6);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, 0.05f);
                        text.GetComponent<TextMesh>().text = " That is not \n an orange";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(7);
                        break;
                    case "Spilled":
                        Save("isPlayed", 6);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, 0.05f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(7);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, 0.10f);
                        if (q.score > levelScore[6] && levelScore[6] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.10f, -0.10f);
                        text.GetComponent<TextMesh>().text = " You are \n the best!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 6);
                        SceneManager.LoadScene(8);
                        break;
                }
            break;

            // Behaviour LEVEL 8:
            case "Level 8":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 7);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, 0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(8);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 7);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.70f, 0.15f);
                        text.GetComponent<TextMesh>().text = " Green \n apples only!";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(8);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 7);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.50f, 0.15f);
                        text.GetComponent<TextMesh>().text = " Thats not \n 5x apples";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(8);
                        break;
                    case "Spilled":
                        Save("isPlayed", 7);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.60f, 0.15f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(8);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.55f, 0.20f);
                        if (q.score > levelScore[7] && levelScore[7] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(0.00f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Thank you \n very much!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 7);
                        SceneManager.LoadScene(9);
                        break;
                }
            break;

            // Behaviour LEVEL 9:
            case "Level 9":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 8);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, 0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(9);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 8);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, 0.10f);
                        text.GetComponent<TextMesh>().text = " PPAP \n no..";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(9);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 8);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.50f, 0.15f);
                        text.GetComponent<TextMesh>().text = " Pineapples \n only!";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(9);
                        break;
                    case "Wrong3":
                        Save("isPlayed", 8);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.35f, -0.25f);
                        text.GetComponent<TextMesh>().text = " To many!";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(9);
                        break;
                    case "Spilled":
                        Save("isPlayed", 8);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.60f, 0.15f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(9);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.55f, 0.20f);
                        if (q.score > levelScore[8] && levelScore[8] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Great! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 8);
                        SceneManager.LoadScene(10);
                        break;
                }
            break;

            // Behaviour LEVEL 10:
            case "Level 10":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 9);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(10);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 9);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, -0.05f);
                        text.GetComponent<TextMesh>().text = " That is not \n a strawberry";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(10);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 9);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.05f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Not what \n I wanted";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(10);
                        break;
                    case "Wrong3":
                        Save("isPlayed", 9);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.15f, -0.05f);
                        text.GetComponent<TextMesh>().text = " To much \n orange";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(10);
                        break;
                    case "Spilled":
                        Save("isPlayed", 9);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.05f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(10);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.10f, 0f);
                        if (q.score > levelScore[9] && levelScore[9] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(0.00f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Thank you \n very much!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 9);
                        SceneManager.LoadScene(11);
                        break;
                }
            break;

            // Behaviour LEVEL 11:
            case "Level 11":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 10);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(11);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 10);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.05f);
                        text.GetComponent<TextMesh>().text = " That is not \n a lime";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(11);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 10);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.05f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Not quite \n right";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(11);
                        break;
                    case "Spilled":
                        Save("isPlayed", 10);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.05f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(11);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.10f, 0f);
                        if (q.score > levelScore[10] && levelScore[10] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Great! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 10);
                        SceneManager.LoadScene(12);
                        break;
                }
            break;

            // Behaviour LEVEL 12:
            case "Level 12":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 11);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.20f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(12);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 11);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.30f, -0.15f);
                        text.GetComponent<TextMesh>().text = " That is not \n a blueberry";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(12);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 11);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.25f, -0.60f);
                        text.GetComponent<TextMesh>().text = " Nooo..";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(12);
                        break;
                    case "Wrong3":
                        Save("isPlayed", 11);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.10f, -0.15f);
                        text.GetComponent<TextMesh>().text = " More than \n I wanted";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(12);
                        break;
                    case "Spilled":
                        Save("isPlayed", 11);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, -0.15f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(12);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, -0.10f);
                        if (q.score > levelScore[11] && levelScore[11] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.20f, -0.40f);
                        text.GetComponent<TextMesh>().text = " Awesome!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 11);
                        SceneManager.LoadScene(13);
                        break;
                }
            break;

            // Behaviour LEVEL 13:
            case "Level 13":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 12);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.30f, -0.20f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(13);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 12);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.35f, -0.15f);
                        text.GetComponent<TextMesh>().text = " That is not \n a grapefruit";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(13);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 12);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.35f, -0.60f);
                        text.GetComponent<TextMesh>().text = " Ops..";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(13);
                        break;
                    case "Wrong3":
                        Save("isPlayed", 12);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, -0.15f);
                        text.GetComponent<TextMesh>().text = " More than \n I wanted";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(13);
                        break;
                    case "Spilled":
                        Save("isPlayed", 12);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, -0.15f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(13);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.10f);
                        if (q.score > levelScore[12] && levelScore[12] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Great! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 12);
                        SceneManager.LoadScene(14);
                        break;
                }
            break;

            // Behaviour LEVEL 14:
            case "Level 14":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 13);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.30f, -0.20f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(14);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 13);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.30f, -0.15f);
                        text.GetComponent<TextMesh>().text = " Wrong \n mix";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(14);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 13);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.15f);
                        text.GetComponent<TextMesh>().text = " You almost \n had it";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(14);
                        break;
                    case "Spilled":
                        Save("isPlayed", 13);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, -0.15f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(14);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.10f);
                        if (q.score > levelScore[13] && levelScore[13] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.05f, -0.40f);
                        text.GetComponent<TextMesh>().text = " Magnificent";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 13);
                        SceneManager.LoadScene(15);
                        break;
                }
            break;

            // Behaviour LEVEL 15:
            case "Level 15":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 14);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.30f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(15);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 14);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, -0.30f);
                        text.GetComponent<TextMesh>().text = " Ehm.. \n no";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(15);
                        break;
                    case "Spilled":
                        Save("isPlayed", 14);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.65f, -0.25f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(15);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.60f, -0.20f);
                        if (q.score > levelScore[14] && levelScore[14] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.15f, -0.10f);
                        text.GetComponent<TextMesh>().text = " That was \n easy!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 14);
                        SceneManager.LoadScene(16);
                        break;
                }
            break;

            // Behaviour LEVEL 16:
            case "Level 16":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 15);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.60f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(16);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 15);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.35f, -0.95f);
                        text.GetComponent<TextMesh>().text = " Almost..";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(16);
                        break;
                    case "Spilled":
                        Save("isPlayed", 15);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.65f, -0.55f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(16);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.60f, -0.50f);
                        if (q.score > levelScore[15] && levelScore[15] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.35f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Great! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 15);
                        SceneManager.LoadScene(17);
                        break;
                }
            break;

            // Behaviour LEVEL 17:
            case "Level 17":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 16);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, -0.60f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(17);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 16);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.65f, -0.55f);
                        text.GetComponent<TextMesh>().text = " You skipped \n a layer";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(17);
                        break;
                    case "Spilled":
                        Save("isPlayed", 16);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.65f, -0.55f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(17);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.60f, -0.50f);
                        if (q.score > levelScore[16] && levelScore[16] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.05f, 0.40f);
                        text.GetComponent<TextMesh>().text = " You are a \n smoothie \n wizard";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 16);
                        SceneManager.LoadScene(18);
                        break;
                }
            break;

            // Behaviour LEVEL 18:
            case "Level 18":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 17);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.35f, 0f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(18);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 17);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.30f, 0.15f);
                        text.GetComponent<TextMesh>().text = " Oh! \n banana only!";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(18);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 17);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.25f, 0.55f);
                        text.GetComponent<TextMesh>().text = " You thought \n I would'nt \n notice? ";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(18);
                        break;
                    case "Spilled":
                        Save("isPlayed", 17);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, 0.10f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(18);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, 0.15f);
                        if (q.score > levelScore[17] && levelScore[17] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.15f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Blue and \n tasty!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 17);
                        SceneManager.LoadScene(19);
                        break;
                }
            break;
            
            // Behaviour LEVEL 19:
            case "Level 19":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 18);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.35f, 0f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(19);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 18);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.10f, 0.55f);
                        text.GetComponent<TextMesh>().text = " That was \n a strange \n tomato.. ";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(19);
                        break;
                    case "Wrong2":
                        Save("isPlayed", 18);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.35f, -0.30f);
                        text.GetComponent<TextMesh>().text = " Noo.. ";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(19);
                        break;
                    case "Spilled":
                        Save("isPlayed", 18);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.20f, 0.10f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(19);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.15f, 0.15f);
                        if (q.score > levelScore[18] && levelScore[18] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.25f, -0.45f);
                        text.GetComponent<TextMesh>().text = " Love it!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 18);
                        SceneManager.LoadScene(20);
                        break;
                }
            break;

            // Behaviour LEVEL 20:
            case "Level 20":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 19);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.50f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(20);
                        break;
                    case "Spilled":
                        Save("isPlayed", 19);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.05f, 0.10f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(20);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(-0.10f, 0.10f);
                        if (q.score > levelScore[19] && levelScore[19] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.30f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Great! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 19);
                        SceneManager.LoadScene(21);
                        break;
                }
            break;

            // Behaviour LEVEL 21:
            case "Level 21":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 20);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, -0.05f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(21);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 20);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.00f, -0.35f);
                        text.GetComponent<TextMesh>().text = " Nope";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(21);
                        break;
                    case "Spilled":
                        Save("isPlayed", 20);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.50f, 0.10f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(21);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.45f, 0.10f);
                        if (q.score > levelScore[20] && levelScore[20] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.05f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Even in \n the blind!";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 20);
                        SceneManager.LoadScene(22);
                        break;
                }
            break;

            // Behaviour LEVEL 22:
            case "Level 22":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 21);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, -0.50f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(22);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 21);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.00f, -0.80f);
                        text.GetComponent<TextMesh>().text = " Nope";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(22);
                        break;
                    case "Spilled":
                        Save("isPlayed", 21);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.50f, -0.35f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(22);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.45f, -0.35f);
                        if (q.score > levelScore[21] && levelScore[21] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.15f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Allright! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 21);
                        SceneManager.LoadScene(23);
                        break;
                }
            break;

            // Behaviour LEVEL 23:
            case "Level 23":

                switch (action)
                {
                    case "Time":
                        Save("isPlayed", 22);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.05f, -0.65f);
                        text.GetComponent<TextMesh>().text = " Times \n up!";
                        yield return new WaitForSeconds(3.0f);
                        SceneManager.LoadScene(23);
                        break;
                    case "Wrong1":
                        Save("isPlayed", 22);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.00f, -0.95f);
                        text.GetComponent<TextMesh>().text = " Nope";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(23);
                        break;
                    case "Spilled":
                        Save("isPlayed", 22);
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.50f, -0.50f);
                        text.GetComponent<TextMesh>().text = " A little to \n much is it?";
                        yield return new WaitForSeconds(4f);
                        SceneManager.LoadScene(23);
                        break;
                    case "Finished":
                        p.CanPickUp(false);
                        fruit.SetActive(false);
                        MoveDialogAndText(0.45f, -0.50f);
                        if (q.score > levelScore[22] && levelScore[22] > 1)
                        {
                            text.GetComponent<TextMesh>().text = " WOW! NEW \n HIGHSCORE!";
                            yield return new WaitForSeconds(2f);
                        }
                        MoveDialogAndText(-0.15f, -0.10f);
                        text.GetComponent<TextMesh>().text = " Allright! \n thanks";
                        yield return new WaitForSeconds(4.0f);
                        Save("saveLevel", 22);
                        SceneManager.LoadScene(0);
                        break;
                }
            break;
        }
    }

    // Change size on talk bubble to fit text dialog inside.
    private void MoveDialogAndText(float xAxis, float yAxis)
    {
        talkBubble.transform.localScale = new Vector2(talkBubble.transform.localScale.x + xAxis, talkBubble.transform.localScale.y + yAxis);
        talkBubble.transform.position = new Vector2(talkBubble.transform.position.x - xAxis, talkBubble.transform.position.y);

        text.transform.position = new Vector2(text.transform.position.x - xAxis * 3f, text.transform.position.y + yAxis * 0.5f);
    }

    // SAVE AND LOAD TO FILE:

    public void Save(string type, int activeLevel)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/smoothieChef.dat");
        StaticDataStore data = new StaticDataStore();

        // Level is played but not cleared.
        if (type == "isPlayed")
        {
            data.isThisRetry = true;

            Array.Copy(levelScore, 0, data.levelScore, 0, 30);

            // If current level played is higher than levels played, set new value for levels played.
            if (activeLevel >= levelsPlayed)
                data.levelsPlayed = activeLevel;
            else
                data.levelsPlayed = levelsPlayed;
        }
        // Level is cleared.
        else if (type == "saveLevel")
        {
            data.isThisRetry = false;

            Array.Copy(levelScore, 0, data.levelScore, 0, 30);

            // Only store if score is higher than last round.
            if (q.score > data.levelScore[activeLevel])
                data.levelScore[activeLevel] = q.score;

            // If current level played is higher than levels played, set new value for levels played.
            if (activeLevel >= levelsPlayed)
                data.levelsPlayed = ++activeLevel;
            else
                data.levelsPlayed = levelsPlayed;
        }
        
        // SAVE FROM MAIN MENU WHEN QUIT GAME.
        else if (type == "QuitGame")
        {
            data.isThisRetry = false;

            Array.Copy(levelScore, 0, data.levelScore, 0, 30);

            data.levelsPlayed = levelsPlayed;
        }

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/smoothieChef.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/smoothieChef.dat", FileMode.Open);
            StaticDataStore data = (StaticDataStore)bf.Deserialize(file);
            file.Close();

            isRetryLevel = data.isThisRetry;
            levelsPlayed = data.levelsPlayed;

            Array.Copy(data.levelScore, 0, levelScore, 0, 30);
        }
    }
}
