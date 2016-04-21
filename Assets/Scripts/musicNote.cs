using UnityEngine;
using System;
using System.Collections;
using NAudio;
using NAudio.Midi;

public class musicNote : MonoBehaviour {
    public int hp = 0;
    int tone = 75;
    public NoteOnEvent currentNote;
    public long deltaTime;
    public double tempo;
    public int channel;
    public int currentPatch;
    float speed = -5f;
    public bool dead = false;
    Vector3 moveAmount;
    public MidiOut midiOut;
    GameObject hpBar;

    public void subtractHp(int damageDone, int tonePlayed)
    {
        hp -= damageDone;
        tone = tonePlayed;
        if (hp <= 0)
        {
            dead = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame which is 50 per second
	void FixedUpdate () {
        moveAmount.x = speed * Time.deltaTime;
        transform.Translate(moveAmount);
	
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
            UnityEngine.Debug.Log("Destroy good note");
            Destroy(this.gameObject);
        } else
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)4 * tempo)));
            midiOut.Send(MidiMessage.StopNote(currentNote.NoteNumber, currentNote.Velocity, channel).RawData);
            //midiOut.Send(MidiMessage.ChangePatch(currentPatch, channel).RawData);
            UnityEngine.Debug.Log("Destroy good note");
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
            UnityEngine.Debug.Log("Destroy bad note");
            Destroy(this.gameObject);
        }
        else
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)4 * tempo)));
            midiOut.Send(MidiMessage.StopNote(currentNote.NoteNumber+1, currentNote.Velocity, channel).RawData);
            //midiOut.Send(MidiMessage.ChangePatch(currentPatch, channel).RawData);
            UnityEngine.Debug.Log("Destroy bad note");
            Destroy(this.gameObject);
        }

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
                GlobalVariables.cashAtHand += 20;
                
            } else
            {
                hpBar = GameObject.FindGameObjectWithTag("audienceBar");
                hpBar.GetComponent<audienceBar>().damageReputation(1);
                StartCoroutine(playIncorrectNote());
            }

        }
    }
}
