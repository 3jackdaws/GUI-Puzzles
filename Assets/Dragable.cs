using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class Dragable : MonoBehaviour
{
    private Vector3 lastPos;
    public float shakeFactor;
    public Text fortune;
    public InputField request;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FollowMouse()
    {
        InvokeRepeating("Follow", 0, 0.02f);
    }

    public void UnfollowMouse()
    {
        CancelInvoke("Follow");
    }

    void Follow()
    {
        this.transform.position = Input.mousePosition;
        if((lastPos - this.transform.position).magnitude > shakeFactor)
            Invoke("Shake", 0);

    }

    void Shake()
    {
        Debug.Log("Shake");
        if(request.text.Length > 0)
            Invoke("ChangeFortune", 1);
    }

    void ChangeFortune()
    {
        Random.seed = request.text.GetHashCode();
        switch ((int)(Random.value * 5))
        {
            case 0:
            {
                fortune.text = "YES";
                break;
            }
            case 1:
            {
                fortune.text = "NO";
                break;
            }
            case 2:
            {
                fortune.text = "POSSIBLY";
                break;
            }
            case 3:
            {
                fortune.text = "IDK";
                break;
            }
            default:
                fortune.text = "MAYBE";
                break;
        }
    }
}
