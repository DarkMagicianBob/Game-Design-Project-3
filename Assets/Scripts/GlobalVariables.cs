using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour {
    public static int deltaTimeGlob = 0;
    public static double tempoToUse = 0;
    public static int audienceMeter = 50;
    public static int currentDifficulty = 3;
    public static int cashAtHand = 30000;
    public static int storyModeCash = 5000;
    public static int freePlayModeCash = 10000;
    public static bool gamePaused = false;
    public static bool[][] spaceFilled;
    public static int []recorderRange = new int[3];
    public static int[] clarinetRange = new int[4];
    public static int[] fluteRange = new int[5];
    public static int[] tubaRange = new int[4];
    public static int[] saxophoneRange = new int[3];
    public static int[] drumsRange = new int[1];
    public static int[] harpRange = new int[7];
    public static int[] violinRange = new int[5];
    public static int[] bassoonRange = new int[4];
    public static int[] pianoRange = new int[8];
    public static int[] organRange = new int[11];
    public static int[] mandolinRange = new int[4];
    public static int[] trumpetRange = new int[4];
    public static int[] tromboneRange = new int[6];
    public static int[] piccoloRange = new int[4];
    public static int[] frenchHornRange = new int[4];
    public static int[] doubleBassRange = new int[5];
    public static int[] cowbellRange = new int[1];
    public static int[] timpaniRange = new int[3];
    public static bool freezeSoundWaves = false;

    public static bool[] unlockedLevels = new bool[30];
    public static bool storyMode;
    public static bool validSong = true;
    public static int currentLevel;
    public static string currentBackground;
    public static string currentSong;

	// Use this for initialization
	void Start () {
        spaceFilled = new bool[12][];
        spaceFilled[0] = new bool[7];
        spaceFilled[1] = new bool[7];
        spaceFilled[2] = new bool[7];
        spaceFilled[3] = new bool[7];
        spaceFilled[4] = new bool[7];
        spaceFilled[5] = new bool[7];
        spaceFilled[6] = new bool[7];
        spaceFilled[7] = new bool[7];
        spaceFilled[8] = new bool[7];
        spaceFilled[9] = new bool[7];
        spaceFilled[10] = new bool[7];
        spaceFilled[11] = new bool[7];

        recorderRange[0] = 4;
        recorderRange[1] = 5;
        recorderRange[2] = 6;

        clarinetRange[0] = 3;
        clarinetRange[1] = 4;
        clarinetRange[2] = 5;
        clarinetRange[3] = 6;

        fluteRange[0] = 4;
        fluteRange[1] = 5;
        fluteRange[2] = 6;
        fluteRange[3] = 7;
        fluteRange[4] = 8;

        tubaRange[0] = 1;
        tubaRange[1] = 2;
        tubaRange[2] = 3;
        tubaRange[3] = 4;

        saxophoneRange[0] = 4;
        saxophoneRange[1] = 5;
        saxophoneRange[2] = 6;

        drumsRange[0] = -1;

        harpRange[0] = 1;
        harpRange[1] = 2;
        harpRange[2] = 3;
        harpRange[3] = 4;
        harpRange[4] = 5;
        harpRange[5] = 6;
        harpRange[6] = 7;

        violinRange[0] = 3;
        violinRange[1] = 4;
        violinRange[2] = 5;
        violinRange[3] = 6;
        violinRange[4] = 7;

        bassoonRange[0] = 1;
        bassoonRange[1] = 2;
        bassoonRange[2] = 3;
        bassoonRange[3] = 4;

        pianoRange[0] = 0;
        pianoRange[1] = 1;
        pianoRange[2] = 2;
        pianoRange[3] = 3;
        pianoRange[4] = 4;
        pianoRange[5] = 5;
        pianoRange[6] = 6;
        pianoRange[7] = 7;

        organRange[0] = 0;
        organRange[1] = 1;
        organRange[2] = 2;
        organRange[3] = 3;
        organRange[4] = 4;
        organRange[5] = 5;
        organRange[6] = 6;
        organRange[7] = 7;
        organRange[8] = 8;
        organRange[9] = 9;
        organRange[10] = 10;

        mandolinRange[0] = 3;
        mandolinRange[1] = 4;
        mandolinRange[2] = 5;
        mandolinRange[3] = 6;

        trumpetRange[0] = 3;
        trumpetRange[1] = 4;
        trumpetRange[2] = 5;
        trumpetRange[3] = 6;

        tromboneRange[0] = 0;
        tromboneRange[1] = 1;
        tromboneRange[2] = 2;
        tromboneRange[3] = 3;
        tromboneRange[4] = 4;
        tromboneRange[5] = 5;

        piccoloRange[0] = 5;
        piccoloRange[1] = 6;
        piccoloRange[2] = 7;
        piccoloRange[3] = 8;

        frenchHornRange[0] = 2;
        frenchHornRange[1] = 3;
        frenchHornRange[2] = 4;
        frenchHornRange[3] = 5;

        doubleBassRange[0] = 1;
        doubleBassRange[1] = 2;
        doubleBassRange[2] = 3;
        doubleBassRange[3] = 4;
        doubleBassRange[4] = 5;

        cowbellRange[0] = -1;

        timpaniRange[0] = -1;
        timpaniRange[1] = 2;
        timpaniRange[2] = 3;

        unlockedLevels[0] = true;
        //Uncomment this if you wish to make all levels playable
        /*unlockedLevels[1] = true;
        unlockedLevels[2] = true;
        unlockedLevels[3] = true;
        unlockedLevels[4] = true;
        unlockedLevels[5] = true;
        unlockedLevels[6] = true;
        unlockedLevels[7] = true;
        unlockedLevels[8] = true;
        unlockedLevels[9] = true;
        unlockedLevels[10] = true;
        unlockedLevels[11] = true;
        unlockedLevels[12] = true;
        unlockedLevels[13] = true;
        unlockedLevels[14] = true;
        unlockedLevels[15] = true;
        unlockedLevels[16] = true;
        unlockedLevels[17] = true;
        unlockedLevels[18] = true;
        unlockedLevels[19] = true;
        unlockedLevels[20] = true;
        unlockedLevels[21] = true;
        unlockedLevels[22] = true;
        unlockedLevels[23] = true;
        unlockedLevels[24] = true;
        unlockedLevels[25] = true;
        unlockedLevels[26] = true;
        unlockedLevels[27] = true;
        unlockedLevels[28] = true;
        unlockedLevels[29] = true;*/
        //The level in story mode that is being played currently, used to go unlock later levels
        currentLevel = 1;
        storyMode = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
