using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class audienceBar : MonoBehaviour
{

    UnityEngine.UI.Slider hpSlider;
    int hp = GlobalVariables.audienceMeter;

    //Subtract hp and add knock back
    public void damageReputation(int damage)
    {
        hp -= damage;
        hpSlider.value = hp;
        if (hp <= 0)
        {
            GameObject midiPlayer = GameObject.FindGameObjectWithTag("concertHall");
            //You have to end the midi player or else the next song will fail
            midiPlayer.GetComponent<ProgramV2>().endMidi();
            SceneManager.LoadScene("gameOverScreen");
            if (GlobalVariables.storyMode) {
                //Reset all levels, so that you have to start from the very beginning.  I'm evil and the game is too easy anyways.
                for (int i = 1; i < GlobalVariables.unlockedLevels.Length; i++)
                {
                    GlobalVariables.unlockedLevels[i] = false;
                }
                GlobalVariables.storyModeCash = 5000;
                GlobalVariables.cashAtHand = 5000;
            }
            //Go to the level select screen if you fail out
        }

    }

    public void earnReputation(int boon)
    {
        if (hp + boon <= hpSlider.maxValue)
        hp += boon;
        hpSlider.value = hp;
    }

    // Use this for initialization
    void Start()
    {
        hpSlider = GameObject.Find("audienceBar").GetComponent<Slider>();
        hpSlider.maxValue = hp;
        hpSlider.value = hp;

    }
    public void increaseMaxRep()
    {
        hpSlider.maxValue += 50;
        hp += 50;
        hpSlider.value += 50;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

