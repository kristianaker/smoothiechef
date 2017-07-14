using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckLevel {

    float glassCount = 0;
    float[] counter = new float[10];
    string flag;

    /** 
     * counter[9] is used as a flag to determine if the variables in the counter array should be summarized or be kept separated, in ProgressBar.SetCollected().
     * counter[9] = 0 (Sum).
     * counter[9] = 1 (Keep separated).
     *
     * When there is to much fruit, count[i] is set to += 99f because then ProgressBar.SetCollected() know when that happens. (For setting red color on textMexh in editor).
     */

    public string LevelCheck (string currentLevel, float[] fruitCount, float currentlyHolds, string glassFruit)
    {
        switch (currentLevel)
        {
            // LEVEL 1:
            case "Level 1":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each BANANA in fruitCount, add to list.
                    for (float i = 0; i < fruitCount[3]; i++)
                        counter[0]++;

                // If more than two BANANAS, return true, ready for next level.
                if (counter[0] >= 4)
                    return "Finished";

            break;

            // LEVEL 2:
            case "Level 2":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each GREEN APPLE in fruitCount, add to list.
                    for (float i = 0; i < fruitCount[0]; i++)
                        counter[0]++;

                // If more than two BANANAS, return true, ready for next level.
                if (counter[0] >= 4)
                    return "Finished";

            break;

            // LEVEL 3:
            case "Level 3":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Add to list if BANANAS or STRAWBERRIES.
                            if (i == 3 || i == 15)

                                // Drop as many BANANAS or STRAWBERRIES as in fruitCount into blender.
                                counter[0]++;
                            else
                                continue;

                // If more than five BANANAS / STRAWBERRIES, return true, ready for next level.
                if (counter[0] >= 5)
                    return "Finished";

            break;

            // LEVEL 4:
            case "Level 4":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Add to list if BLUEBERRIES or COCONUT.
                            if (i == 4 || i == 7)

                                // Drop as many BANANAS or STRAWBERRIES as in fruitCount into blender.
                                counter[0]++;
                            else
                                continue;

                // If more than four BLUEBERRIES and COCONUTS, return true, ready for next level.
                if (counter[0] >= 6)
                    return "Finished";

            break;

            // LEVEL 5:
            case "Level 5":

                // Add glassfruit STRAWBERRY to list.
                if (glassFruit == "Strawberry")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Strawberry" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Return "Wrong2" because the customer doesn't want any fruit in blender.
                            if (fruitCount[i] > 0)
                                return "Wrong2";

                // If more than four BLUEBERRIES and COCONUTS, return true, ready for next level.
                if (glassCount >= 1)
                    return "Finished";

            break;

            // LEVEL 6:
            case "Level 6":

                // Add glassfruit KIWI to list.
                if (glassFruit == "Kiwi")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Kiwi" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Add to list if BANANA or TOMATO.
                            if (i == 3 || i == 16)

                                // Drop as many BANANAS or STRAWBERRIES as in fruitCount into blender.
                                counter[0]++;
                            else
                                continue;

                // If more than five BANANAS or TOMATOS + KIWI, return true, ready for next level.
                if (counter[0] >= 5 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 7:
            case "Level 7":

                // Add glassfruit ORANGE to list.
                if (glassFruit == "Orange")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Orange" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Add to list if BLUEBERRIES or WATERMELON.
                            if (i == 4 || i == 17)

                                // Drop as many BANANAS or STRAWBERRIES as in fruitCount into blender.
                                counter[0]++;
                            else
                                continue;

                // If more than six BLUEBERRIES or WATERMELON + ORANGE, return true, ready for next level.
                if (counter[0] >= 6 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 8:
            case "Level 8":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Add to list if GREEN APPLES.
                            if (i == 0)
                            {
                                // Drop as many GREEN APPLES as in fruitCount into blender.
                                counter[0]++;

                                // To many GREEN APPLES.
                                if (counter[0] > 5)
                                {
                                    counter[0] += 99f;
                                    return "Wrong2";
                                }
                            }
                            // Return wrong when other fruit is dropped into blender.
                            else
                                return "Wrong1";

                // If more than five GREEN APPLES, return true, ready for next level.
                if (counter[0] >= 5)
                    return "Finished";

            break;

            // LEVEL 9:
            case "Level 9":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // If APPLES and PINEAPPLES, return wrong.
                    if (fruitCount[0] > 0 && fruitCount[14] > 0)
                        return "Wrong1";

                    // If APPLES only, return wrong.
                    else if (fruitCount[0] > 0 && fruitCount[14] == 0)
                        return "Wrong2";

                    // If PINEAPPLES only.
                    else if (fruitCount[0] == 0 && fruitCount[14] > 0)
                        
                        // For each count of PINEAPPLE.
                        for (int j = 0; j < fruitCount[14]; j++)
                        {
                            counter[0]++;

                            // Check if there is more fruit that wanted.
                            if (counter[0] > 7)
                            {
                                counter[0] += 99f;
                                return "Wrong3";
                            }
                        }

                // If seven PINEAPPLES, return true, ready for next level.
                if (counter[0] >= 7)
                    return "Finished";

            break;

            // LEVEL 10:
            case "Level 10":

                // Add glassfruit STRAWBERRY to list.
                if (glassFruit == "Strawberry")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Strawberry" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Return wrong when other fruit is dropped into blender.
                            if (i != 5 && i != 8 && i != 12)
                                return "Wrong2";

                            // Add to list if CARROT, GRAPEFRUIT or ORANGE.
                            else if (i == 5 || i == 8 || i == 12)
                            {
                                // Drop as many fruits as in fruitCount into blender.
                                counter[0]++;

                                // Check if there is more fruit that wanted.
                                if (counter[0] > 6)
                                {
                                    counter[0] += 99f;
                                    return "Wrong3";
                                }
                            }

                // If six CARROTS, GRAPFRUITS or ORANGES + STRAWBERRY, return true, ready for next level.
                if (counter[0] >= 6 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 11:
            case "Level 11":

                // Add glassfruit LIME to list.
                if (glassFruit == "Lime")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Lime" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // LEMON and STRAWBERRY.
                    if (currentlyHolds == 2 && (fruitCount[10] == 1 && fruitCount[15] == 1 || 
                    // PINEAPPLE and STRAWBERRY.    
                        fruitCount[14] == 1 && fruitCount[15] == 1))
                    {
                        counter[0] += 2;

                        // To much.
                        if (counter[0] > 6)
                        {
                            counter[0] += 99f;
                            return "Spilled";
                        }
                    }
                    else
                        return "Wrong2";
                        
                // If more than six orange fruits + LEMON, return true, ready for next level.
                if (counter[0] >= 6 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 12:
            case "Level 12":

                // Add glassfruit BLUEBERRY to list.
                if (glassFruit == "Blueberry")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Blueberry" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")
                {
                    if (currentlyHolds == 2 && fruitCount[4] == 1 && fruitCount[15] == 1 ||     // BLUEBERRY and STRAWBERRY, (purple).
                        currentlyHolds == 2 && fruitCount[4] == 1 && fruitCount[17] == 1)       // BLUEBERRY and WATERMELON, (purple).
                        counter[0] += 2;

                    else if (currentlyHolds == 2 && fruitCount[3] == 1 && fruitCount[4] == 1 || // BANANA and BLUEBERRY, (green).
                             currentlyHolds == 2 && fruitCount[10] == 1 && fruitCount[4] == 1)  // LEMON and BLUEBERRY, (green).
                        counter[1] += 2;
                    else if (currentlyHolds == 1 && fruitCount[11] == 1 || currentlyHolds == 2 && fruitCount[11] == 2 || currentlyHolds == 3 && fruitCount[11] == 3) // LIME, (green).
                        counter[1] += currentlyHolds;
                    else
                        return "Wrong2";

                    // Check fruit count.
                    if (counter[0] > 4) {
                        counter[0] += 99f;
                        return "Wrong3";
                    }
                    if (counter[1] > 2) {
                        counter[1] += 99f;
                        return "Wrong3";
                    }
                        
                }

                // Flag to determine if the variables should be summarized or be kept separated, in ProgressBar.SetCollected().
                // counter[9] = 0 (Sum).
                // counter[9] = 1 (Keep separated).
                counter[9] = 1;

                // If more than six fruits + BLUEBERRY, return true, ready for next level.
                if (counter[0] == 4 && counter[1] == 2 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 13:
            case "Level 13":

                // Add glassfruit BLUEBERRY to list.
                if (glassFruit == "Grapefruit")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Grapefruit" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")
                {
                    // Orange and white together, wrong.
                    if (fruitCount[8] > 0 && fruitCount[0] > 0 || fruitCount[8] > 0 && fruitCount[1] > 0 || fruitCount[8] > 0 && fruitCount[2] > 0 || fruitCount[8] > 0 && fruitCount[7] > 0 ||
                        fruitCount[12] > 0 && fruitCount[0] > 0 || fruitCount[12] > 0 && fruitCount[1] > 0 || fruitCount[12] > 0 && fruitCount[2] > 0 || fruitCount[12] > 0 && fruitCount[7] > 0)
                        return "Wrong2";
                    
                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            if (i == 0 || i == 1 || i == 2 || i == 7)  // APPLES or COCONUT, (white).
                                counter[0]++;
                            else if (i == 8 || i == 12)                // GRAPEFRUIT or ORANGE, (orange).
                                counter[1]++;
                            else
                                return "Wrong2";

                    // Check fruit count.
                    if (counter[0] > 4)
                    {
                        counter[0] += 99f;
                        return "Wrong3";
                    }
                    if (counter[1] > 5)
                    {
                        counter[1] += 99f;
                        return "Wrong3";
                    }

                }

                // Flag to determine if the variables should be summarized or be kept separated, in ProgressBar.SetCollected().
                // counter[9] = 0 (Sum).
                // counter[9] = 1 (Keep separated).
                counter[9] = 1;

                // If more than six fruits + BLUEBERRY, return true, ready for next level.
                if (counter[0] == 4 && counter[1] == 5 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 14:
            case "Level 14":

                // Add glassfruit BLUEBERRY to list.
                if (glassFruit == "Apple green")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Apple green" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")
                {
                    // STRAWBERRY && ( PEAR, APPLE GREEN, APPLE YELLOW, COCONUT ). (Same but with tomato under).
                    if (currentlyHolds == 2 && (fruitCount[15] == 1 && fruitCount[13] == 1 || fruitCount[15] == 1 && fruitCount[0] == 1 || fruitCount[15] == 1 && fruitCount[2] == 1 || fruitCount[15] == 1 && fruitCount[7] == 1 ||
                        fruitCount[16] == 1 && fruitCount[13] == 1 || fruitCount[16] == 1 && fruitCount[0] == 1 || fruitCount[16] == 1 && fruitCount[2] == 1 || fruitCount[16] == 1 && fruitCount[7] == 1))

                        counter[0] += 2;

                    // PEAR.
                    else if (fruitCount[13] > 0)
                    
                        // For each fruit.
                        for (int i = 0; i < fruitCount.Length; i++)

                            // For each count of that fruit.
                            for (int j = 0; j < fruitCount[i]; j++)

                                if (i == 13)  // PEAR.
                                    counter[1]++;
                                else
                                    return "Wrong1";    // PEAR with other fruit.
                    else
                        return "Wrong1";                // Other fruit without pear.

                    // Check fruit count.
                    if (counter[0] > 4)
                    {
                        counter[0] += 99f;
                        return "Wrong2";
                    }
                    if (counter[1] > 7)
                    {
                        counter[1] += 99f;
                        return "Wrong2";
                    }

                }

                // Flag to determine if the variables should be summarized or be kept separated, in ProgressBar.SetCollected().
                // counter[9] = 0 (Sum).
                // counter[9] = 1 (Keep separated).
                counter[9] = 1;

                // If more than six fruits + BLUEBERRY, return true, ready for next level.
                if (counter[0] == 4 && counter[1] == 7 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 15:
            case "Level 15":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // FIRST smoothie layer.
                    // CARROTS, or BANANA/STRAWBERRY, (orange).
                    if (counter[1] == 0 && (currentlyHolds == fruitCount[5] || currentlyHolds == 2 && fruitCount[3] == 1 && fruitCount[15] == 1))
                        counter[0] = 1;

                    // SECOND smoothie layer.
                    else if (counter[0] > 0 && currentlyHolds == fruitCount[4])
                        counter[1] = 1;

                    // THIRD smoothie layer.
                    else if (counter[1] > 0 && currentlyHolds == fruitCount[3])
                        counter[2] = 1;

                    else
                        return "Wrong1";

                // If all three smoothie layers is ok, return true, ready for next level.
                if (counter[2] > 0)
                    return "Finished";

            break;

            // LEVEL 16:
            case "Level 16":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // FIRST smoothie layer.
                    // TOMATO / (WATERMELOM), (red).
                    if (counter[1] == 0 && (currentlyHolds == fruitCount[16] || currentlyHolds == fruitCount[17] || currentlyHolds == fruitCount[16] + fruitCount[17]))
                        counter[0] = 1;

                    // SECOND smoothie layer.
                    // LEMON with APPLES, (yellow).
                    else if (counter[0] > 0 && (currentlyHolds == fruitCount[10] || currentlyHolds == fruitCount[10] + fruitCount[0] ||
                                                currentlyHolds == fruitCount[10] + fruitCount[1] || currentlyHolds == fruitCount[10] + fruitCount[2]))
                        counter[1] = 1;

                    // THIRD smoothie layer.
                    // BLUEBERRY and TOMATO / (WATERMELON), (purple).
                    else if (counter[1] > 0 && currentlyHolds == 2 && (fruitCount[4] == 1 && fruitCount[16] == 1 || fruitCount[4] == 1 && fruitCount[17] == 1))
                        counter[2] = 1;

                    // FOURTH smoothie layer.
                    // (green).
                    else if (counter[2] > 0 && currentlyHolds == 1 && (fruitCount[9] == 1 || fruitCount[11] == 1) ||    // KIWI or LIME.
                             counter[2] > 0 && currentlyHolds == 2 && fruitCount[9] == 1 && fruitCount[11] == 1 ||      // KIWI and LIME.
                             counter[2] > 0 && currentlyHolds == 2 && fruitCount[4] == 1 && fruitCount[10] == 1)        // BLUEBERRY and LEMON.
                        counter[3] = 1;

                    else
                        return "Wrong1";

                // If all three smoothie layers is ok, return true, ready for next level.
                if (counter[3] > 0)
                    return "Finished";

                // Apple green = 0, Apple red = 1, Apple yellow = 2, Banana = 3, Blueberry = 4, Carrot = 5, Cherry = 6, Coconut = 7, Grapefruit = 8,
                // Kiwi = 9, Lemon = 10, Lime = 11, Orange = 12, Pear = 13, Pineapple = 14, Strawberry = 15, Tomato = 16, Watermelon = 17

            break;

            // LEVEL 17:
            case "Level 17":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // FIRST smoothie layer.
                    // Color RED, every combination of strawberry and watermelon.
                    if (counter[1] == 0 && (currentlyHolds == 1 && (fruitCount[15] == 1 || fruitCount[17] == 1) ||
                                            currentlyHolds == 2 && ((fruitCount[15] == 1 && fruitCount[17] == 1) ||
                                                                    (fruitCount[15] == 2 || fruitCount[17] == 2)) ||
                                            currentlyHolds == 3 && ((fruitCount[15] == 3 || fruitCount[17] == 3) ||
                                                                    (fruitCount[15] == 2 && fruitCount[17] == 1) ||
                                                                    (fruitCount[17] == 2 && fruitCount[15] == 1))))
                        counter[0] = 1;

                    // SECOND smoothie layer.
                    // Color DARK ORANGE.
                    else if (counter[0] > 0 && (currentlyHolds == 1 && fruitCount[8] == 1 ||
                                                currentlyHolds == 2 && ((fruitCount[15] == 1 && fruitCount[5] == 1) ||
                                                                       (fruitCount[15] == 1 && fruitCount[12] == 1) ||
                                                                       (fruitCount[17] == 1 && fruitCount[5] == 1) ||
                                                                       (fruitCount[17] == 1 && fruitCount[12] == 1)) ||
                                                currentlyHolds == 3 && ((fruitCount[15] == 1 && fruitCount[17] == 1 && fruitCount[3] == 1) ||
                                                                       (fruitCount[15] == 1 && fruitCount[17] == 1 && fruitCount[10] == 1) ||
                                                                       (fruitCount[15] == 2 && fruitCount[3] == 1) ||
                                                                       (fruitCount[15] == 2 && fruitCount[10] == 1) ||
                                                                       (fruitCount[17] == 2 && fruitCount[3] == 1) ||
                                                                       (fruitCount[17] == 2 && fruitCount[10] == 1))))
                        counter[1] = 1;

                    // THIRD smoothie layer.
                    // Color ORANGE.
                    else if (counter[1] > 0 && (currentlyHolds == 1 && (fruitCount[5] == 1 || fruitCount[12] == 1) ||
                                                currentlyHolds == 2 && ((fruitCount[15] == 1 && fruitCount[3] == 1) ||
                                                                        (fruitCount[15] == 1 && fruitCount[10] == 1) ||
                                                                        (fruitCount[17] == 1 && fruitCount[3] == 1) ||
                                                                        (fruitCount[17] == 1 && fruitCount[10] == 1) ||
                                                                        (fruitCount[5] == 1 && fruitCount[12] == 1)) ||
                                                currentlyHolds == 3 && ((fruitCount[5] == 3 || fruitCount[12] == 3) ||
                                                                        (fruitCount[5] == 2 && fruitCount[12] == 1) ||
                                                                        (fruitCount[12] == 2 && fruitCount[5] == 1))))
                        counter[2] = 1;

                    // FOURTH smoothie layer.
                    // Color LIGHT ORANGE.
                    else if (counter[2] > 0 && (currentlyHolds == 2 && ((fruitCount[5] == 1 && fruitCount[3] == 1) ||
                                                                       (fruitCount[5] == 1 && fruitCount[10] == 1) ||
                                                                       (fruitCount[12] == 1 && fruitCount[3] == 1) ||
                                                                       (fruitCount[12] == 1 && fruitCount[10] == 1)) ||
                                                currentlyHolds == 3 && ((fruitCount[3] == 1 && fruitCount[10] == 1 && fruitCount[15] == 1) ||
                                                                       (fruitCount[3] == 1 && fruitCount[10] == 1 && fruitCount[17] == 1) ||
                                                                       (fruitCount[3] == 2 && fruitCount[15] == 1) ||
                                                                       (fruitCount[3] == 2 && fruitCount[17] == 1) ||
                                                                       (fruitCount[10] == 2 && fruitCount[15] == 1) ||
                                                                       (fruitCount[10] == 2 && fruitCount[17] == 1))))
                        counter[3] = 1;

                    // FIFTH smoothie layer.
                    // Color, YELLOW.
                    else if (counter[3] > 0 && (currentlyHolds == 1 && (fruitCount[3] == 1 || fruitCount[10] == 1) ||
                                                currentlyHolds == 2 && ((fruitCount[3] == 1 && fruitCount[10] == 1) ||
                                                                        (fruitCount[3] == 2 || fruitCount[10] == 2)) ||
                                                currentlyHolds == 3 && ((fruitCount[3] == 3 || fruitCount[10] == 3) ||
                                                                        (fruitCount[3] == 2 && fruitCount[10] == 1) ||
                                                                        (fruitCount[10] == 2 && fruitCount[3] == 1))))
                        counter[4] = 1;

                    else
                        return "Wrong1";

                // If all five smoothie layers is ok, return true, ready for next level.
                if (counter[4] > 0)
                    return "Finished";

            break;

            // LEVEL 18:
            case "Level 18":

                // Add glassfruit Banana to list.
                if (glassFruit == "Banana")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Banana" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // When green apples or banana are dropped into blender.
                            if (i != 4)
                                return "Wrong2";
                            // Add to list if BLUE APPLES.
                            else if (i == 4)
                                counter[0]++;

                // If more than nine BLUE APPLES + BANANA, return true, ready for next level.
                if (counter[0] == 9 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 19:
            case "Level 19":

                // Add glassfruit Tomato to list.
                if (glassFruit == "Tomato")
                    glassCount++;
                // Return "Wrong" when other fruit is set on glass. Also excludes "" because false positiv when fruit is dropped into blender.
                else if (glassFruit != "Tomato" && glassFruit != "")
                    return "Wrong1";

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)
                        {
                            // When other fruits are dropped into blender.
                            if (i != 4)
                                return "Wrong2";
                            // Add to list if BLUE APPLES.
                            else if (i == 4)
                                counter[0]++;

                            // If to much BLUE APPLES.
                            if (counter[0] > 9)
                            {
                                counter[0] += 99f;
                                return "Spilled";
                            }
                        }

                // If more than nine BLUE APPLES + TOMATO, return true, ready for next level.
                if (counter[0] == 9 && glassCount == 1)
                    return "Finished";

            break;

            // LEVEL 20:
            case "Level 20":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)
                            
                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Add to list if any citrus (GRAPEFRUIT, LEMON, LIME or ORANGE).
                            if (i == 8 || i == 10 || i == 11 || i == 12)
                                counter[0]++;
                            else
                                continue;

                // If more than eleven fruits, return true, ready for next level.
                if (counter[0] == 10)
                    return "Finished";

                break;

            // LEVEL 21:
            case "Level 21":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)

                            // Add to list if LEMON or LIME.
                            if (i == 10 || i == 11)
                                counter[0]++;
                            else
                                return "Wrong1";

                // If more than eleven fruits, return true, ready for next level.
                if (counter[0] == 6)
                    return "Finished";

            break;

            // LEVEL 22:
            case "Level 22":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)
                        {
                            if (i == 16)
                                counter[0] += 1f; // TOMATO.
                            else if (i == 4)
                                counter[1] += 1f; // BLUEBERRY.
                            else if (i == 8)
                                counter[2] += 1f; // GRAPEFRUIT.
                            else
                                return "Wrong1";

                            // Set variable to 99 when too much because then ProgressBar.SetCollected() know there is to much of that fruit.
                            if (counter[0] < 99 && counter[0] > 3f)
                                counter[0] += 99f;
                            if (counter[1] < 99 && counter[1] > 3f)
                                counter[1] += 99f;
                            if (counter[2] < 99 && counter[2] > 3f)
                                counter[2] += 99f;
                        }

                if (counter[0] > 3f || counter[1] > 3f || counter[2] > 3f)
                    return "Wrong1";

                // Flag to determine if the variables should be summarized or be kept separated, in ProgressBar.SetCollected().
                // counter[9] = 0 (Sum).
                // counter[9] = 1 (Keep separated).
                counter[9] = 1;

                // If more than eleven fruits, return true, ready for next level.
                if (counter[0] == 3f && counter[1] == 3f && counter[2] == 3f)
                    return "Finished";

                break;

            // LEVEL 23:
            case "Level 23":

                // Only add to list if glassFruit is empty, that means this function is called from "drop fruit into blender".
                if (glassFruit == "")

                    // For each fruit.
                    for (int i = 0; i < fruitCount.Length; i++)

                        // For each count of that fruit.
                        for (int j = 0; j < fruitCount[i]; j++)
                        {
                            // Add to list if .
                            if (i == 3)
                            {
                                counter[0] += 0.5f; // half LEMON count.
                                counter[1] += 0.5f; // half ORANGE count.
                            }
                            else if (i == 5)
                            {
                                counter[0] += 0.5f; // half LEMON count.
                                counter[2] += 0.5f; // half GRAPEFRUIT count.
                            }
                            else if (i == 9)
                            {
                                counter[0] += 0.5f; // half LEMON count.
                                counter[3] += 0.5f; // half LIME count.
                            }
                            else if (i == 8)
                                counter[2]++; // GRAPEFRUIT count.
                            else if (i == 10)
                                counter[0]++; // LEMON count.
                            else if (i == 11)
                                counter[3]++; // LIME count.
                            else if (i == 12)
                                counter[1]++; // ORANGE count.

                            // Set variable to 99 when too much because then ProgressBar.SetCollected() know there is to much of that fruit.
                            if (counter[0] < 99 && counter[0] > 2f)
                                counter[0] += 99f;
                            if (counter[1] < 99 && counter[1] > 1.5f)
                                counter[1] += 99f;
                            if (counter[2] < 99 && counter[2] > 1.5f)
                                counter[2] += 99f;
                            if (counter[3] < 99 && counter[3] > 2f)
                                counter[3] += 99f;
                        }

                if (counter[0] > 2f || counter[1] > 1.5f || counter[2] > 1.5f || counter[3] > 2f)
                    return "Wrong1";

                // Flag to determine if the variables should be summarized or be kept separated, in ProgressBar.SetCollected().
                // counter[9] = 0 (Sum).
                // counter[9] = 1 (Keep separated).
                counter[9] = 1;

                // If more than eleven fruits, return true, ready for next level.
                if (counter[0] == 2 && counter[1] == 1.5f && counter[2] == 1.5f && counter[3] == 2)
                    return "Finished";

            break;

                // Apple green = 0, Apple red = 1, Apple yellow = 2, Banana = 3, Blueberry = 4, Carrot = 5, Cherry = 6, Coconut = 7, Grapefruit = 8,
                // Kiwi = 9, Lemon = 10, Lime = 11, Orange = 12, Pear = 13, Pineapple = 14, Strawberry = 15, Tomato = 16, Watermelon = 17
        }

        // Default return value. Level is not complete.
        return "";
    }

    public float[] Counter()
    {
        return counter;
    }

    public float GlassCounter()
    {
        return glassCount;
    }
}
