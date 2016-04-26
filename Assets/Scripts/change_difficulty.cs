using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class change_difficulty : MonoBehaviour {
    public Dropdown menu;

    public void difficulty()
    {
        string num = menu.captionText.text;
        int nnum = int.Parse(num);
        GlobalVariables.difficulty = nnum;
        Debug.Log(nnum.ToString() + num);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
