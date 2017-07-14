using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class Blender : MonoBehaviour {

    public Fluid f, s;

    public GameObject fluid, spill;

    private Animator anim;

    // Colors to be mixed with Lerp() and returned. Categorized to keep track in special cases.
    Color32 a, b, c, d,
        aa, bb;

    // Fluid position.
    private float x = -1.382f, y = -9.412f;

    public int currentLevel, newColorsfilledTimes;

    // Different fruits and the respective color.
    string[] fruitNames = new string[18] { "Apple green", "Apple red", "Apple yellow", "Banana", "Blueberry", "Carrot", "Cherry", "Coconut", "Grapefruit", "Kiwi", "Lemon", "Lime", "Orange", "Pear", "Pineapple", "Strawberry", "Tomato", "Watermelon" };
    string[] fruitNamesColor = new string[18] { "beige", "beige", "beige", "yellow", "blue", "orange", "red", "white", "darkOrange", "green", "yellow", "green", "orange", "beige", "yellow", "red", "red", "red" };

    // Return these colors based on the array above, red ::::::::::::::::::::::blue::::::::::::::::::::::: green ::::::::::::::::::::::::: yellow :::::::::::::::::::::::: orange :::::::::::::::::::::::::: white :::::::::::::::::::::: beige :::::::::::::::::::::::::: dark orange ::::::::::::::: <------------------------ new colors ---------------------------------------->
    Color32[] fruitColors = new Color32[11] { new Color32(255, 0, 0, 255), new Color32(0, 0, 255, 255), new Color32(172, 255, 0, 255), new Color32(255, 255, 0, 255), new Color32(255, 127, 0, 255), new Color32(255, 255, 255, 255), new Color32(255, 255, 216, 255), new Color32(255, 63, 0, 255), new Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255) };

    // Counts instances of different colors pr blender mix; 0 = red ::: 1 = blue ::: 2 = green ::: 3 = yellow ::: 4 = orange ::: 5 = white ::: 6 = beige.
    float[] fruitColorCount = new float[11];

    private Color32 color;
    private int numberOfColors, timesGlassIsFilled;

    bool singelColor, doubleColor;

    void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update ()
    {
        // Just for debugging.
        //Debug.Log("fruitColorCount[0]: " + fruitColorCount[0] + " fruitColorCount[1]: " + fruitColorCount[1] + " fruitColorCount[2]: " + fruitColorCount[2] + " fruitColorCount[3]: " + fruitColorCount[3]);
    }
	
	public void BlenderAction (float[] fruitCount, string flag)
    {
        // Generate right color for fruit (mix).
        color = ChooseColor(fruitCount);

        //Debug.Log("color: " + color);

        // Coroutune because of timer on blender animation.
        // Send in parameters color to be set on fluid, and sum of fruitCount to measure fluid.
        StartCoroutine(WaitFor(color, fruitCount.Sum()));
    }

    IEnumerator WaitFor (Color32 color, float fruitCountSum)
    {
        // Blender animation starts.
        anim.SetBool("IsOn", true);

        // Wait.
        yield return new WaitForSeconds(1f);

        // Blender animation stops.
        anim.SetBool("IsOn", false);

        // Fills glass with fluid.
        f.FillGlass(color);
        s.FillGlass(color);

        // Copy and create fluid object then set its position.
        InstantiateFluid(fruitCountSum);
    }

    public Color32 ChooseColor (float[] fruitCount)
    {
        // Set colors to a standard value / Reset from last loop.
        ResetColorValues();
        
        // Reset fruitColorCount.
        for (int i = 0; i < fruitColorCount.Length; i++)
            fruitColorCount[i] = 0;

        // For each fruit.
        for (int i = 0; i < fruitNamesColor.Length; i++)
        {
            // For each count of that fruit.
            for (int j = 0; j < fruitCount[i]; j++)
            {
                // Store and sort right ammount of different colors in new array fruitColorCount[].
                switch (fruitNamesColor[i])
                {
                    case "red":
                        fruitColorCount[0]++;
                        numberOfColors++;
                        break;
                    case "blue":
                        fruitColorCount[1]++;
                        numberOfColors++;
                        break;
                    case "green":
                        fruitColorCount[2]++;
                        numberOfColors++;
                        break;
                    case "yellow":
                        fruitColorCount[3]++;
                        numberOfColors++;
                        break;
                    case "orange":
                        fruitColorCount[4]++;
                        numberOfColors++;
                        break;
                    case "white":
                        fruitColorCount[5]++;
                        numberOfColors++;
                        break;
                    case "beige":
                        fruitColorCount[6]++;
                        numberOfColors++;
                        break;
                    case "darkOrange":
                        fruitColorCount[7]++;
                        numberOfColors++;
                        break;
                    case "newColor1":
                        fruitColorCount[8]++;
                        numberOfColors++;
                        break;
                    case "newColor2":
                        fruitColorCount[9]++;
                        numberOfColors++;
                        break;
                    case "newColor3":
                        fruitColorCount[10]++;
                        numberOfColors++;
                        break;
                }
            }
        }

        // RETURN SINGEL/MIXED COLORS:

        // Return singel color.
        if (numberOfColors == 1)
        {
            // Reset value.
            numberOfColors = 0;

            for (int i = 0; i < fruitColorCount.Length; i++)
            {
                // Only one color is stored, enter when hit.
                if (fruitColorCount[i] != 0)
                {
                    // Return singel color.
                    return fruitColors[i];
                }
            }
        }
        // Return mixed colors.
        else if (numberOfColors == 2)
        {
            // Reset value.
            numberOfColors = 0;

            for (int i = 0; i < fruitColorCount.Length; i++)
            {
                // Spesial case when two of the colors are of same type, then return this.
                if (fruitColorCount[i] == 2)
                    return fruitColors[i];

                // Enter when this color is used.
                else if (fruitColorCount[i] == 1)
                {
                    // Special case so a is set first and only one time.
                    if (a == Color.black)
                    {
                        a = fruitColors[i];
                        // Continue loop for next color to be set.
                        continue;
                    }
                    // b is set second.
                    b = fruitColors[i];
                    // a & b are now filled and no need for further loop, then break.
                    break;
                }
                // Special case when no color is stored here, then continue loop.
                else if (fruitColorCount[i] == 0)
                    continue;
            }
            // Special case for blue and yellow, because it returns grey with lerp() function.
            if (a.Equals(new Color32(0, 0, 255, 255)) && b.Equals(new Color32(255, 255, 0, 255)))
                return new Color32(0, 255, 0, 255);

            // Return mixed color, a & b, 50% blended.
            return Color32.Lerp(a, b, 0.5f);
        }

        else if (numberOfColors == 3)
        {
            // Reset value.
            numberOfColors = 0;

            for (int i = 0; i < fruitColorCount.Length; i++)
            {
                // Special case when all three of the colors are of same type, then return this.
                if (fruitColorCount[i] == 3)
                    return fruitColors[i];

                // Special case when 2/3 of the colors are of same type, store these two and continue loop.
                else if (fruitColorCount[i] == 2)
                {
                    // If this is set, that means that two of the colors are of same type.
                    doubleColor = true;

                    // aa & bb are the same color.
                    aa = fruitColors[i];
                    bb = fruitColors[i];

                    // Next loop cycle.
                    continue;
                }
                // 
                else if (fruitColorCount[i] == 1)
                {
                    // Special case so a is set first and only one time.
                    if (a == Color.black)
                    {
                        a = fruitColors[i];

                        // Next loop cycle.
                        continue;
                    }
                    // Special case so b is set second.
                    else if (b == Color.black)
                    {
                        // If it reaches this far, that means that all three colors are different from each other.
                        singelColor = true;

                        b = fruitColors[i];
                        // Next loop cycle.
                        continue;
                    }
                    // Special case so c is set third and last.
                    else if (c == Color.black)
                    {
                        c = fruitColors[i];
                        // Next loop cycle.
                        continue;
                    }
                }
                // Special case when no color is stored here, then continue loop.
                else if (fruitColorCount[i] == 0)
                    continue;
            }

            // COLORS MIXED:

            // Lerp() based on if there are two of the same color.
            if (doubleColor)
            {
                d = Color32.Lerp(aa, a, 0.5f);
                return Color32.Lerp(d, bb, 0.5f);
            }
            // Lerp() based on if all three colors are different.
            else if (singelColor)
            {
                d = Color32.Lerp(a, b, 0.5f);
                return Color32.Lerp(c, d, 0.5f);
            }
        }
        // For all other values, return cyan.
        return Color.cyan;
    }

    private void ResetColorValues()
    {
        // Set colors to a standard value / Reset from last loop.
        a = Color.black;
        b = Color.black;
        c = Color.black;
        d = Color.black;

        aa = Color.black;
        bb = Color.black;

        singelColor = false;
        doubleColor = false;
    }

    private void InstantiateFluid(float fruitCountSum)
    {
        for (int i = 0; i < fruitCountSum; i++)
        {
            // Special case when there is to much fluid and its reaching out of glass. Activate spill and set its color.
            if (timesGlassIsFilled > 10)
            {
                Instantiate(spill, new Vector2(-1.4f, -9.7f), Quaternion.identity);
                break;
            }
                
            // Creates a new fluid and place it in the glass.
            Instantiate(fluid, new Vector2(x, y), Quaternion.identity);

            // New position for fluid so it creates a feeling of filling the glass.
            y += 0.2f;

            // Keep track of how much fluid is in glass.
            timesGlassIsFilled++;
        }
    }

    public void ChangeColorOnFruit(string fruit, byte r, byte g, byte b)
    {
        int index = 0;

        switch (fruit)
        {
            case "Apple green": index = 0; break;
            case "Apple red": index = 1; break;
            case "Apple yellow": index = 2; break;
            case "Banana": index = 3; break;
            case "Blueberry": index = 4; break;
            case "Carrot": index = 5; break;
            case "Cherry": index = 6; break;
            case "Coconut": index = 7; break;
            case "Grapefruit": index = 8; break;
            case "Kiwi": index = 9; break;
            case "Lemon": index = 10; break;
            case "Lime": index = 11; break;
            case "Orange": index = 12; break;
            case "Pear": index = 13; break;
            case "Pineapple": index = 14; break;
            case "Strawberry": index = 15; break;
            case "Tomato": index = 16; break;
            case "Watermelon": index = 17; break;
        }

        if (newColorsfilledTimes == 0)
        {
            fruitColors[8] = new Color32(r, g, b, 255);
            fruitNamesColor[index] = "newColor1";
        }
        else if (newColorsfilledTimes == 1)
        {
            fruitColors[9] = new Color32(r, g, b, 255);
            fruitNamesColor[index] = "newColor2";
        }
        else if (newColorsfilledTimes == 2)
        {
            fruitColors[10] = new Color32(r, g, b, 255);
            fruitNamesColor[index] = "newColor3";
        }

        newColorsfilledTimes++;
    }
}
