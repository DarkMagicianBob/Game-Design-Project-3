using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class create_menu : MonoBehaviour {
	public GameObject[] lane_buttons;
	public GameObject background;
	public GameObject ccanvas;
	private GameObject button;
	Button menu;

	void Awake(){
		menu = GetComponent<Button> ();
		menu.onClick .AddListener (() => spawn ());
	}

	public void spawn(){
		GameObject bbackground = Instantiate (background, transform.position, transform.rotation) as GameObject;
		bbackground.transform.SetParent (ccanvas.transform, false);
		bbackground.tag = "menu";
		float i = -6f;
		foreach (GameObject go in lane_buttons) {
			button = Instantiate (go, transform.position, transform.rotation) as GameObject;
			button.transform.SetParent (ccanvas.transform, false);
			button.tag = "menu";
			button.transform.position += new Vector3 (0f, 25f * i, 0f);
			i++;
		}
		menu.onClick.AddListener (() => dst ());
	}

	public void dst(){
		GameObject[] gameobjects = GameObject.FindGameObjectsWithTag ("menu");
		foreach (GameObject go in gameobjects) {
			Destroy (go);
		}
		Awake ();
	}

	void Start(){
	}

	// Update is called once per frame
	void Update () {
	
	}
}
