using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class midiImport : MonoBehaviour {

    // Use this for initialization
    public InputField input;

    public void import()
    {
        string name = input.textComponent.text;
        GlobalVariables.currentSong = name;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
