using System;
using UnityEngine;
using System.Collections;

public class StopLightStateSelector : MonoBehaviour
{
    public RectTransform red;
    public RectTransform yellow;
    public RectTransform green;
    // Use this for initialization
    void Start () {
        UnsetAll();
        try
        {
            switch (PlayerPrefs.GetInt("ActiveLight"))
            {
                case 0:
                    {
                        red.gameObject.SetActive(true);
                        break;
                    }
                case 1:
                    {
                        yellow.gameObject.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        green.gameObject.SetActive(true);
                        break;
                    }
            }
        }
        catch (PlayerPrefsException e)
        {
            red.gameObject.SetActive(true);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UnsetAll()
    {
        red.gameObject.SetActive(false);
        yellow.gameObject.SetActive(false);
        green.gameObject.SetActive(false);
    }

    public void SetGreen()
    {
        UnsetAll();
        green.gameObject.SetActive(true);
        PlayerPrefs.SetInt("ActiveLight", 2);
        PlayerPrefs.Save();
    }

    public void SetYellow()
    {
        UnsetAll();
        yellow.gameObject.SetActive(true);
        PlayerPrefs.SetInt("ActiveLight", 1);
        PlayerPrefs.Save();
    }

    public void SetRed()
    {
        UnsetAll();
        red.gameObject.SetActive(true);
        PlayerPrefs.SetInt("ActiveLight", 0);
        PlayerPrefs.Save();
    }


}
