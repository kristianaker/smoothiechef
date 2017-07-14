using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

public class Player : MonoBehaviour {

    /**
    * 
    */

    // Reference to other classes.
    public DropFruit d;
    public Blender b;
    public RandomGameObject r1, r2, r3;
    public ProgressBar p;
    public Customer c;
    public FadeOut f;

    private Animator anim;

    // Customer gameobjects.
    public GameObject customer, textMesh, textMeshClone, level;

    StaticDataStore data = new StaticDataStore();
    CheckLevel checkLevel = new CheckLevel();

    List<string> NameChangeOnFruit = new List<string>();

    private float playerSpeed = 60f;

    // Keep track of fruit count.
    float[] fruitCount = new float[18];
    float[] fruitCountTotal = new float[18];

    string[] fruitNames = new string[18] { "Apple green", "Apple red", "Apple yellow", "Banana", "Blueberry", "Carrot", "Cherry", "Coconut", "Grapefruit", "Kiwi", "Lemon", "Lime", "Orange", "Pear", "Pineapple", "Strawberry", "Tomato", "Watermelon"};
    
    // canOnlyHold can only be max 3 !! The program returns cyan color on default if more.
    float currentlyHolds, canOnlyHold = 3;
    public string currentLevel;

    string returnValue;

    // Cannot move before dialog with customer is finished.
    bool canMove = false, flipped, hasSpilled, readyforRetryClick, levelIsStarted, isFruitNameChange, isTrophySet;

    // Store first fruit to be picked up. So it can be placed on glass.
    string glassFruit = "";
    int glassFruitIndex, currentlyPlayingLvl = 0;
    bool isFruitOnGlass, isFirstCarryFruitOpen, levelFinished, levelCleared;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        // This object is cloned, so it doesn't need to be active.
        textMesh.SetActive(false);

        // Get current level from text object on screen.
        currentLevel = level.GetComponent<TextMesh>().text;
        string resultString = Regex.Match(currentLevel, @"\d+").Value;
        currentlyPlayingLvl = int.Parse(resultString);

        //Debug.Log("activeLevel: " + currentLevel);
    }

    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDirection = mousePosition - gameObject.transform.position;
        mouseDirection = mouseDirection.normalized;
        mouseDirection.z = 0;

        // Move player while mousebutton is pressed down.
        if (Input.GetMouseButton(0) && canMove == true)
        {
            transform.Translate(mouseDirection * Time.deltaTime * playerSpeed);
            
            anim.SetBool("MouseIsTriggered", true);

            // Start timer count when player first move.
            if (!levelIsStarted)
            {
                p.SetTimer(true);
                levelIsStarted = true;
            }
        }
        else
            anim.SetBool("MouseIsTriggered", false);

        // Turn player facing mouse pointer.
        if (mouseDirection.x < -0.01f && canMove == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flipped = true;
        }
        else if (mouseDirection.x > 0.01f && canMove == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
            flipped = false;
        }

        // Change position on the fruits the player are holding after finished level. Holding it up.
        if (levelCleared && Input.GetMouseButton(0))
            ChangeFruitInHand(false);
        else if (levelCleared && !Input.GetMouseButton(0))
            ChangeFruitInHand(true);

        if (readyforRetryClick == true && Input.GetMouseButton(0) && mousePosition.x >= 0.475f && mousePosition.x <= 3.725f && mousePosition.y >= -9.375f && mousePosition.y <= -8.175f)
            c.isRetryClicked = true;

        //Debug.Log("currentLevel: " + currentLevel);
        //Debug.Log("glassFruit: " + glassFruit + " glassFruitIndex: " + glassFruitIndex);
        //Debug.Log("x: " + transform.position.x + " y: " + transform.position.y);
        //Debug.Log("mousePosition.x: " + mousePosition.x + "   mousePosition.y: " + mousePosition.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // PICKUP FRUIT:

        // Loop through list of fruitnames to se which is triggered.
        for (int i = 0; i < fruitNames.Length; i++)
        {
            // Break out of loop when no more fruits can be held.
            if (currentlyHolds == canOnlyHold)
                break;

            // If gameObject.tag == respective fruit.
            if (col.gameObject.tag == fruitNames[i])
            {
                // Count fruit.
                currentlyHolds++;
                fruitCount[i]++;
                fruitCountTotal[i]++;
                
                // Set sprite for fruit that is held by player.
                if (isFirstCarryFruitOpen == false && currentlyHolds == 1)
                    r1.SetFruit(i);
                else if (isFirstCarryFruitOpen == false && currentlyHolds == 2)
                    r2.SetFruit(i);
                else if (isFirstCarryFruitOpen == false && currentlyHolds == 3)
                    r3.SetFruit(i);
                // Special case when first fruit is put on glass and more fruit is to be picked up.
                // Must fill in open slot on.
                else if (isFirstCarryFruitOpen == true)
                {
                    r1.SetFruit(i);
                    isFirstCarryFruitOpen = false;
                }
                    
                // Fading text appears when fruit is picked up.
                InstantiateTextMesh(fruitNames[i]);

                // First fruit that is picked up is stored.
                if (!isFruitOnGlass && glassFruit == "")
                {
                    glassFruit = fruitNames[i];
                    glassFruitIndex = i;
                }

                // Destroy object(fruit) when triggered.
                Destroy(col.gameObject);
            }
        }

        // EMPTY FRUIT:
        
        // Empty fruits here and check if all fruits are collected.
        if (currentlyHolds != 0 && levelFinished == false && col.gameObject.tag == "Blender")
        {
            // Check glass for fluid.
            CheckFluid(fruitCountTotal.Sum());

            // Start blender animation and send fruitCount so right fruit color can be set on fluid.
            b.BlenderAction(fruitCount, "");

            // Remove sprite from player so he doesn't carry any fruit. 80 is a default value.
            r1.SetFruit(80);
            r2.SetFruit(80);
            r3.SetFruit(80);

            if (!hasSpilled)
                // Check if fruits to complete leves has been collected.
                returnValue = checkLevel.LevelCheck(currentLevel, fruitCount, currentlyHolds, "");

            currentlyHolds = 0;
            p.SetCollected(checkLevel.Counter());

            if (returnValue == "Finished")
                ReadyForNextLevel();
            else if (returnValue != "")
                WrongFruit(returnValue);

            // For each fruit.
            for (int i = 0; i < fruitNames.Length; i++)
            {
                // For each count of that fruit.
                for (int j = 0; j < fruitCount[i]; j++)
                {
                    // Drop as many fruits as in fruitCount into blender.
                    d.DropIntoBlender(fruitNames[i]);
                }
                // Reset fruitCount.
                fruitCount[i] = 0;

                // No fruit were put on glass. Reset values.
                glassFruit = "";
            }
        }
        
        // PUT FRUIT ON GLASS.

        if (currentlyHolds != 0 && levelFinished == false && isFruitOnGlass == false && col.gameObject.tag == "Glass")
        {
            // Places fruit on glass.
            d.DropIntoGlass(glassFruit);
            // Set bool value and decrement fruitCount of fruit that was put on glass.
            isFruitOnGlass = true;
            fruitCount[glassFruitIndex]--;
            fruitCountTotal[glassFruitIndex]--;
            // Remove sprite from player so he doesn't carry first fruit. 80 is a default value.
            r1.SetFruit(80);
            isFirstCarryFruitOpen = true;

            // Check if fruits to complete leves has been collected.
            returnValue = checkLevel.LevelCheck(currentLevel, fruitCount, currentlyHolds, glassFruit);
            currentlyHolds--;
            p.SetGlassCollected(checkLevel.GlassCounter());

            if (returnValue == "Finished")
                ReadyForNextLevel();
            else if (returnValue != "")
                WrongFruit(returnValue);
        }

    } // End of function.

    private bool CheckFluid(float fruitCountTotal)
    {
        // If there is to much fluid in glass.
        if (fruitCountTotal > 11)
        {
            hasSpilled = true;
            // Stop timer.
            p.SetTimer(false);
            // Player cannot pick up more fruit.
            canOnlyHold = 0;
            // Start customer handle.
            c.Action("Spilled");
            anim.SetBool("IsSad", true);
            playerSpeed = 10f;
        }
        // Default return value.
        return false;
    } // End of function

    public void CanMove(bool value)
    {
        canMove = value;
    }

    public void CanPickUp(bool value)
    {
        if (value == false)
            canOnlyHold = currentlyHolds;
        else
            canOnlyHold = 3;
    }

    private void InstantiateTextMesh(string value)
    {
        // Special case for the three apples, change parameter so just "Apple" appears.
        if (value == "Apple green" || value == "Apple red" || value == "Apple yellow")
            value = "Apple";

        // Change text only on textMesh.
        if (isFruitNameChange)
            for (int i = 0; i < NameChangeOnFruit.Count; i += 2)
                if (value == NameChangeOnFruit[i])
                    value = NameChangeOnFruit[i+1];

        // Text when trophy is achieved.
        if (value == "Banana trophy \n   achieved!")
        {
            // Make a clone of textMesh.
            textMeshClone = Instantiate(textMesh, new Vector3(-5.00f, 3.00f, -1.00f), Quaternion.identity) as GameObject;

            textMeshClone.GetComponent<TextMesh>().text = value;                            // Change text on clone.
            var fbs = textMeshClone.GetComponent<FadeOut>();                                // Get access to the objects script.
            fbs.duration = 8.0f;                                                            // Change values.
            fbs.floatSpeed = 0f;                                                            // --- " ---
            textMeshClone.GetComponent<TextMesh>().color = new Color32(255, 255, 0, 255);   // Set color to yellow.
            textMeshClone.transform.localScale = new Vector2(0.16f, 0.16f);                 // Scale up text.

            Destroy(textMeshClone, 8f);     // Destroy clone after 5 seconds.
            f.isActivate = true;            // Activate FadeOut script.
            textMeshClone.SetActive(true);  // Activate clone so it shows.
        }
        else {
            // Make a clone of textMesh.
            textMeshClone = Instantiate(textMesh, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f), Quaternion.identity) as GameObject;

            textMeshClone.GetComponent<TextMesh>().text = value;                            // Change text on clone.
            var fbs = textMeshClone.GetComponent<FadeOut>();                                // Get access to the objects script.
            fbs.duration = 2.0f;                                                            // Change values.
            fbs.floatSpeed = 10f;                                                           // --- " ---

            Destroy(textMeshClone, 2f);     // Destroy clone after 5 seconds.
            f.isActivate = true;            // Activate FadeOut script.
            textMeshClone.SetActive(true);  // Activate clone so it shows.
        }
    }

    private void ReadyForNextLevel()
    {
        // Stop timer.
        p.SetTimer(false);
        SetLevelFinished(true);
        SetLevelCleared(true);
        // Start customer handle.
        c.Action("Finished");
        // Trigger an animation, player shows peace sign.
        anim.SetTrigger("JustFinished");
        anim.SetBool("Finished", true);
        
        playerSpeed = 10f;
    }

    private void WrongFruit(string wrong)
    {
        // Stop timer.
        p.SetTimer(false);
        // Start customer handle.
        c.Action(wrong);
        anim.SetBool("IsSad", true);
        SetLevelFinished(true);
        playerSpeed = 10f;
    }

    // Changes position on fruits the player are holding after level is finished, player are holding the fruit up.
    public void ChangeFruitInHand(bool value)
    {
        // Set trophy sprite when the current saved lvl score is under 500 and new score is over...
        if (!isTrophySet && c.levelScore[currentlyPlayingLvl-1] < 500 && p.score >= 500)
        {
            r2.SetFruit(80); // Remove sprite in r2 position if there are any.
            r3.SetFruit(18); // Set trophy sprite in r3 position. 
            InstantiateTextMesh("Banana trophy \n   achieved!");
            isTrophySet = true;
        }
        // Move sprite.
        if (flipped == true)
            if (value == true)
            {
                r2.transform.position = new Vector2(transform.position.x + 0.75f, transform.position.y + 0.08f);
                r3.transform.position = new Vector2(transform.position.x + 0.75f, transform.position.y + 0.5f);
            }
            else
            {
                r2.transform.position = new Vector2(transform.position.x - 0.48f, transform.position.y - 0.75f);
                r3.transform.position = new Vector2(transform.position.x - 0.06f, transform.position.y - 0.90f);
            }
        else
            if (value == true)
            {
                r2.transform.position = new Vector2(transform.position.x - 0.75f, transform.position.y + 0.08f);
                r3.transform.position = new Vector2(transform.position.x - 0.75f, transform.position.y + 0.5f);
            }
            else
            {
                r2.transform.position = new Vector2(transform.position.x + 0.48f, transform.position.y - 0.75f);
                r3.transform.position = new Vector2(transform.position.x + 0.06f, transform.position.y - 0.90f);
            }
    }

    public void SetPlayerIsSad()
    {
        anim.SetBool("IsSad", true);
        playerSpeed = 10f;
    }

    public void SetLevelFinished(bool value)
    {
        levelFinished = value;
    }

    public void SetLevelCleared(bool value)
    {
        levelCleared = value;
    }

    public void ReadyForRetryClick()
    {
        readyforRetryClick = true;
    }

    // TextMesh override from Customer class. Special cases when you want a fruit text to display something else.
    public void ChangeNameOnFruit(string from, string to)
    {
        isFruitNameChange = true;
        NameChangeOnFruit.Add(from);
        NameChangeOnFruit.Add(to);
    }
}
