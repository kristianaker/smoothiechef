using UnityEngine;
using System.Collections;

public class MovingFruit : MonoBehaviour {

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        var pos = new Vector2(250, 0);
        transform.Translate(pos * Time.deltaTime * 0.01f);
    }
}
