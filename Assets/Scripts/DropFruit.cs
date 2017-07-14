using UnityEngine;
using System.Collections;

public class DropFruit : MonoBehaviour {

    public GameObject appleGreen, appleRed, appleYellow, banana, blueberry, carrot, cherry, coconut, grapefruit, kiwi, lemon,
        lime, orange, pear, pineapple, strawberry, tomato, watermelon;

    public GameObject halfAppleGreen, halfAppleRed, halfAppleYellow, halfBanana, halfBlueberry, halfCarrot, halfCherry, halfCoconut, halfGrapefruit, halfKiwi, halfLemon,
        halfLime, halfOrange, halfPear, halfPineapple, halfStrawberry, halfTomato, halfWatermelon;

    // Position for fruit to be dropped from into blender.
    private float x, y;

    // Time it takes before object gets destroyed.
    private float destroyTime = 1f;

    void Start()
    {
        
    }

    public void DropIntoBlender(string fruit)
    {
        x = -4f;
        y = -2.5f;

        try {

            switch (fruit)
            {
                case "Apple green":
                    Destroy(Instantiate(appleGreen, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Apple red":
                    Destroy(Instantiate(appleRed, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Apple yellow":
                    Destroy(Instantiate(appleYellow, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Banana":
                    Destroy(Instantiate(banana, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Blueberry":
                    Destroy(Instantiate(blueberry, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Carrot":
                    Destroy(Instantiate(carrot, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Cherry":
                    Destroy(Instantiate(cherry, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Coconut":
                    Destroy(Instantiate(coconut, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Grapefruit":
                    Destroy(Instantiate(grapefruit, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Kiwi":
                    Destroy(Instantiate(kiwi, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Lemon":
                    Destroy(Instantiate(lemon, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Lime":
                    Destroy(Instantiate(lime, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Orange":
                    Destroy(Instantiate(orange, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Pear":
                    Destroy(Instantiate(pear, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Pineapple":
                    Destroy(Instantiate(pineapple, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Strawberry":
                    Destroy(Instantiate(strawberry, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Tomato":
                    Destroy(Instantiate(tomato, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
                case "Watermelon":
                    Destroy(Instantiate(watermelon, new Vector2(x, y), Quaternion.identity), destroyTime);
                    break;
            }
        } catch (UnassignedReferenceException) {

        }
    }

    public void DropIntoGlass(string fruit)
    {
        x = -1.917f;
        y = -7.3f;

        try {

            switch (fruit)
            {
                case "Apple green":
                    Instantiate(halfAppleGreen, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Apple red":
                    Instantiate(halfAppleRed, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Apple yellow":
                    Instantiate(halfAppleYellow, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Banana":
                    Instantiate(halfBanana, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Blueberry":
                    Instantiate(halfBlueberry, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Carrot":
                    Instantiate(halfCarrot, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Cherry":
                    Instantiate(halfCherry, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Coconut":
                    Instantiate(halfCoconut, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Grapefruit":
                    Instantiate(halfGrapefruit, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Kiwi":
                    Instantiate(halfKiwi, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Lemon":
                    Instantiate(halfLemon, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Lime":
                    Instantiate(halfLime, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Orange":
                    Instantiate(halfOrange, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Pear":
                    Instantiate(halfPear, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Pineapple":
                    Instantiate(halfPineapple, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Strawberry":
                    Instantiate(halfStrawberry, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Tomato":
                    Instantiate(halfTomato, new Vector2(x, y), Quaternion.identity);
                    break;
                case "Watermelon":
                    Instantiate(halfWatermelon, new Vector2(x, y), Quaternion.identity);
                    break;
            }
        } catch (UnassignedReferenceException) {

        }
    }
}
