using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using NAudio.Midi;

public class playTrack : MonoBehaviour {
    //Different levels of difficult depending on how we want to do things
    public int difficulty = 2;
    int noteTimeDivisor;
    public double tempoToUse;
    public GameObject noteObj;
    public int currentPatch;

    public IEnumerator pause()
    {
        while (GlobalVariables.gamePaused)
        {
            yield return new WaitForSeconds(1);
        }
    }

    //A lot of these change functions will be VERY similar
    IEnumerator playNote(long timeToWait, long deltaTime, long offset, MidiOut midiOut, NoteOnEvent noteToPlay, int channel, bool repeat)
    {
        if (noteToPlay.OffEvent != null)
        {

            //If the time offset is less than the time to wait, then the offset is used
            if (Math.Floor((double)timeToWait / deltaTime * tempoToUse) > (Int32)offset)
            {
                yield return new WaitForSeconds(.001f * ((Int32)Math.Floor(((double)(timeToWait) / deltaTime * tempoToUse)) - (Int32)offset));
                float posOffset;
                if (channel == 10)
                {
                    posOffset = 0f;

                }
                else
                {
                    posOffset = Mathf.Floor((float)noteToPlay.NoteNumber / 11) + 1;
                }
                //If the note falls on the quarter beat then create the note object (may change later for more difficult levels)
                if (noteToPlay.AbsoluteTime % (noteTimeDivisor) == 0)
                {
                    GameObject notePlayed = (GameObject)Instantiate(noteObj, new Vector3(21.25f, -9.8f + (posOffset * 2), 0), transform.rotation);
                    notePlayed.GetComponent<musicNote>().midiOut = midiOut;
                    notePlayed.GetComponent<musicNote>().currentNote = noteToPlay;
                    notePlayed.GetComponent<musicNote>().channel = channel;
                    notePlayed.GetComponent<musicNote>().currentPatch = currentPatch;
                    notePlayed.GetComponent<musicNote>().deltaTime = deltaTime;
                    notePlayed.GetComponent<musicNote>().tempo = tempoToUse;
                }
                yield return new WaitForSeconds(5);
                midiOut.Send(MidiMessage.StartNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);
                
                if (repeat)
                {
                    yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)noteToPlay.NoteLength / deltaTime * tempoToUse)));
                    midiOut.Send(MidiMessage.StopNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);
                    midiOut.Send(MidiMessage.StartNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);
                    yield break;
                }
            }
            // Else, it is not
            else
            {
                yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)timeToWait / deltaTime * tempoToUse)));
                float posOffset;
                if (channel == 10)
                {
                    posOffset = 0f;

                }
                else
                {
                    posOffset = Mathf.Floor((float)noteToPlay.NoteNumber / 11) + 1;
                }
                //If the note falls on the quarter beat then create the note object (may change later for more difficult levels)
                if (noteToPlay.AbsoluteTime % (noteTimeDivisor) == 0)
                {
                    GameObject notePlayed = (GameObject)Instantiate(noteObj, new Vector3(21.25f, -9.8f + (posOffset * 2), 0), transform.rotation);
                    notePlayed.GetComponent<musicNote>().midiOut = midiOut;
                    notePlayed.GetComponent<musicNote>().currentNote = noteToPlay;
                    notePlayed.GetComponent<musicNote>().channel = channel;
                    notePlayed.GetComponent<musicNote>().currentPatch = currentPatch;
                    notePlayed.GetComponent<musicNote>().deltaTime = deltaTime;
                    notePlayed.GetComponent<musicNote>().tempo = tempoToUse;
                }
                yield return new WaitForSeconds(5);
                midiOut.Send(MidiMessage.StartNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);

                if (repeat)
                {
                    yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)noteToPlay.NoteLength / deltaTime * tempoToUse)));
                    midiOut.Send(MidiMessage.StopNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);
                    yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)1 / deltaTime * tempoToUse)));
                    midiOut.Send(MidiMessage.StartNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);
                    yield break;
                }
            }
            //If a repeat of a note isn't specified then a stopNote event will be passed
            yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)(noteToPlay.NoteLength) / deltaTime * tempoToUse)));
            midiOut.Send(MidiMessage.StopNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);
        }
        else
        {
            if (Math.Floor((double)timeToWait / deltaTime * tempoToUse) > (Int32)offset)
            {
                yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)timeToWait / deltaTime * tempoToUse) - (Int32)offset));
                midiOut.Send(MidiMessage.StopNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);
            }
            else
            {
                yield return new WaitForSeconds(.001f * ((Int32)Math.Floor((double)timeToWait / deltaTime * tempoToUse)));
                midiOut.Send(MidiMessage.StopNote(noteToPlay.NoteNumber, noteToPlay.Velocity, channel).RawData);

            }
        }
        yield break;
    }
    public IEnumerator changePatchF(long timeToWait, long deltaTime, long offset, MidiOut midiOut, PatchChangeEvent patchChange, int channel)
    {
        if (timeToWait == 0)
        {
            midiOut.Send(MidiMessage.ChangePatch(patchChange.Patch, channel).RawData);
            currentPatch = patchChange.Patch;
        }
        else
        {
            yield return new WaitForSeconds(.001f * ((Int32)Math.Ceiling((double)timeToWait / deltaTime * tempoToUse) - (Int32)offset));
            midiOut.Send(MidiMessage.ChangePatch(patchChange.Patch, channel).RawData);
            currentPatch = patchChange.Patch;
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
            yield return new WaitForSeconds(.001f * ((Int32)Math.Ceiling((double)timeToWait / deltaTime * tempoToUse)));
            midiOut.Send(MidiMessage.ChangeControl((int)controlChange.Controller, controlChange.ControllerValue, channel).RawData);
        }
        yield break;

    }

    public IEnumerator endTrack(long timeToWait, long deltaTime, long offset)
    {
        yield return new WaitForSeconds(.001f * ((Int32)Math.Ceiling((double)timeToWait / deltaTime * tempoToUse) - (Int32)offset));
        Destroy(gameObject);

    }

    public void playCurrentTrack(int spot, MidiOut midiOut, MidiFile midi)
    {
        MidiEvent note;
        NoteOnEvent t_note;
        NoteOnEvent n_note;
        Stopwatch timer = new Stopwatch();
        timer.Reset();
        timer.Start();
        difficulty = GlobalVariables.currentDifficulty;
        //Every measure / 4th note
        if (difficulty == 1)
        {
            noteTimeDivisor = midi.DeltaTicksPerQuarterNote * 4;
        }
        //Every half note
        if (difficulty == 2)
        {
            noteTimeDivisor = midi.DeltaTicksPerQuarterNote * 2;
        }
        //Every quarter note
        if (difficulty == 3)
        {
            noteTimeDivisor = midi.DeltaTicksPerQuarterNote;
        }
        //Every eighth note
        if (difficulty == 4)
        {
            noteTimeDivisor = midi.DeltaTicksPerQuarterNote / 2;
        }
        //Every note
        if (difficulty == 5)
        {
            noteTimeDivisor = 1;
        }
        GlobalVariables.currentDifficulty = difficulty;
        for (int j = 0; j < midi.Events[spot].Count(); j++)
        {
            note = midi.Events[spot][j];
            //For tempo changes
            //For control changes
            if (note is ControlChangeEvent)
            {
                ControlChangeEvent cc = (ControlChangeEvent)note;
                StartCoroutine(controlChangeF(note.AbsoluteTime, midi.DeltaTicksPerQuarterNote, timer.ElapsedMilliseconds, midiOut, cc, note.Channel));
            }
            //For instrument tone/patch changes
            else if (note.CommandCode == MidiCommandCode.PatchChange)
            {
                //Console.WriteLine("ChangedInstrument");
                PatchChangeEvent changePatch = (PatchChangeEvent)note;
                StartCoroutine(changePatchF(note.AbsoluteTime, midi.DeltaTicksPerQuarterNote, timer.ElapsedMilliseconds, midiOut, changePatch, changePatch.Channel));

            }
            else if (note.CommandCode == MidiCommandCode.NoteOn)
            {
                t_note = (NoteOnEvent)note;

                //If the next NoteOn event is a noteOnEvent with velocity 0
                if (j + 2 < midi.Events[spot].Count() && midi.Events[spot][j + 2] is NoteOnEvent)
                {
                    n_note = (NoteOnEvent)midi.Events[spot][j + 2];
                    //Repeat if happening on same absolute time stamp
                    if (t_note.Velocity != 0 && n_note.Velocity != 0 && n_note.NoteName == t_note.NoteName && n_note.AbsoluteTime == t_note.AbsoluteTime + t_note.NoteLength)
                    {
                       StartCoroutine(playNote(note.AbsoluteTime, midi.DeltaTicksPerQuarterNote, timer.ElapsedMilliseconds, midiOut, t_note, t_note.Channel, true));

                    }
                    else
                    {
                       StartCoroutine(playNote(note.AbsoluteTime, midi.DeltaTicksPerQuarterNote, timer.ElapsedMilliseconds, midiOut, t_note, t_note.Channel, false));
                    }
                }
                else {
                    StartCoroutine(playNote(note.AbsoluteTime, midi.DeltaTicksPerQuarterNote, timer.ElapsedMilliseconds, midiOut, t_note, t_note.Channel, false));
                }


            } else if (note != null)
                {
                MetaEvent me = note as MetaEvent;
                if (me != null)
                {
                    if (me.MetaEventType == MetaEventType.EndTrack)
                    {
                        StartCoroutine(endTrack(note.AbsoluteTime, midi.DeltaTicksPerQuarterNote, timer.ElapsedMilliseconds));
                    }
                }

           }
        }

    }
}
