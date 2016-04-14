using UnityEngine;
using System.Collections;

public class soundwaveScript : MonoBehaviour {
    public int damage = 0;
    public int tone = 0;
    float speed = 10;
    Vector3 moveAmount;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moveAmount.x = speed * Time.deltaTime;
        transform.Translate(moveAmount);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "note" && coll.gameObject.GetComponent<musicNote>().dead == false)
        {
            coll.gameObject.GetComponent<musicNote>().subtractHp(damage, tone);
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "menu")
        {
            Destroy(this.gameObject);
        }
    }
}
