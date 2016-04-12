using UnityEngine;
using System.Collections;

public class enemy_health : MonoBehaviour {
    public int life = 3;

    public void TakeDamage(int amount)
    {
        Debug.Log("damage taken");
        life -= amount;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(life <= 0)
        {
            Debug.Log("enemy dead");
            Destroy(this.gameObject);
        }
	}
}
