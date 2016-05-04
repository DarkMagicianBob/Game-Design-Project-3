using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* important: implementation guide
this script is designed to work on a button press to do this correctly follow these steps
1. attach this script to an object and make that object a prefab.
2. click the button you want to attach this to. At the button of the inspector you should see a field called on click, click the plus button on that.
3. drag the prfab object with this script attached to that field.
4. in the no function dialouge box click goToScene -> load().
5. fill in the exact name of the level you want to load in the new field.
6. you also have to make a build with all of the secenes included.
7. go to file -> build settings and drag all of the scenes in to that field then click build.
*/

public class goToScene : MonoBehaviour {

    public void load(string level_name)
    {
        if (level_name == "freePlayMenu")
        {
            GlobalVariables.storyMode = false;
        }
        else if (level_name == "storyMenu") {
            GlobalVariables.storyMode = true;
        }
        //Empty all filled space so that you can place units anew
        for (int i = 0; i < GlobalVariables.spaceFilled.Length; i ++)
        {
            for (int j = 0; j < GlobalVariables.spaceFilled[i].Length; j++)
            {
                GlobalVariables.spaceFilled[i][j] = false;
            }
        }
        SceneManager.LoadScene(level_name);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
