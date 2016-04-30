using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeDifficulty : MonoBehaviour {
    public Dropdown myDropdown;

	// Use this for initialization
	void Start () {
        myDropdown.onValueChanged.AddListener(delegate { myDropdownValueChangedHandler(myDropdown);
        });
	
	}
    void Destroy()
    {
        myDropdown.onValueChanged.RemoveAllListeners();
    }
	
	private void myDropdownValueChangedHandler(Dropdown target)
    {
        Debug.Log(target.value);
        GlobalVariables.currentDifficulty = target.value + 1;
    }
    public void SetDropdownIndex(int index)
    {
        myDropdown.value = index;
    }
}
