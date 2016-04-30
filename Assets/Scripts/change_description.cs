using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class change_description : MonoBehaviour {

    public Text song_name;
    public Text background;
    public string song;
    public string back;

    public void changeSong(string songName) { 
        song_name.text = songName;
    }
    public void changeBackgroundInfo(string backgroundInfo)
    {
        background.text = backgroundInfo;
    }

	// Use this for initialization
	void Start () {
        song_name = GameObject.FindGameObjectWithTag("songName").GetComponent<Text>();
        background = GameObject.FindGameObjectWithTag("backgroundInfo").GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
