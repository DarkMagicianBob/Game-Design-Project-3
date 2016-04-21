using UnityEngine;
using System.Collections;

public class tubaScript : MonoBehaviour
{
    //Valid spots you can put the instrument
    int[] range = new int[4];
    //I think if this is set to the deltaTicksPerQuarterNote then it will be able to shoot every quarter note
    public int frequency;
    public int damage = 20;
    int ticks = 0;
    //Where the instrument is currently
    public int currentSpot;
    //The tone of the instrument, used when a note is successfully played by an instrument
    public int tone = 75;
    //Soundwave projectile
    public GameObject soundwave;
    public double tempo;
    bool paused = false;
    bool purchased = false;

    Vector3 mousePosition;
    RaycastHit2D hit;

    private Vector3 screenPoint;
    private Vector3 originalPosition;
    private Vector3 offset;
    private Vector3 curScreenPoint;
    private Vector3 curPosition;


    // Use this for initialization
    void Start()
    {
        range[0] = 1;
        range[1] = 2;
        range[2] = 3;
        range[3] = 4;
        frequency = GlobalVariables.deltaTimeGlob / 8;

    }
    //FIGURE OUT THE BEST WAY TO FIGURE OUT THE FREQUENCY OF FIRING SOUND WAVES
    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            ticks = 0;
        }
        if (GlobalVariables.freezeSoundWaves)
        {
            ticks = 0;
        }
        //Wait until this gets updated
        if (frequency == 0 && tempo == 0)
        {
            frequency = GlobalVariables.deltaTimeGlob / 8;
            UnityEngine.Debug.Log(frequency);
            tempo = GlobalVariables.tempoToUse;
            UnityEngine.Debug.Log(tempo);
        }
        else if (ticks == frequency)
        {
            GameObject soundwavePlayed = (GameObject)Instantiate(soundwave, this.transform.position, this.transform.rotation);
            soundwavePlayed.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed.GetComponent<soundwaveScript>().tone = tone;
            ticks = 0;

        }
        else
        {
            ticks += 1;
        }

    }

    void OnMouseDown()
    {
        UnityEngine.Debug.Log("MouseDown");
        paused = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        originalPosition = transform.position;

    }

    void OnMouseDrag()
    {
        UnityEngine.Debug.Log("MouseDrag");
        curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }
    void OnMouseUp()
    {
        UnityEngine.Debug.Log("MouseUp");
        for (int i = 0; i < range.Length; i++)
        {
            if (Mathf.Abs(curPosition.y - (-9.8f + (range[i] + 1) * 2)) < 2f && curPosition.x < -4.8f)
            {
                transform.position = new Vector3(this.transform.position.x, -9.8f + (range[i] + 1) * 2, 0f);
                paused = false;
                return;

            }
        }
        paused = false;
        transform.position = originalPosition;

    }
}
