using UnityEngine;
using System.Collections;

public class enemy_detect : MonoBehaviour {
    public bool forward;
    public int range = 50;
    public float cooldown = 1f;
    public Vector3 direction = new Vector3(1f, 0f, 0f);
    public GameObject bullet;
    private RaycastHit hit;
    private bool ready = true;

    public IEnumerator wait (float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        ready = true;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Physics.Raycast(transform.position, direction, out hit, range) && hit.collider.tag == "Enemy" && ready)
        {
            Debug.Log("object foud");
            GameObject clone_bullet = Instantiate(bullet, transform.position + direction, transform.rotation) as GameObject;
            clone_bullet.GetComponent<bullet_move>().target = hit.transform;
            ready = false;
            StartCoroutine(wait(cooldown));
        }
	}
}
