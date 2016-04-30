using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Used for upgrading or selling an instrument in-game
public class upgradePanelScript : MonoBehaviour {
    public Button genericButton;
    public Text messageBox;
    public GameObject recorderU;
    public GameObject clarinetU;
    public GameObject fluteU;
    public GameObject tubaU;
    public GameObject saxophoneU;
    public GameObject drumsU;
    public GameObject harpU;
    public GameObject violinU;
    public GameObject bassoonU;
    public GameObject pianoU;
    public GameObject organU;
    public GameObject mandolinU;
    public GameObject trumpetU;
    public GameObject tromboneU;
    public GameObject piccoloU;
    public GameObject frenchHornU;
    public GameObject doubleBassU;
    public GameObject timpaniU;
    public GameObject cowbellU;
    //Includes information on what gets upgraded and how much it costs
    private Button[] arrayOfButtons;
    //Upgrade
    //Sell
    //Exit (takes up the screen)
    public GameObject background;
    GameObject bbackground;
    int x;
    int y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void instrumentPanel(GameObject instrument, int xSpot, int ySpot, int resale, int cost) {
        x = xSpot;
        y = ySpot;
        arrayOfButtons = new Button[3];
        bbackground = Instantiate(background, new Vector3(this.transform.position.x + 433f, this.transform.position.y + 0f, this.transform.position.z), transform.rotation) as GameObject;
        bbackground.transform.SetParent(this.transform, false);
        bbackground.tag = "menu";

        Text messageBoxx = Instantiate(messageBox, this.transform.position, this.transform.rotation) as Text;
        if (instrument.name.Contains("recorder")) {
            messageBoxx.text = "Well, hey it's better than nothing. Get an additional 5 damage on this unit.";
        }
        if (instrument.name.Contains("clarinet"))
        {
            messageBoxx.text = "Make your smooth clarinet jazz daddy play just a little bit faster AND have a higher chance of slowing down notes";
        }
        if (instrument.name.Contains("flute"))
        {
            messageBoxx.text = "Now your flute can hit three lanes at one, making defeating notes that much easier";
        }
        if (instrument.name.Contains("tuba"))
        {
            messageBoxx.text = "Now your tuba can cause burn damage AND shoot faster";
        }
        if (instrument.name.Contains("saxophone"))
        {
            messageBoxx.text = "Now your crowd appeal applies to the audience bar as well (plus you can move your instrument to the C3 lane)";
        }
        if (instrument.name.Contains("drums"))
        {
            messageBoxx.text = "Now your drums can rimshot all other notes in the drumlane making notes in the drum lane that much easier to defeat";
        }
        if (instrument.name.Contains("harp"))
        {
            messageBoxx.text = "Now your harp can shoot faster and cause a slowdown at C1 and C7";
        }
        if (instrument.name.Contains("violin"))
        {
            messageBoxx.text = "Your violin notes now pierce all the way to the end, plus it shoots faster";
        }
        if (instrument.name.Contains("flute"))
        {
            messageBoxx.text = "Now your flute can hit three lanes at one, making defeating notes that much easier";
        }
        if (instrument.name.Contains("bassoon"))
        {
            messageBoxx.text = "Now your bassoon boosts the power of all low-octave notes, making all notes in that range much easier to defeat";
        }
        if (instrument.name.Contains("piano"))
        {
            messageBoxx.text = "Now your piano can shoot all reachable lanes at once!";
        }
        if (instrument.name.Contains("organ"))
        {
            messageBoxx.text = "Now your organ has both piercing shot and higher frequency! CRAZY!";
        }
        if (instrument.name.Contains("mandolin"))
        {
            messageBoxx.text = "Now instruments go even faster and your mandolin itself now has salvageable damage";
        }
        if (instrument.name.Contains("trumpet"))
        {
            messageBoxx.text = "Slight damage increase, nothing too special, sorry";
        }
        if (instrument.name.Contains("trombone"))
        {
            messageBoxx.text = "Now your trombone has a better attack range";
        }
        if (instrument.name.Contains("piccolo"))
        {
            messageBoxx.text = "Now your piccolo increases the damage of all instruments in higher octaves! Rad!";
        }
        if (instrument.name.Contains("frenchHorn"))
        {
            messageBoxx.text = "Now your audience bar gets boosted even further plus your french horn gets better damage";
        }
        if (instrument.name.Contains("doubleBass"))
        {
            messageBoxx.text = "Now your double bass shoots faster plus selects which lane needs its one shot";
        }
        if (instrument.name.Contains("cowbell"))
        {
            messageBoxx.text = "More cowbell! Go MSU!";
        }
        messageBoxx.transform.SetParent(bbackground.transform, false);
        messageBoxx.transform.localScale = new Vector3(1, .5f, 1);
        messageBoxx.transform.position += new Vector3(0f, -1f, 0f);

        float i = 10f;
        arrayOfButtons[0] = Instantiate(genericButton, this.transform.position, this.transform.rotation) as Button;
        arrayOfButtons[0].transform.SetParent(bbackground.transform, false);
        arrayOfButtons[0].transform.localScale = new Vector3(1, .5f, 1);
        arrayOfButtons[0].tag = "menu";
        arrayOfButtons[0].transform.position += new Vector3(0f, -32f + 2f * i, 0f);
        arrayOfButtons[0].GetComponentInChildren<Text>().text = "Exit";
        arrayOfButtons[0].onClick.AddListener(() => cancel());
        i++;
        arrayOfButtons[1] = Instantiate(genericButton, this.transform.position, this.transform.rotation) as Button;
        arrayOfButtons[1].transform.SetParent(bbackground.transform, false);
        arrayOfButtons[1].transform.localScale = new Vector3(1, .5f, 1);
        arrayOfButtons[1].tag = "menu";
        arrayOfButtons[1].GetComponentInChildren<Text>().text = "Sell Instrument ($" + resale +")";
        arrayOfButtons[1].transform.position += new Vector3(0f, -32 + 2f * i, 0f);
        arrayOfButtons[1].onClick.AddListener(() => sellInstrument(instrument, xSpot, ySpot, resale));
        i++;
        if (!instrument.name.Contains("Upgrade")) {
            arrayOfButtons[2] = Instantiate(genericButton, this.transform.position, this.transform.rotation) as Button;
            arrayOfButtons[2].transform.SetParent(bbackground.transform, false);
            arrayOfButtons[2].transform.localScale = new Vector3(1, .5f, 1);
            arrayOfButtons[2].tag = "menu";
            arrayOfButtons[2].GetComponentInChildren<Text>().text = "Upgrade Instrument ($" + cost + ")";
            arrayOfButtons[2].transform.position += new Vector3(0f, -32 + 2f * i, 0f);
            arrayOfButtons[2].onClick.AddListener(() => upgradeInstrument(instrument, cost));
        }
        
    }
    public void cancel()
    {
        if (bbackground != null) {
            Destroy(bbackground);
            for (int i = 0; i < arrayOfButtons.Length; i++)
            {
                if (arrayOfButtons[i] != null)
                    Destroy(arrayOfButtons[i]);
            }
        }
    }
    void sellInstrument(GameObject instrument, int xSpot, int ySpot, int resale)
    {
        Destroy(instrument);
        GlobalVariables.spaceFilled[ySpot][xSpot] = false;
        GlobalVariables.cashAtHand += resale;
        Debug.Log("Instrument sold");
        cancel();

    }
    void upgradeInstrument(GameObject instrument, int upgradeCost)
    {
        GlobalVariables.cashAtHand -= upgradeCost;
        if (instrument.name.Contains("recorder")) {
            Instantiate(recorderU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("clarinet"))
        {
            Instantiate(clarinetU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("flute"))
        {
            Instantiate(fluteU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("tuba"))
        {
            Instantiate(tubaU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("saxophone"))
        {
            Instantiate(saxophoneU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("drums"))
        {
            Instantiate(drumsU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("harp"))
        {
            Instantiate(harpU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("violin"))
        {
            Instantiate(violinU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("bassoon"))
        {
            Instantiate(bassoonU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("piano"))
        {
            Instantiate(pianoU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("organ"))
        {
            Instantiate(organU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("mandolin"))
        {
            Instantiate(mandolinU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("trumpet"))
        {
            Instantiate(trumpetU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("trombone"))
        {
            Instantiate(tromboneU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("piccolo"))
        {
            Instantiate(piccoloU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("frenchHorn"))
        {
            Instantiate(frenchHornU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("doubleBass"))
        {
            Instantiate(doubleBassU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("timpani"))
        {
            Instantiate(timpaniU, instrument.transform.position, instrument.transform.rotation);
        }
        else if (instrument.name.Contains("cowbell"))
        {
            Instantiate(cowbellU, instrument.transform.position, instrument.transform.rotation);
        }
        Destroy(instrument);
        cancel();

    }
}
