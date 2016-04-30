using UnityEngine;
using System.Collections;
using NAudio.Midi;

public class instrumentMenuScript : MonoBehaviour {
    public static MidiOut toMute;

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
        toMute.Volume = 0;

    }
    void OnMouseExit()
    {
        Time.timeScale = 1;
        GlobalVariables.freezeSoundWaves = false;
        toMute.Volume = 65535;
    }
}
