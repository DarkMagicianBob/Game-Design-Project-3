using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using NAudio.Midi;

public class ProgramV2 : MonoBehaviour
{
    MidiOut midiOut;
    public double tempoToUse = 400000;
    public GameObject trackPlayer;
    public GameObject noteObj;
    public GameObject[] trackPlayers;

    //Various backgrounds so that "levels" can be formed
    public Sprite generic;
    public Sprite backAlley;
    public Sprite bar;
    public Sprite barbershop;
    public Sprite berlin;
    public Sprite danube;
    public Sprite graveyard;
    public Sprite halloween;
    public Sprite harvard;
    public Sprite hellportal;
    public Sprite horsefuneral;
    public Sprite horserace;
    public Sprite magicCastle;
    public Sprite moscow;
    public Sprite paris;
    public Sprite russianWoods;
    public Sprite sanFrancisco;
    public Sprite singapore;
    public Sprite spaceCenter;
    public Sprite spooky;
    public Sprite vienna;

    bool checkForEnd = false;

    public void endMidi()
    {
        if(midiOut != null)
            midiOut.Dispose();
    }

    public void Update()
    {
        if (checkForEnd)
        {
            if (GameObject.FindGameObjectsWithTag("trackPlayer").Length == 0 && GameObject.FindGameObjectsWithTag("note").Length == 0)
            {
                midiOut.Dispose();
                //Unfortunately, the only way I could figure out how to multiple movements on some songs is by simply restarting the level
                //You'll be swimming in cash anyways so it doesn't really matter
                //Moonlight Sonata movements
                if (GlobalVariables.currentSong == "MoonlightSonata1") {
                    GlobalVariables.currentSong = "MoonlightSonata2";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.currentSong == "MoonlightSonata2")
                {
                    GlobalVariables.currentSong = "MoonlightSonata3";
                    SceneManager.LoadScene("roughSheet");
                }
                //Carmen movements
                else if (GlobalVariables.currentSong == "CarmenHabanera")
                {
                    GlobalVariables.currentSong = "CarmenHabanera";
                    SceneManager.LoadScene("roughSheet");
                }
                //Nutcracker movements
                else if (GlobalVariables.currentSong == "Nutcracker1")
                {
                    GlobalVariables.currentSong = "Nutcracker2";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.currentSong == "Nutcracker2")
                {
                    GlobalVariables.currentSong = "Nutcracker3";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.currentSong == "Nutcracker3")
                {
                    GlobalVariables.currentSong = "Nutcracker4";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.currentSong == "Nutcracker4")
                {
                    GlobalVariables.currentSong = "Nutcracker5";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.currentSong == "Nutcracker5")
                {
                    GlobalVariables.currentSong = "Nutcracker6";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.currentSong == "Nutcracker6")
                {
                    GlobalVariables.currentSong = "Nutcracker7";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.currentSong == "Nutcracker7")
                {
                    GlobalVariables.currentSong = "Nutcracker8";
                    SceneManager.LoadScene("roughSheet");
                }
                else if (GlobalVariables.storyMode)
                {
                    GlobalVariables.unlockedLevels[GlobalVariables.currentLevel] = true;
                    GlobalVariables.storyModeCash = GlobalVariables.cashAtHand;
                    GlobalVariables.currentLevel += 1;
                    SceneManager.LoadScene("storyMenu");
                }
                else {
                    GlobalVariables.freePlayModeCash = 10000;
                    //Reset cash at hand
                    GlobalVariables.cashAtHand = GlobalVariables.freePlayModeCash;
                    SceneManager.LoadScene("mainMenu");
                }
            }
        }

    }
    public IEnumerator changeTempo(long timeToWait, long deltaTime, long offset, MidiOut midiOut, TempoEvent tempoEv, int channel)
    {
        if (timeToWait == 0)
        {
            tempoToUse = tempoEv.MicrosecondsPerQuarterNote / 1000;
            GlobalVariables.tempoToUse = tempoToUse;

        }
        /*else {
            Console.WriteLine("Change later");
            yield return new WaitForSeconds(.001f * ((Int32)Math.Ceiling((double)timeToWait / deltaTime * tempoToUse) - (Int32)offset));
            Console.WriteLine("Change Now");
            tempoToUse = tempoEv.MicrosecondsPerQuarterNote / 1000;
        }*/
        yield break;


    }
    public IEnumerator changePatchF(long timeToWait, long deltaTime, long offset, MidiOut midiOut, PatchChangeEvent patchChange, int channel)
    {
        if (timeToWait == 0)
        {
            midiOut.Send(MidiMessage.ChangePatch(patchChange.Patch, channel).RawData);
        }
        else
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Ceiling((double)timeToWait / deltaTime * tempoToUse) - (Int32)offset));
            midiOut.Send(MidiMessage.ChangePatch(patchChange.Patch, channel).RawData);
        }
        yield break;

    }
    public IEnumerator controlChangeF(long timeToWait, long deltaTime, long offset, MidiOut midiOut, ControlChangeEvent controlChange, int channel)
    {
        if (timeToWait == 0)
        {
            midiOut.Send(MidiMessage.ChangeControl((int)controlChange.Controller, controlChange.ControllerValue, channel).RawData);
        }
        else
        {
            UnityEngine.Debug.Log(.001f * ((Int32)Math.Ceiling((double)timeToWait / deltaTime * tempoToUse)));
            yield return new WaitForSeconds(.001f * ((Int32)Math.Ceiling((double)timeToWait / deltaTime * tempoToUse)));
            midiOut.Send(MidiMessage.ChangeControl((int)controlChange.Controller, controlChange.ControllerValue, channel).RawData);
        }
        yield break;

    }
    public void playTracks(MidiOut midiOut, MidiFile midi, System.IO.StreamWriter file)
    {
        MidiEvent note;
        TempoEvent tempo;
        Stopwatch timer = new Stopwatch();
        timer.Reset();
        timer.Start();
        GlobalVariables.deltaTimeGlob = midi.DeltaTicksPerQuarterNote;
        trackPlayers = new GameObject[midi.Events.Count()];

        for (int i = 0; i < midi.Events.Count(); i++)
        {
            if (i == 0) {
                // Only intial events like setting the tempo
                for (int j = 0; j < midi.Events[0].Count(); j++)
                {
                    note = midi.Events[0][j];
                    if (note is TempoEvent)
                    {
                        tempo = (TempoEvent)note;
                        //Console.WriteLine(tempo.Tempo);
                        //Console.WriteLine(tempo.MicrosecondsPerQuarterNote);
                        //Console.WriteLine(midi.DeltaTicksPerQuarterNote);
                        StartCoroutine(changeTempo(tempo.AbsoluteTime, midi.DeltaTicksPerQuarterNote, timer.ElapsedMilliseconds, midiOut, tempo, tempo.Channel));
                    }

                }
            }
            trackPlayers[i] = (GameObject)Instantiate(trackPlayer, transform.position, transform.rotation);
            trackPlayers[i].GetComponent<playTrack>().noteObj = noteObj;
            trackPlayers[i].GetComponent<playTrack>().tempoToUse = tempoToUse;
            trackPlayers[i].GetComponent<playTrack>().playCurrentTrack(i, midiOut, midi);

        }
        checkForEnd = true;

    }
    public void haltTracks()
    {
        for (int i = 0; i < trackPlayers.Length; i ++)
        {
            trackPlayers[i].GetComponent<playTrack>().StartCoroutine(trackPlayers[i].GetComponent<playTrack>().pause());
        }
    }
    public IEnumerator pause()
    {
        while(GlobalVariables.gamePaused)
        {
            yield return new WaitForSeconds(1);
        }
    }
    public void playMidi(MidiOut midiOut, MidiFile midi)
    {
        //NoteEvent t_stop;
        MidiEvent note;
        using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(@"./midiFile.txt"))
        {
            for (int i = 0; i < midi.Events.Count(); i++)
            {
                for (int j = 0; j < midi.Events[i].Count(); j++)
                {
                    note = midi.Events[i][j];
                    file.WriteLine(note.ToString());

                }
            }
            playTracks(midiOut, midi, file);
        }

    }
    void Start()
    {
        UnityEngine.Debug.Log(GlobalVariables.validSong);
        if (GlobalVariables.currentBackground == "generic")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = generic;
        }
        else if (GlobalVariables.currentBackground == "backAlley")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = backAlley;
        }
        else if (GlobalVariables.currentBackground == "bar")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bar;
        }
        else if (GlobalVariables.currentBackground == "barbershop")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = barbershop;
        }
        else if (GlobalVariables.currentBackground == "berlin")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = berlin;
        }
        else if (GlobalVariables.currentBackground == "danube")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = danube;
        }
        else if (GlobalVariables.currentBackground == "graveyard")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = graveyard;
        }
        else if (GlobalVariables.currentBackground == "halloween")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = halloween;
        }
        else if (GlobalVariables.currentBackground == "harvard")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = harvard;
        }
        else if (GlobalVariables.currentBackground == "hellPortal")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hellportal;
        }
        else if (GlobalVariables.currentBackground == "horseRace")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = horserace;
        }
        else if (GlobalVariables.currentBackground == "horseFuneral")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = horsefuneral;
        }
        else if (GlobalVariables.currentBackground == "magicalCastle")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = magicCastle;
        }
        else if (GlobalVariables.currentBackground == "moscow")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = moscow;
        }
        else if (GlobalVariables.currentBackground == "paris")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = paris;
        }
        else if (GlobalVariables.currentBackground == "russianWoods")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = russianWoods;
        }
        else if (GlobalVariables.currentBackground == "sanFrancisco")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sanFrancisco;
        }
        else if (GlobalVariables.currentBackground == "singapore")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = singapore;
        }
        else if (GlobalVariables.currentBackground == "spaceCenter")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spaceCenter;
        }
        else if (GlobalVariables.currentBackground == "spooks")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spooky;
        }
        else if (GlobalVariables.currentBackground == "vienna")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = vienna;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = generic;
        }
        if (!GlobalVariables.validSong && GlobalVariables.storyMode)
        {
            SceneManager.LoadScene("storyMenu");
            return;
        } else if (!GlobalVariables.validSong && !GlobalVariables.storyMode)
        {
            SceneManager.LoadScene("freePlayMenu");
        }
        if (midiOut == null) {
            midiOut = new MidiOut(0);
        }
        if (GlobalVariables.storyMode)
        {
            GlobalVariables.cashAtHand = GlobalVariables.storyModeCash;
        } else
        {
            GlobalVariables.cashAtHand = GlobalVariables.freePlayModeCash;
        }
        //Empty all filled space so that you can place units anew
        for (int i = 0; i < GlobalVariables.spaceFilled.Length; i++)
        {
            for (int j = 0; j < GlobalVariables.spaceFilled[i].Length; j++)
            {
                GlobalVariables.spaceFilled[i][j] = false;
            }
        }
        instrumentMenuScript.toMute = midiOut;
        UnityEngine.Debug.Log(GlobalVariables.currentSong);
        MidiFile midi = new MidiFile("Assets/midiFiles/" + GlobalVariables.currentSong + ".mid");
        playMidi(midiOut, midi);
    }
}
