using UnityEngine;
using System.Collections;

public class bassoonUScript : MonoBehaviour
{
    //Valid spots you can put the instrument\
    public GameObject canvas;
    int[] range = new int[4];
    int multFreq = 10;
    int frequency;
    int damage = 10;
    int durability = 50;
    int upgradeCost = 500;
    int resaleCost = 4100;
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

    public Sprite whiteBox;
    Sprite originalSprite;

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
        frequency = 0;
        calculateSpot();

        GameObject[] instruments = GameObject.FindGameObjectsWithTag("instrument");
        for (int i = 0; i < instruments.Length; i++)
        {
            //Upgraded instruments
            if (instruments[i].name.Contains("Upgrade"))
            {
                if (instruments[i].name.Contains("recorder"))
                {
                    instruments[i].GetComponent<recorderUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaUScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinUScript>().increaseDamage(true);
                }
            }
            //Not upgraded instruments
            else {
                if (instruments[i].name.Contains("recorder"))
                {
                    instruments[i].GetComponent<recorderScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaScript>().increaseDamage(true);
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinScript>().increaseDamage(true);
                }
            }
        }

    }

    void OnDestroy()
    {
        GameObject[] instruments = GameObject.FindGameObjectsWithTag("instrument");
        for (int i = 0; i < instruments.Length; i++)
        {
            //Upgraded instruments
            if (instruments[i].name.Contains("Upgrade"))
            {
                if (instruments[i].name.Contains("recorder"))
                {
                    instruments[i].GetComponent<recorderUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaUScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinUScript>().decreaseDamage(true);
                }
            }
            //Not upgraded instruments
            else {
                if (instruments[i].name.Contains("recorder"))
                {
                    instruments[i].GetComponent<recorderScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaScript>().decreaseDamage(true);
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinScript>().decreaseDamage(true);
                }
            }
        }

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
            GameObject soundwavePlayed = (GameObject)Instantiate(soundwave, this.transform.position, this.transform.rotation);
            soundwavePlayed.GetComponent<soundwaveScript>().damage = damage;
            if (Random.value * 100 <= 3)
            {
                soundwavePlayed.GetComponent<soundwaveScript>().freeze = true;

            }
            else if (Random.value * 10 <= 5)
            {
                soundwavePlayed.GetComponent<soundwaveScript>().slow = true;
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

    void OnMouseEnter()
    {
        originalSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = whiteBox;

    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;

    }

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
