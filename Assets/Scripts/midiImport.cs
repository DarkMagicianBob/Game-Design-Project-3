using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class midiImport : MonoBehaviour {

    // Use this for initialization
    public InputField input;

    public void import()
    {
        string customSong = input.textComponent.text;
        if (!string.IsNullOrEmpty(customSong) && !customSong.Contains("Enter text..."))
        {
            Debug.Log("CUSTOM");
            GlobalVariables.currentSong = customSong;
        }
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
