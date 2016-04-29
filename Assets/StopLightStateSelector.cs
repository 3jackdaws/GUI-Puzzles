using System;
using UnityEngine;
using System.Collections;

public class StopLightStateSelector : MonoBehaviour
{
    public RectTransform [] lights;
    private int set_light;
    
    // Use this for initialization
    void Start () {
        UnsetAll();
        try
        {
            set_light = PlayerPrefs.GetInt("ActiveLight");
        }
        catch (PlayerPrefsException e)
        {
            set_light = 0;
        }
        lights[set_light].gameObject.SetActive(true);
        InvokeRepeating("GoNext", 1, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UnsetAll()
    {
        foreach(RectTransform light in lights)
        {
            light.gameObject.SetActive(false);
        }
    }

    void GoNext()
    {
        lights[set_light++].gameObject.SetActive(false);
        lights[set_light%=3].gameObject.SetActive(true);
        PlayerPrefs.SetInt("ActiveLight", set_light);
        PlayerPrefs.Save();
    }


}
