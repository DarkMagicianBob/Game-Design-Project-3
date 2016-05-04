using UnityEngine;
using System.Collections;

public class timpaniUScript : MonoBehaviour
{
    //Valid spots you can put the instrument
    public GameObject canvas;
    int[] range = new int[3];
    int multFreq = 10;
    int frequency;
    int damage = 15;
    int durability = 50;
    int upgradeCost = 1000;
    int resaleCost = 3000;
    int ticks = 0;
    //Where the instrument is currently
    int currentSpot;
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
        range[0] = -1;
        range[1] = 2;
        range[2] = 3;
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
            GameObject soundwavePlayed1 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (0) * 2), 0), this.transform.rotation);
            soundwavePlayed1.GetComponent<soundwaveScript>().damage = damage;
            RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector3(this.transform.position.x, (-9.8f + (0) * 2), 0), Vector2.right);
            //Rimshot ability
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.name == "note")
                {
                    hit[i].collider.gameObject.GetComponent<musicNote>().subtractHp(1);
                }
            }
            GameObject soundwavePlayed2 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (3) * 2), 0), this.transform.rotation);
            soundwavePlayed2.GetComponent<soundwaveScript>().damage = damage;
            RaycastHit2D[] hit2 = Physics2D.RaycastAll(new Vector3(this.transform.position.x, (-9.8f + (3) * 2), 0), Vector2.right);
            //Rimshot ability
            for (int i = 0; i < hit2.Length; i++)
            {
                if (hit2[i].collider.gameObject.name == "note")
                {
                    hit2[i].collider.gameObject.GetComponent<musicNote>().subtractHp(1);
                }
            }
            GameObject soundwavePlayed3 = (GameObject)Instantiate(soundwave, new Vector3(this.transform.position.x, (-9.8f + (4) * 2), 0), this.transform.rotation);
            soundwavePlayed3.GetComponent<soundwaveScript>().damage = damage;
            RaycastHit2D[] hit3 = Physics2D.RaycastAll(new Vector3(this.transform.position.x, (-9.8f + (4) * 2), 0), Vector2.right);
            //Rimshot ability
            for (int i = 0; i < hit3.Length; i++)
            {
                if (hit3[i].collider.gameObject.name == "note")
                {
                    hit3[i].collider.gameObject.GetComponent<musicNote>().subtractHp(1);
                }
            }
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
                if (ySpot == -1)
                {
                    ySpot = 0;

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
