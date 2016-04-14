using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMoney : MonoBehaviour {

    Text money;

	// Use this for initialization
	void Start () {
        money = GetComponent<Text>();
        money.text = "Money: $" + GlobalVariables.cashAtHand;
	
	}
	
	// Update is called once per frame
	void Update () {

        money.text = "Money: $" + GlobalVariables.cashAtHand;
	
	}
}
