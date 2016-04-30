using UnityEngine;
using System.Collections;

public class gongScript : MonoBehaviour
{
    //Valid spots you can put the instrument
    public GameObject canvas;
    int xSpot;
    int ySpot;


    // Use this for initialization
    void Start()
    {
        GameObject[] allNotes = GameObject.FindGameObjectsWithTag("note");
        for (int i = 0; i < allNotes.Length; i++)
        {
            allNotes[i].GetComponent<musicNote>().subtractHp(100);
            Destroy(gameObject);
        }
        calculateSpot();
        GameObject hpBar = GameObject.FindGameObjectWithTag("audienceBar");
        hpBar.GetComponent<audienceBar>().earnReputation(25);
        GlobalVariables.spaceFilled[ySpot][xSpot] = false;
        Destroy(gameObject);

    }

    void calculateSpot()
    {
        ySpot = (int)Mathf.Floor((gameObject.transform.position.y + 9.8f) / 2f);
        xSpot = (int)Mathf.Floor((gameObject.transform.position.x - 6.0f) / -2f) - 6;

    }
}
