using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class change_description : MonoBehaviour {

    public Text song_name;
    public Text background;
    public string song;
    public string back;

    public void change() { 
        song_name.text = song;
        background.text = back;
        GlobalVariables.song_name = "Assets/" + song + ".mid";
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
