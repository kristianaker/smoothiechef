using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RandomStartFruit : MonoBehaviour
{
    public Player player;

    public GameObject appleGreen, appleRed, appleYellow, banana, blueberry, carrot, cherry, coconut, grapefruit, kiwi, lemon,
        lime, orange, pear, pineapple, strawberry, tomato, watermelon;

    public GameObject movingFruit;

    System.Random rnd = new System.Random();

    public void SetFruit()
    {
        int fruit = rnd.Next(0, 18);

        // Spawn point for fruit. (Outside of editor).
        float x = -8f;
        float y = 4;

        switch (fruit)
        {
            case 0:
                movingFruit = Instantiate(appleGreen, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 1:
                movingFruit = Instantiate(appleRed, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 2:
                movingFruit = Instantiate(appleYellow, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 3:
                movingFruit = Instantiate(banana, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 4:
                movingFruit = Instantiate(blueberry, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 5:
                movingFruit = Instantiate(carrot, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 6:
                movingFruit = Instantiate(cherry, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 7:
                movingFruit = Instantiate(coconut, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 8:
                movingFruit = Instantiate(grapefruit, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 9:
                movingFruit = Instantiate(kiwi, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 10:
                movingFruit = Instantiate(lemon, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 11:
                movingFruit = Instantiate(lime, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 12:
                movingFruit = Instantiate(orange, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 13:
                movingFruit = Instantiate(pear, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 14:
                movingFruit = Instantiate(pineapple, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 15:
                movingFruit = Instantiate(strawberry, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 16:
                movingFruit = Instantiate(tomato, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
            case 17:
                movingFruit = Instantiate(watermelon, new Vector2(x, y), Quaternion.identity) as GameObject;
                break;
        } // End switch.

        var fbs = movingFruit.AddComponent<MovingFruit>();  // Adds script to child object. (var fbs can access variables in child object).
        Destroy(movingFruit, 5f);
    }

    public void RestartPress()
    {
        SceneManager.LoadScene(26);
    }
}
