using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class genericSpawner : MonoBehaviour {
    public string instrument;
    int price;
    string message;
    public Text messageBox;
    public GameObject instrumentPrefab;
    public Button genericButton;
    private Button[] arrayOfButtons;
    public GameObject background;
    GameObject bbackground;
    public GameObject ccanvas;
    private Button button;

    Text buttonText;

    Button spawner;

    void Awake()
    {
        if (instrument == "recorder")
        {
            price = 50;
            message = "Recorder:\n" +
                "The most basic of all instruments.  Does little damage but attacks at a steady rate.\n" +
                "It's special ability is that it is really freaking cheap.\n" +
                "Cost: $50\n" +
                "Damage: 5\n" +
                "Frequency: 25\n" +
                "Range: C4-C6\n" +
                "Durability: N/A\n\n" +
                "Can be upgraded to get higher damage (+5) for an additional $100";
        }
        if (instrument == "clarinet")
        {
            price = 650;
            message = "Clarient:\n" +
                "A middle of the road woodwind that has the special ability to occasionally slow down a note (about 30 %)\n" +
                "Cost: $650\n" +
                "Damage: 20\n" +
                "Frequency: 18\n" +
                "Range: C3-C6\n" +
                "Durability: N/A\n\n" +
                "Can be upgraded to increase the frequency of the clarient by 10 for an additional $300";
        }
        if (instrument == "flute")
        {
            price = 1500;
            message = "Flute:\n" +
                "An absolute speed demon that resides on the higher registers but has lower damage to balance it out\n" +
                "Cost: $1500\n" +
                "Damage: 5\n" +
                "Frequency: 3\n" +
                "Range: C4-C7\n" +
                "Durability: N/A\n\n" +
                "Can be upgraded to allow it to attack one octave above (in additional to its normal octave) for a whopping $1000";
        }
        if (instrument == "tuba")
        {
            message = "Tuba:\n" +
                "One of the strongest instruments around who lurks on the lower registers.  Attacks slowly but surely.\n" +
                "Also has splash damage that can hit other nearby enemies in a radius. Somewhat expensive.\n" +
                "Cost: $4000\n" +
                "Damage: 40\n" +
                "Frequency: 50\n" +
                "Range: C1-C4\n" +
                "Durability: N/A\n\n" +
                "Can be upgraded to attack faster and also cause burn damage which damages notes over time for $300 more.";
            price = 4000;
        }
        if (instrument == "saxophone")
        {
            message = "Saxophone:\n" +
                "This epic instrument is what is needed to really drive the crowd appeal.  Use this instrument to generate extra money upon defeating a note.\n" +
                "Is mediocre otherwise, surprisingly.\n" +
                "Cost: $2000\n" +
                "Damage: 10\n" +
                "Frequency: 16\n" +
                "Range: C4-C6\n" +
                "Durability: N/A\n\n" +
                "Can be upgraded to allow movement to C3, increase damage, and increase the audience bar even further upon defeating a note for an extra $500.";
            price = 2000;
        }
        if (instrument == "drums")
        {
            message = "Drums:\n" +
                "Your standard percussion instrument.  Is the bread and butter of the percussion lane and is relatively inexpensive.  All the cool kids play drums.\n" +
                "Cost: $1000\n" +
                "Damage: 5\n" +
                "Frequency: 5\n" +
                "Range: Percussion\n" +
                "Durability: N/A\n\n" +
                "Can be upgraded to generate a rimshot attack which damages all active notes in the percussion lane for an additional $700";
            price = 1000;
        }
        if (instrument == "harp")
        {
            message = "Harp:\n" +
                "This angelic instrument has more than meets the eye.  It can hit all octaves in its range in a downward motion.\n" +
                "A bit slow and full of itself, however.\n" +
                "Cost: $1750\n" +
                "Damage: 15\n" +
                "Frequency: 10\n" +
                "Range: C1-C7\n" +
                "Durability: N/A\n" +
                "Can be upgraded to play notes faster and also generate a slowdown note on C1 and C7 for an extra $300";
            price = 1750;
        }
        if (instrument == "violin")
        {
            message = "Violin:\n" +
                "This instrument has a shrill, piercing sound that can go through multiple notes at once, which allows it cover a lot of ground.\n" +
                "Because the soundwaves are going through so many notes, notes produced by this instrument will stop after piercing 10 notes.\n" +
                "Cost: $700\n" +
                "Damage: 5\n" +
                "Frequency: 20\n" +
                "Range: C3-C7\n" +
                "Durability: N/A\n\n" +
                "Now your notes are strong enough to get all the way to the end.  But only if you upgrade with $500.";
            price = 700;
        }
        if (instrument == "bassoon")
        {
            message = "Bassoon:\n" +
                "This is the Big Bertha of instruments.  Although this instrument is expensive, it has great utility in the lower octaves.\n" +
                "It has a higher chance to slow notes, and even has a chance to completely freeze a note. Plus, when upgraded, all towers are boosted.\n" +
                "Cost: $7700\n" +
                "Damage: 5\n" +
                "Frequency: 20\n" +
                "Range: C3-C7\n" +
                "Durability: N/A\n\n" +
                "This unit can function as an aid to all instruments from C0-C6, boosting an attack by 1.5X.  You will need $500 more, but you've already got the largest expense out of the way.";
            price = 7700;
        }
        if (instrument == "piano")
        {
            message = "Piano:\n" +
                "Elegant and refined, this instrument is a staple for all big name bands.  This instrument can hit many lanes at once, covering both treble and bass clefts and is pretty fast to boot.\n" +
                "Shoots in a pattern of one low note and one high note in a V pattern.\n" +
                "Cost: $3000\n" +
                "Damage: 5\n" +
                "Frequency: 10\n" +
                "Range: C3-C7\n" +
                "Durability: N/A\n\n" +
                "Upgraded, this unit can reach all reachable octaves all at the same time, making it quite far-reaching.  But now it shoots a little slower. Try it for $500 more.";
            price = 3000;
        }
        if (instrument == "organ")
        {
            message = "Organ:\n" +
                "This is the PINNACLE of all instruments.  Able to cover ALL octaves barring percussion and boasting really good stats, this instrument does it all.\n" +
                "But the price tag is... well... HEHEHEHEHEHE!\n" +
                "Cost: $30000\n" +
                "Damage: 20\n" +
                "Frequency: 15\n" +
                "Range: C0-C11\n" +
                "Durability: N/A\n\n" +
                "Upgrade this instrument and you don't even need instruments anymore.  Piercing AND higher frequency.  The price is only... $1000.";
            price = 30000;
        }
        if (instrument == "mandolin")
        {
            message = "Mandolin:\n" +
                "This guitar prototype from the middle ages, although not much on its own, can be used to keep other instruments on your team upbeat and increase shot speed. Hip and radical, dude!\n" +
                "Cost: $700\n" +
                "Damage: 7\n" +
                "Frequency: 17\n" +
                "Range: C3-C6\n" +
                "Durability: N/A\n\n" +
                "Make your mandolin actually contribute to the team and make your teammates work even harder by forking over $700.";
            price = 700;
        }
        if (instrument == "trumpet")
        {
            message = "Trumpet:\n" +
                "Every orchestra needs some brass instruments and trumpets are your footsoldiers in the musical battlefield.  Not only are they strong but they also cause burning damage.  Mighty mighty.\n" +
                "Cost: $1100\n" +
                "Damage: 15\n" +
                "Frequency: 15\n" +
                "Range: C3-C6\n" +
                "Durability: N/A\n\n" +
                "Not every upgrade will be amazing, but hey at least this one's cheap. Pay $200 and your trumpet will shoot down its foes faster.";
            price = 1100;
        }
        if (instrument == "trombone")
        {
            message = "Trombone:\n" +
                "Potentially powerful but also potentially weak, the trombone has damage that can go all over the place.  It could knock out foes in one hit or just lightly scrape them.\n" +
                "If you are willing to take a risk, the trombone may be worth it, however, because it is the cheapest bass instrument and has great frequency.\n" +
                "Cost: $1400\n" +
                "Damage: 1-30\n" +
                "Frequency: 10\n" +
                "Range: C0-C5\n" +
                "Durability: N/A\n\n" +
                "Now you don't have to worry about terrible damage anymore.  The trombone's range can range from 5-35 if you are willing to let go of $700.";
            price = 1400;
        }
        if (instrument == "piccolo")
        {
            message = "Piccolo:\n" +
               "This little songbird is an upper register powerhouse which has trades a little frequency for higher damage; plus it can pierce notes.\n" +
               "Cost: $3500\n" +
               "Damage: 15\n" +
               "Frequency: 5\n" +
               "Range: C5-C8\n" +
               "Durability: N/A\n\n" +
               "The piccolo can also act as a damage increase tower for other instruments but only if you pay $1000. Thems the breaks.";
            price = 3500;
        }
        if (instrument == "frenchHorn")
        {
            message = "French Horn:\n" +
               "Despite being a middle of the road instrument in terms of normal utility, the french horn has an ability that no other instrument has.\n" +
               "It can act as a wall and increase the max value of your audience bar! Plus it also generates double audience points if used to play a note.\n" +
               "Cost: $4700\n" +
               "Damage: 15\n" +
               "Frequency: 12\n" +
               "Range: C2-C5\n" +
               "Durability: N/A\n\n" +
               "If you pay $500 more, you can further boost your audience bar and your french horn can have increased damage.";
            price = 4700;
        }
        if (instrument == "doubleBass")
        {
            message = "Double Bass:\n" +
               "The double bass functions as the violin of the lower registers.  Although it has piercing shot and enviable damage, it has the slowest frequency of all instruments.\n" +
               "But if you're willing to look past it's slow speed, you shall see a valuable instrument.\n" +
               "Cost: $2000\n" +
               "Damage: 18\n" +
               "Frequency: 75\n" +
               "Range: C1-C5\n" +
               "Durability: N/A\n\n" +
               "With an extra $500, the speed of your double bass will not seem so shabby.  It will actually be the best bass instrument at that point.";
            price = 2000;
        }
        if (instrument == "cowbell")
        {
            message = "Cowbell:\n" +
               "Show off your school spirit with this silly little percussion instrument. VERY cheap but essentially useless, barring its ability to generate extra money in the percussion lane.\n" +
               "Cost: $5\n" +
               "Damage: 1\n" +
               "Frequency: 15\n" +
               "Range: Percussion\n" +
               "Durability: N/A\n\n" +
               "If you upgrade your cowbell with $100, than it will get a slight boost in attack and frequency.  I have a fever and it calls for more cowbell!";
            price = 5;
        }
        if (instrument == "timpani")
        {
            message = "Timpani:\n" +
               "The timpani may be one of the strangest instruments in the game.  Despite being a percussion instrument, it can also hit two octave lanes as well at the same time.\n" +
               "Because of its double utility, the price is quite dear, however, so keep that in mind.\n" +
               "Cost: $6000\n" +
               "Damage: 15\n" +
               "Frequency: 10\n" +
               "Range: Percussion + C2-C3\n" +
               "Durability: N/A\n\n" +
               "Because of the power of the drum echo ability, it is very expensive to upgrade timpani sets.  You will need $1000 more to add the ability to this instrument.";
            price = 6000;
        }
        if (instrument == "gong")
        {
            message = "Gong:\n" +
               "Are you feeling overwhelmed by a constant stream of notes? You won't have to feel that way ever again after purchasing a gong.  Buy it to instantly clear the screen of notes, and get some audience points back.\n" +
               "Cost: $1200\n" +
               "Damage: N/A\n" +
               "Frequency: N/A\n" +
               "Range: Percussion + N/A\n" +
               "Durability: N/A\n\n" +
               "Because this is a one time use instrument, there is no upgrade (:P)";
            price = 1200;
        }
        spawner = GetComponent<Button>(); // <-- you get access to the button component here

        spawner.onClick.AddListener(() => createSelection());  // <-- you assign a method to the button OnClick event here
    }

    void createSelection()
    {
        int[] range;
        if (instrument == "recorder")
        {
            range = GlobalVariables.recorderRange;
        } else if (instrument == "clarinet")
        {
            range = GlobalVariables.clarinetRange;
        } else if (instrument == "flute")
        {
            range = GlobalVariables.fluteRange;
        } else if (instrument == "tuba")
        {
            range = GlobalVariables.tubaRange;
        }
        else if (instrument == "saxophone")
        {
            range = GlobalVariables.saxophoneRange;
        }
        else if (instrument == "harp")
        {
            range = GlobalVariables.harpRange;
        }
        else if (instrument == "violin")
        {
            range = GlobalVariables.violinRange;
        }
        else if (instrument == "bassoon")
        {
            range = GlobalVariables.bassoonRange;
        }
        else if (instrument == "piano")
        {
            range = GlobalVariables.pianoRange;
        }
        else if (instrument == "organ")
        {
            range = GlobalVariables.organRange;
        }
        else if (instrument == "organ")
        {
            range = GlobalVariables.organRange;
        }
        else if (instrument == "mandolin")
        {
            range = GlobalVariables.mandolinRange;
        }
        else if (instrument == "trumpet")
        {
            range = GlobalVariables.trumpetRange;
        }
        else if (instrument == "trombone")
        {
            range = GlobalVariables.tromboneRange;
        }
        else if (instrument == "piccolo")
        {
            range = GlobalVariables.piccoloRange;
        }
        else if (instrument == "frenchHorn")
        {
            range = GlobalVariables.frenchHornRange;
        }
        else if (instrument == "doubleBass")
        {
            range = GlobalVariables.doubleBassRange;
        }
        else if (instrument == "cowbell")
        {
            range = GlobalVariables.cowbellRange;
        }
        else if (instrument == "timpani")
        {
            range = GlobalVariables.timpaniRange;
        }
        //Implies simply percussion
        else
        {
            range = new int[1];
            range[0] = -1;
        }
        arrayOfButtons = new Button[range.Length+1];
        bbackground = Instantiate(background, new Vector3(ccanvas.transform.position.x + 433f, ccanvas.transform.position.y + 0f, ccanvas.transform.position.z), transform.rotation) as GameObject;
        bbackground.transform.SetParent(ccanvas.transform, false);
        bbackground.tag = "menu";

        Text messageBoxx = Instantiate(messageBox, ccanvas.transform.position, ccanvas.transform.rotation) as Text;
        messageBoxx.text = message;
        messageBoxx.transform.SetParent(bbackground.transform, false);
        messageBoxx.transform.localScale = new Vector3(1, .5f, 1);
        messageBoxx.transform.position += new Vector3(0f, -1f, 0f);

        float i = 10f;
        for (int j = 0; j < range.Length; j++)
        {
            int currentRange = range[j];
            arrayOfButtons[j] = Instantiate(genericButton, ccanvas.transform.position, ccanvas.transform.rotation) as Button;
            arrayOfButtons[j].transform.SetParent(bbackground.transform, false);
            arrayOfButtons[j].transform.localScale = new Vector3(1, .5f, 1);
            arrayOfButtons[j].tag = "menu";
            arrayOfButtons[j].transform.position += new Vector3(0f, -32f + 2f * i , 0f);
            if (range[j] >= 0) {
                arrayOfButtons[j].GetComponentInChildren<Text>().text = "C" + range[j];
            } else
            {
                arrayOfButtons[j].GetComponentInChildren<Text>().text = "Percussion";
            }
            
            arrayOfButtons[j].onClick.AddListener(() => spawnInstrument(currentRange));
            
            i++;
        }
        arrayOfButtons[range.Length] = Instantiate(genericButton, ccanvas.transform.position, ccanvas.transform.rotation) as Button;
        arrayOfButtons[range.Length].transform.SetParent(bbackground.transform, false);
        arrayOfButtons[range.Length].transform.localScale = new Vector3(1, .5f, 1);
        arrayOfButtons[range.Length].tag = "menu";
        arrayOfButtons[range.Length].GetComponentInChildren<Text>().text = "Cancel";
        arrayOfButtons[range.Length].transform.position += new Vector3(0f, -14f, 0f);
        arrayOfButtons[range.Length].onClick.AddListener(() => cancelAction());
        spawner.onClick.RemoveAllListeners();
    }

    void cancelAction()
    {
        Destroy(bbackground.gameObject);
        for (int i = 0; i < arrayOfButtons.Length; i++)
        {
            Destroy(arrayOfButtons[i].gameObject);
        }
        spawner.onClick.AddListener(() => createSelection());

    }

    void spawnInstrument(int lane)
    {
        Destroy(bbackground.gameObject);
        for (int i = 0; i < arrayOfButtons.Length; i ++)
        {
            Destroy(arrayOfButtons[i].gameObject);
        }
        spawner.onClick.AddListener(() => createSelection());
        for (int i = 0; i < GlobalVariables.spaceFilled[lane+1].Length; i++)
        {
            if(!GlobalVariables.spaceFilled[lane+1][i] && GlobalVariables.cashAtHand-price >= 0)
            {
                Instantiate(instrumentPrefab, new Vector3(-6.0f - 2f * i, -9.8f + (lane+1) * 2f, 0f), transform.rotation);
                GlobalVariables.spaceFilled[lane+1][i] = true;
                GlobalVariables.cashAtHand -= price;
                break;
            }
        }
    }

    public void dst()
    {
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("menu");
        foreach (GameObject go in gameobjects)
        {
            Destroy(go);
        }
        Awake();
    }
}
