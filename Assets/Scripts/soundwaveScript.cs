using UnityEngine;
using System.Collections;

public class soundwaveScript : MonoBehaviour {
    //All of the various effects and properties that can be applied to notes
    public int damage;
    public bool slow = false;
    public bool freeze = false;
    public bool burn = false;
    public bool splashDamage = false;
    public bool extraMoney = false;
    public bool extraRep = false;
    //Used for piercing instruments
    public bool piercing = false;
    public bool stopEarly = false;
    int notesHit = 0;
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
            coll.gameObject.GetComponent<musicNote>().subtractHp(damage, slow, burn, extraMoney, freeze);
            if (splashDamage)
            {
                Collider2D[] surroundingNotes = Physics2D.OverlapCircleAll(transform.position, 2f);
                for (int i = 0; i < surroundingNotes.Length; i++)
                {
                    if (surroundingNotes[i].gameObject.tag == "note")
                        surroundingNotes[i].gameObject.GetComponent<musicNote>().subtractHp(damage, slow, burn, extraMoney, freeze, extraRep);
                }
            }
            if (piercing)
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
                if (stopEarly) {
                    notesHit += 1;
                    if (notesHit == 10)
                    {
                        Destroy(this.gameObject);
                    }
                }

            } else {
                Destroy(this.gameObject);
            }
        }
        if (coll.gameObject.tag == "menu")
        {
            Destroy(this.gameObject);
        }
    }
}
