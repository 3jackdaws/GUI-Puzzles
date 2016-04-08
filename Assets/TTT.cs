using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TTT : MonoBehaviour
{
    public Text field;
	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetX()
    {
        field.text = "X";
    }

    public void SetO()
    {
        field.text = "O";
    }

    public void ChangeMarker()
    {
        if (field.text == "")
        {
            field.text = "X";
        }
        else if (field.text == "X")
        {
            field.text = "O";
        }
        else
            field.text = "";

    }
}
