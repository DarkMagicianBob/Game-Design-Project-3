using UnityEngine;
using System.Collections;

public class instrumentMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseEnter()
    {
        Time.timeScale = 0;
        GlobalVariables.freezeSoundWaves = true;

    }
    void OnMouseExit()
    {
        Time.timeScale = 1;
        GlobalVariables.freezeSoundWaves = false;
    }
}
