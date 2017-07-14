using UnityEngine;
using System.Collections;

public class Fluid : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FillGlass(Color32 color)
    {
        spriteRenderer.color = color;
    }
}
