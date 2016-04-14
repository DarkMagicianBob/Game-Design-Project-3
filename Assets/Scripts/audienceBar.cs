using UnityEngine;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class audienceBar : MonoBehaviour
{

    UnityEngine.UI.Slider hpSlider;
    int hp = GlobalVariables.audienceMeter;

    //Subtract hp and add knock back
    public void damageReputation(int damage)
    {
        hp -= damage;
        hpSlider.value = hp;
        if (hp == 0)
        {
            //Go to the level select screen if you fail out
        }

    }

    // Use this for initialization
    void Start()
    {
        hpSlider = GameObject.Find("audienceBar").GetComponent<Slider>();
        hpSlider.maxValue = hp;
        hpSlider.value = hp;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

