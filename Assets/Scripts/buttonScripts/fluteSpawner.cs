using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fluteSpawner : MonoBehaviour
{
    public GameObject flutePrefab;
    public Button genericButton;
    private Button[] arrayOfButtons;
    public GameObject background;
    GameObject bbackground;
    public GameObject ccanvas;
    private Button button;

    Text buttonText;

    Button spawner;

    void Awake()
    {
        spawner = GetComponent<Button>(); // <-- you get access to the button component here

        spawner.onClick.AddListener(() => createSelection());  // <-- you assign a method to the button OnClick event here
    }

    void createSelection()
    {
        arrayOfButtons = new Button[GlobalVariables.fluteRange.Length];
        bbackground = Instantiate(background, new Vector3(ccanvas.transform.position.x + 433f, ccanvas.transform.position.y + 165f, ccanvas.transform.position.z), transform.rotation) as GameObject;
        bbackground.transform.SetParent(ccanvas.transform, false);
        bbackground.tag = "menu";
        float i = 10f;
        int[] range = GlobalVariables.fluteRange;
        for (int j = 0; j < range.Length; j++)
        {
            int currentRange = range[j];
            arrayOfButtons[j] = Instantiate(genericButton, ccanvas.transform.position, ccanvas.transform.rotation) as Button;
            arrayOfButtons[j].transform.SetParent(bbackground.transform, false);
            arrayOfButtons[j].tag = "menu";
            arrayOfButtons[j].transform.position += new Vector3(0f, -20f + 2f * i, 0f);
            arrayOfButtons[j].GetComponentInChildren<Text>().text = "C" + range[j];
            arrayOfButtons[j].onClick.AddListener(() => spawnRecorder(currentRange));

            i++;
        }
        arrayOfButtons[4] = Instantiate(genericButton, ccanvas.transform.position, ccanvas.transform.rotation) as Button;
        arrayOfButtons[4].transform.SetParent(bbackground.transform, false);
        arrayOfButtons[4].tag = "menu";
        arrayOfButtons[4].GetComponentInChildren<Text>().text = "Cancel";
        arrayOfButtons[4].transform.position += new Vector3(0f, -5f, 0f);
        arrayOfButtons[4].onClick.AddListener(() => cancelAction());
        spawner.onClick.RemoveAllListeners();
        //spawner.onClick.AddListener(() => dst());
    }

    void myWindowGui(int windowID)
    {

    }

    void cancelAction()
    {
        Debug.Log("Purchase cancelled");
        Destroy(bbackground.gameObject);
        for (int i = 0; i < arrayOfButtons.Length; i++)
        {
            Destroy(arrayOfButtons[i].gameObject);
        }
        spawner.onClick.AddListener(() => createSelection());

    }

    void spawnRecorder(int lane)
    {
        Debug.Log("Spawn in lane: " + lane);
        Destroy(bbackground.gameObject);
        for (int i = 0; i < arrayOfButtons.Length; i++)
        {
            Destroy(arrayOfButtons[i].gameObject);
        }
        spawner.onClick.AddListener(() => createSelection());
        for (int i = 0; i < GlobalVariables.spaceFilled[lane + 1].Length; i++)
        {
            if (!GlobalVariables.spaceFilled[lane + 1][i] && GlobalVariables.cashAtHand >= 200)
            {
                Instantiate(flutePrefab, new Vector3(-6.0f - 2f * i, -9.8f + (lane + 1) * 2f, 0f), transform.rotation);
                GlobalVariables.spaceFilled[lane + 1][i] = true;
                GlobalVariables.cashAtHand -= 200;
                break;
            }
        }
    }

    public void dst()
    {
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("menu");
        foreach (GameObject go in gameobjects)
        {
            Destroy(go);
        }
        Awake();
    }
}
