using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using NAudio.Midi;

public class ProgramV2 : MonoBehaviour
{
    public double tempoToUse = 400000;
    public GameObject trackPlayer;
    public GameObject noteObj;
    public GameObject[] trackPlayers;
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
        NoteOnEvent t_note;
        NoteOnEvent n_note;
        TempoEvent tempo;
        int maxNotes = 0;
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
        MidiOut midiOut = new MidiOut(0);
        MidiFile midi = new MidiFile("Assets/Sis puella magica!.mid");
        playMidi(midiOut, midi);

        Console.ReadLine();
    }
}
