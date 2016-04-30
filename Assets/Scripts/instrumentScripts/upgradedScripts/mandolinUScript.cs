using UnityEngine;
using System.Collections;

public class mandolinUScript : MonoBehaviour
{
    //Valid spots you can put the instrument\
    public GameObject canvas;
    int[] range = new int[4];
    int multFreq = 17;
    int frequency;
    int damage = 10;
    int durability = 50;
    int upgradeCost = 700;
    int resaleCost = 350;
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
        range[0] = 3;
        range[1] = 4;
        range[2] = 5;
        range[3] = 6;
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
                    instruments[i].GetComponent<recorderUScript>().increaseFrequency();
                    instruments[i].GetComponent<recorderUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetUScript>().increaseFrequency();
                    instruments[i].GetComponent<clarinetUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteUScript>().increaseFrequency();
                    instruments[i].GetComponent<fluteUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinUScript>().increaseFrequency();
                    instruments[i].GetComponent<mandolinUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonUScript>().increaseFrequency();
                    instruments[i].GetComponent<bassoonUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellUScript>().increaseFrequency();
                    instruments[i].GetComponent<cowbellUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsUScript>().increaseFrequency();
                    instruments[i].GetComponent<drumsUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassUScript>().increaseFrequency();
                    instruments[i].GetComponent<doubleBassUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornUScript>().increaseFrequency();
                    instruments[i].GetComponent<frenchHornUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpUScript>().increaseFrequency();
                    instruments[i].GetComponent<harpUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organUScript>().increaseFrequency();
                    instruments[i].GetComponent<organUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoUScript>().increaseFrequency();
                    instruments[i].GetComponent<pianoUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloUScript>().increaseFrequency();
                    instruments[i].GetComponent<piccoloUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneUScript>().increaseFrequency();
                    instruments[i].GetComponent<saxophoneUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniUScript>().increaseFrequency();
                    instruments[i].GetComponent<timpaniUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneUScript>().increaseFrequency();
                    instruments[i].GetComponent<tromboneUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetUScript>().increaseFrequency();
                    instruments[i].GetComponent<trumpetUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaUScript>().increaseFrequency();
                    instruments[i].GetComponent<tubaUScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinUScript>().increaseFrequency();
                    instruments[i].GetComponent<violinUScript>().increaseFrequency();
                }
            }
            //Not upgraded instruments
            else {
                if (instruments[i].name.Contains("recorder"))
                {
                    instruments[i].GetComponent<recorderScript>().increaseFrequency();
                    instruments[i].GetComponent<recorderScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetScript>().increaseFrequency();
                    instruments[i].GetComponent<clarinetScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteScript>().increaseFrequency();
                    instruments[i].GetComponent<fluteScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinScript>().increaseFrequency();
                    instruments[i].GetComponent<mandolinScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonScript>().increaseFrequency();
                    instruments[i].GetComponent<bassoonScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellScript>().increaseFrequency();
                    instruments[i].GetComponent<cowbellScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsScript>().increaseFrequency();
                    instruments[i].GetComponent<drumsScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassScript>().increaseFrequency();
                    instruments[i].GetComponent<doubleBassScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornScript>().increaseFrequency();
                    instruments[i].GetComponent<frenchHornScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpScript>().increaseFrequency();
                    instruments[i].GetComponent<harpScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organScript>().increaseFrequency();
                    instruments[i].GetComponent<organScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoScript>().increaseFrequency();
                    instruments[i].GetComponent<pianoScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloScript>().increaseFrequency();
                    instruments[i].GetComponent<piccoloScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneScript>().increaseFrequency();
                    instruments[i].GetComponent<saxophoneScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniScript>().increaseFrequency();
                    instruments[i].GetComponent<timpaniScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneScript>().increaseFrequency();
                    instruments[i].GetComponent<tromboneScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetScript>().increaseFrequency();
                    instruments[i].GetComponent<trumpetScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaScript>().increaseFrequency();
                    instruments[i].GetComponent<tubaScript>().increaseFrequency();
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinScript>().increaseFrequency();
                    instruments[i].GetComponent<violinScript>().increaseFrequency();
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
                    instruments[i].GetComponent<recorderUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaUScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinUScript>().decreaseFrequency();
                }
            }
            //Not upgraded instruments
            else {
                if (instruments[i].name.Contains("recorder"))
                {
                    instruments[i].GetComponent<recorderScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("clarinet"))
                {
                    instruments[i].GetComponent<clarinetScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("flute"))
                {
                    instruments[i].GetComponent<fluteScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("mandolin"))
                {
                    instruments[i].GetComponent<mandolinScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("bassoon"))
                {
                    instruments[i].GetComponent<bassoonScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("cowbell"))
                {
                    instruments[i].GetComponent<cowbellScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("drums"))
                {
                    instruments[i].GetComponent<drumsScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("doubleBass"))
                {
                    instruments[i].GetComponent<doubleBassScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("frenchHorn"))
                {
                    instruments[i].GetComponent<frenchHornScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("harp"))
                {
                    instruments[i].GetComponent<harpScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("organ"))
                {
                    instruments[i].GetComponent<organScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("piano"))
                {
                    instruments[i].GetComponent<pianoScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("piccolo"))
                {
                    instruments[i].GetComponent<piccoloScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("saxophone"))
                {
                    instruments[i].GetComponent<saxophoneScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("timpani"))
                {
                    instruments[i].GetComponent<timpaniScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("trombone"))
                {
                    instruments[i].GetComponent<tromboneScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("trumpet"))
                {
                    instruments[i].GetComponent<trumpetScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("tuba"))
                {
                    instruments[i].GetComponent<tubaScript>().decreaseFrequency();
                }
                if (instruments[i].name.Contains("violin"))
                {
                    instruments[i].GetComponent<violinScript>().decreaseFrequency();
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
            soundwavePlayed.GetComponent<soundwaveScript>().burn = true;
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
