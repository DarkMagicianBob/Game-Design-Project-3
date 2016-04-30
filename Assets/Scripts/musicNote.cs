using UnityEngine;
using System;
using System.Collections;
using NAudio;
using NAudio.Midi;

public class musicNote : MonoBehaviour {
    public int hp = 0;
    bool slowed = false;
    bool burn = false;
    bool extraMoney = false;
    bool extraReputation = false;
    bool freeze = false;
    public NoteOnEvent currentNote;
    public long deltaTime;
    public double tempo;
    public int channel;
    public int currentPatch;
    int difficulty;
    int ticks = 0;
    float speed = -5f;
    public bool dead = false;
    Vector3 moveAmount;
    public MidiOut midiOut;
    GameObject hpBar;

    public void subtractHp(int damageDone, bool slow = false, bool burn = false, bool moreMoney = false, bool freeze = false, bool extraRep = false)
    {
        hp -= damageDone;
        if (hp <= 0)
        {
            dead = true;
            GetComponent<SpriteRenderer>().enabled = false;
            if (freeze)
            {
                speed = 5;
                return;
            }
        } if (slow)
        {
            slowNoteDown();
        }
        if (burn)
        {
            burnNote();
        }
        if (freeze)
        {
            freezeNote();
        }
        if (extraMoney)
        {
            generateExtraMoney();
        }
        if (extraRep)
        {

        }

    }

	// Use this for initialization
	void Start () {
        difficulty = GlobalVariables.currentDifficulty;
	}
	
	// Update is called once per frame which is 50 per second
	void FixedUpdate () {
        if (!slowed)
            moveAmount.x = speed * Time.deltaTime;
        else
            moveAmount.x = speed/2 * Time.deltaTime;
        transform.Translate(moveAmount);
        if (hpBar == null)
        {
            hpBar = GameObject.FindGameObjectWithTag("audienceBar");

        }
        if (burn && ticks == 50)
        {
            subtractHp(1);
            ticks = 0;
        } else if (burn && ticks != 50)
        {
            ticks += 1;

        }
	
	}
    //We may not change the instrument patch depending on what you guys think but the basic logic is still there
    //In fact, using a bunch of patch changes seriously slows down things
    public IEnumerator playCorrectNote()
    {
        //midiOut.Send(MidiMessage.ChangePatch(tone, channel).RawData);
        midiOut.Send(MidiMessage.StartNote(currentNote.NoteNumber, currentNote.Velocity, channel).RawData);
        if (currentNote.OffEvent != null)
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)currentNote.NoteLength / deltaTime * tempo)));
            midiOut.Send(MidiMessage.StopNote(currentNote.NoteNumber, currentNote.Velocity, channel).RawData);
            //midiOut.Send(MidiMessage.ChangePatch(currentPatch, channel).RawData);
            //UnityEngine.Debug.Log("Destroy good note");
            Destroy(this.gameObject);
        } else
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)4 * tempo)));
            midiOut.Send(MidiMessage.StopNote(currentNote.NoteNumber, currentNote.Velocity, channel).RawData);
            //midiOut.Send(MidiMessage.ChangePatch(currentPatch, channel).RawData);
            //UnityEngine.Debug.Log("Destroy good note");
            Destroy(this.gameObject);

        }

    }
    public IEnumerator playIncorrectNote()
    {
        //midiOut.Send(MidiMessage.ChangePatch(tone, channel).RawData);
        midiOut.Send(MidiMessage.StartNote(currentNote.NoteNumber + 1, currentNote.Velocity, channel).RawData);
        if (currentNote.OffEvent != null)
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)currentNote.NoteLength / deltaTime * tempo)));
            midiOut.Send(MidiMessage.StopNote(currentNote.NoteNumber+1, currentNote.Velocity, channel).RawData);
            //midiOut.Send(MidiMessage.ChangePatch(currentPatch, channel).RawData);
            //UnityEngine.Debug.Log("Destroy bad note");
            Destroy(this.gameObject);
        }
        else
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)4 * tempo)));
            midiOut.Send(MidiMessage.StopNote(currentNote.NoteNumber+1, currentNote.Velocity, channel).RawData);
            //midiOut.Send(MidiMessage.ChangePatch(currentPatch, channel).RawData);
            //UnityEngine.Debug.Log("Destroy bad note");
            Destroy(this.gameObject);
        }

    }
    public void slowNoteDown()
    {
        slowed = true;

    }
    public void burnNote()
    {
        burn = true;
    }
    public void generateExtraMoney()
    {
        extraMoney = true;
    }
    public void generateExtraReputation()
    {
        extraReputation = true;
    }
    public void freezeNote()
    {
        speed = 0;
    }
    //It would also very economically sound if we only had a coroutine for playing incorrect notes if we decide not to the whole instrument change thing
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "noteLine")
        {
            if (hp <= 0)
            {
                //StartCoroutine(playCorrectNote());
                Destroy(this.gameObject);
                int moneyEarned = 0;
                if (difficulty == 1)
                {
                    moneyEarned = 5;
                }
                if (difficulty == 2)
                {
                    moneyEarned = 10;
                }
                if (difficulty == 3)
                {
                    moneyEarned = 25;
                }
                if (difficulty == 4)
                {
                    moneyEarned = 50;
                }
                if (difficulty == 5)
                {
                    moneyEarned = 100;
                }
                if (extraMoney)
                {
                    moneyEarned *= 2;
                }
                GlobalVariables.cashAtHand += moneyEarned;
                hpBar.GetComponent<audienceBar>().earnReputation(1);
                if (extraReputation)
                    hpBar.GetComponent<audienceBar>().earnReputation(1);
                
            } else
            {
                hpBar.GetComponent<audienceBar>().damageReputation(2);
                StartCoroutine(playIncorrectNote());
            }

        }
    }
}
