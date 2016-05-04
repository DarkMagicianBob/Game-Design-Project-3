using UnityEngine;
using System.Collections;

public class organUScript : MonoBehaviour
{
    //Valid spots you can put the instrument\
    public GameObject canvas;
    int[] range = new int[11];
    int multFreq = 10;
    int frequency;
    int damage = 20;
    int durability = 50;
    int upgradeCost = 1000;
    int resaleCost = 15500;
    int ticks = 0;
    //Where the instrument is currently
    int currentSpot;
    //Where the instrument is to shoot next
    int currentOctave = 0;
    //The tone of the instrument, used when a note is successfully played by an instrument
    int tone = 75;
    //Soundwave projectile
    public GameObject soundwave;
    double tempo;
    bool paused = false;
    int ySpot;
    int xSpot;

    Vector3 mousePosition;
    RaycastHit2D hit;

    public Sprite whiteBox;
    Sprite originalSprite;

    private Vector3 screenPoint;
    private Vector3 originalPosition;
    private Vector3 offset;
    private Vector3 curScreenPoint;
    private Vector3 curPosition;


    // Use this for initialization
    void Start()
    {
        range[0] = 0;
        range[1] = 1;
        range[2] = 2;
        range[3] = 3;
        range[4] = 4;
        range[5] = 5;
        range[6] = 6;
        range[7] = 7;
        range[8] = 8;
        range[9] = 9;
        range[10] = 10;
        frequency = 0;
        calculateSpot();

    }
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
        if (frequency == 0 && GlobalVariables.deltaTimeGlob != 0 && GlobalVariables.tempoToUse != 0)
        {
            frequency = (int)Mathf.Floor(multFreq / (float)GlobalVariables.deltaTimeGlob * (float)GlobalVariables.tempoToUse);
        }
        else if (ticks == frequency)
        {
            GameObject soundwavePlayed1 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (1) * 2), 0), this.transform.rotation);
            soundwavePlayed1.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed1.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed1.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed2 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (2) * 2), 0), this.transform.rotation);
            soundwavePlayed2.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed2.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed2.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed3 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (3) * 2), 0), this.transform.rotation);
            soundwavePlayed3.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed3.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed3.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed4 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (4) * 2), 0), this.transform.rotation);
            soundwavePlayed4.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed4.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed4.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed5 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (5) * 2), 0), this.transform.rotation);
            soundwavePlayed5.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed5.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed5.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed6 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (6) * 2), 0), this.transform.rotation);
            soundwavePlayed6.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed6.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed6.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed7 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (7) * 2), 0), this.transform.rotation);
            soundwavePlayed7.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed7.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed7.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed8 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (8) * 2), 0), this.transform.rotation);
            soundwavePlayed8.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed8.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed8.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed9 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (9) * 2), 0), this.transform.rotation);
            soundwavePlayed9.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed9.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed9.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed10 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (10) * 2), 0), this.transform.rotation);
            soundwavePlayed10.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed10.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed10.GetComponent<soundwaveScript>().stopEarly = true;
            GameObject soundwavePlayed11 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (11) * 2), 0), this.transform.rotation);
            soundwavePlayed11.GetComponent<soundwaveScript>().damage = damage;
            soundwavePlayed11.GetComponent<soundwaveScript>().piercing = true;
            soundwavePlayed11.GetComponent<soundwaveScript>().stopEarly = true;
            ticks = 0;

        }
        else
        {
            ticks += 1;
        }

    }
    public void increaseFrequency()
    {
        multFreq -= 1;
        if (multFreq == 0)
        {
            multFreq = 1;
        }
    }
    public void decreaseFrequency()
    {
        multFreq += 1;
    }
    public void increaseDamage(bool lowOnly)
    {
        if (ySpot <= 6 && lowOnly)
        {
            damage = (int)(damage * 1.5);
        }
        else if (ySpot > 6 && !lowOnly)
        {
            damage = (int)(damage * 1.5);
        }

    }
    public void decreaseDamage(bool lowOnly)
    {
        if (ySpot <= 6 && lowOnly)
        {
            damage = (int)(damage / 1.5);
        }
        else if (ySpot > 6 && !lowOnly)
        {
            damage = (int)(damage / 1.5);
        }

    }

    //Figure out best way to properly position instruments
    void OnMouseDown()
    {
        canvas = GameObject.FindWithTag("menuCanvas");
        canvas.GetComponent<upgradePanelScript>().cancel();
        paused = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        calculateSpot();
        //Debug.Log(gameObject.transform.position.x);
        //Debug.Log(gameObject.transform.position.y);
        //Debug.Log(xSpot);
        //Debug.Log(ySpot);
        GlobalVariables.spaceFilled[ySpot][xSpot] = false;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        originalPosition = transform.position;
        canvas.GetComponent<upgradePanelScript>().instrumentPanel(this.gameObject, xSpot, ySpot, resaleCost, upgradeCost);

    }

    void calculateSpot()
    {
        ySpot = (int)Mathf.Floor((gameObject.transform.position.y + 9.8f) / 2f);
        xSpot = (int)Mathf.Floor((gameObject.transform.position.x - 6.0f) / -2f) - 6;

    }

    /*void OnMouseEnter()
    {
        originalSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = whiteBox;

    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;

    }*/

    void OnMouseDrag()
    {
        curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }
    void OnMouseUp()
    {
        for (int i = 0; i < range.Length; i++)
        {
            if (Mathf.Abs(curPosition.y - (-9.8f + (range[i] + 1) * 2)) < 2f && curPosition.x < -4.8f)
            {
                calculateSpot();
                //Weird positioning thing
                if (xSpot == -1)
                {
                    xSpot = 0;
                }
                if (GlobalVariables.spaceFilled[ySpot][xSpot] != true)
                {
                    GlobalVariables.spaceFilled[ySpot][xSpot] = true;
                    transform.position = new Vector3(-6.0f - 2f * xSpot, -9.8f + (range[i] + 1) * 2, 0f);
                    paused = false;
                    return;

                }

            }
        }
        paused = false;
        transform.position = originalPosition;
        GlobalVariables.spaceFilled[ySpot][xSpot] = true;

    }
}
