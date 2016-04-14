using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {
    public static int deltaTimeGlob = 0;
    public static double tempoToUse = 0;
    public static int audienceMeter = 20;
    public static int cashAtHand = 1500;
    public static bool gamePaused = false;
    public static bool[][] spaceFilled;
    public static int []recorderRange = new int[3];
    public static int[] clarinetRange = new int[4];
    public static int[] fluteRange = new int[5];
    public static int[] tubaRange = new int[4];
    public static bool freezeSoundWaves = false;

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

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
