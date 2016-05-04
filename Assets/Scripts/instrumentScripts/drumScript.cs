using UnityEngine;
using System.Collections;

public class drumScript : MonoBehaviour
{
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
            ticks = 0;

        }
        else
        {
            ticks += 1;
        }

    }
    //Drums stay in one lane so you cannot actually move drums
}
