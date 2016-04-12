using UnityEngine;
using System.Collections;

public class bullet_move : MonoBehaviour {
    public Transform target;
    public float speed = 15f;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.GetComponent<enemy_health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);
	}
}
