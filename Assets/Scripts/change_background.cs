using UnityEngine;
using System.Collections;

public class change_background : MonoBehaviour {
    public void load(string background)
    {
        GlobalVariables.currentBackground = background;
        Debug.Log(GlobalVariables.currentBackground);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
