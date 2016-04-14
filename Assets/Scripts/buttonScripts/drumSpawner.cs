using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class drumSpawner : MonoBehaviour
{
    public GameObject drumPrefab;
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
        arrayOfButtons = new Button[2];
        bbackground = Instantiate(background, new Vector3(ccanvas.transform.position.x + 433f, ccanvas.transform.position.y + 165f, ccanvas.transform.position.z), transform.rotation) as GameObject;
        bbackground.transform.SetParent(ccanvas.transform, false);
        bbackground.tag = "menu";
        float i = 10f;

        arrayOfButtons[0] = Instantiate(genericButton, ccanvas.transform.position, ccanvas.transform.rotation) as Button;
        arrayOfButtons[0].transform.SetParent(bbackground.transform, false);
        arrayOfButtons[0].tag = "menu";
        arrayOfButtons[0].transform.position += new Vector3(0f, -20f + 2f * i, 0f);
        arrayOfButtons[0].GetComponentInChildren<Text>().text = "Percussion Lane";
        arrayOfButtons[0].onClick.AddListener(() => spawnRecorder(0));
       
        arrayOfButtons[1] = Instantiate(genericButton, ccanvas.transform.position, ccanvas.transform.rotation) as Button;
        arrayOfButtons[1].transform.SetParent(bbackground.transform, false);
        arrayOfButtons[1].tag = "menu";
        arrayOfButtons[1].GetComponentInChildren<Text>().text = "Cancel";
        arrayOfButtons[1].transform.position += new Vector3(0f, -5f, 0f);
        arrayOfButtons[1].onClick.AddListener(() => cancelAction());
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
        for (int i = 0; i < GlobalVariables.spaceFilled[0].Length; i++)
        {
            if (!GlobalVariables.spaceFilled[0][i] && GlobalVariables.cashAtHand >= 200)
            {
                Instantiate(drumPrefab, new Vector3(-6.0f - 2f * i, -9.8f), transform.rotation);
                GlobalVariables.spaceFilled[0][i] = true;
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
