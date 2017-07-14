using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

    public new TextMesh guiText;
    public float duration = 2f, floatSpeed = 125f;
    float initialTime;
    public bool isActivate, isSet;

    void Update ()
    {
        // Is activated from Player script.
        if (isActivate)
            ActivateText();
    }

    void ActivateText ()
    {
        // Set initialTime only once.
        if (!isSet)
        {
            initialTime = Time.time;
            isSet = true;
        }

        // Destroy object after given time.
        if (Time.time - initialTime > duration)
            Destroy(gameObject);

        // guiText fades out.
        Color myColor = guiText.color;
        float ratio = (Time.time - initialTime) / duration;
        myColor.a = Mathf.Lerp(1, 0, ratio);
        guiText.color = myColor;

        // guiText floats up in y-direction.
        var pos = new Vector2(0, floatSpeed);
        transform.Translate(pos * Time.deltaTime * 0.01f);
    }
}
