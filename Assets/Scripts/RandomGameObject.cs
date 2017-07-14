using UnityEngine;
using System.Collections;

public class RandomGameObject : MonoBehaviour {

	public Sprite appleGreen, appleRed, appleYellow, banana, blueberry, carrot, cherry, coconut, grapefruit, kiwi, lemon,
        lime, orange, pear, pineapple, strawberry, tomato, watermelon, trophy;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFruit(int fruit)
    {
        switch (fruit)
        {
            case 0:
                spriteRenderer.sprite = appleGreen;
                break;
            case 1:
                spriteRenderer.sprite = appleRed;
                break;
            case 2:
                spriteRenderer.sprite = appleYellow;
                break;
            case 3:
                spriteRenderer.sprite = banana;
                break;
            case 4:
                spriteRenderer.sprite = blueberry;
                break;
            case 5:
                spriteRenderer.sprite = carrot;
                break;
            case 6:
                spriteRenderer.sprite = cherry;
                break;
            case 7:
                spriteRenderer.sprite = coconut;
                break;
            case 8:
                spriteRenderer.sprite = grapefruit;
                break;
            case 9:
                spriteRenderer.sprite = kiwi;
                break;
            case 10:
                spriteRenderer.sprite = lemon;
                break;
            case 11:
                spriteRenderer.sprite = lime;
                break;
            case 12:
                spriteRenderer.sprite = orange;
                break;
            case 13:
                spriteRenderer.sprite = pear;
                break;
            case 14:
                spriteRenderer.sprite = pineapple;
                break;
            case 15:
                spriteRenderer.sprite = strawberry;
                break;
            case 16:
                spriteRenderer.sprite = tomato;
                break;
            case 17:
                spriteRenderer.sprite = watermelon;
                break;
            case 18:
                spriteRenderer.sprite = trophy;
                gameObject.transform.localScale = new Vector2(1.2f, 1.2f);
                break;
            default:
                spriteRenderer.sprite = null;
                spriteRenderer.color = new Color(255f, 255f, 255f, 255f);
                break;
        } // End switch.
    }
}
