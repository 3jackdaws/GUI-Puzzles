using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{

    public Text songTitle;
    public Text songOtherText;
    private AudioClip currentSong;
    private Song nextSong;
    public AudioSource soundOutput;
    public Slider songProgress;
    public Text songCurrentPosition;
    public Text songEndTime;
    public RectTransform playIcon;
    public RectTransform pauseIcon;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    songProgress.value = soundOutput.time/nextSong.audio.length;
        int length = (int)soundOutput.time;
        songCurrentPosition.text = (length / 60).ToString() + ":" + (length - (length / 60) * 60).ToString("00");
	    if (soundOutput.isPlaying)
	    {
	        playIcon.gameObject.SetActive(true);
            pauseIcon.gameObject.SetActive(false);
        }
	    else
	    {
            pauseIcon.gameObject.SetActive(true);
            playIcon.gameObject.SetActive(false);
        }

	}

    public void SetNextSong(Song song)
    {
        nextSong = song;
        initiateChangeSong();
    }

    void initiateChangeSong()
    {
        songTitle.text = nextSong.clipTitle;
        songOtherText.text = nextSong.clipOtherInfo;
        songCurrentPosition.text = "0:00";
        int length = (int)nextSong.audio.length;
        songEndTime.text = (length/60).ToString() + ":" + (length - (length/60)*60).ToString();
    }

    
}
