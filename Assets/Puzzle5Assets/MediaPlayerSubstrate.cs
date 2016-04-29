using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MediaPlayerSubstrate : MonoBehaviour
{

    public UiController ui;
    public Song[] songlist;
    private int currentSong;
    public AudioSource playerObject;

    void Start()
    {
        playerObject.clip = songlist[0].audio;
        currentSong = 0;
        ui.SetNextSong(songlist[0]);
        playerObject.Play();
        playerObject.Pause();
    }

    void Update()
    {
        if(playerObject.time >= songlist[currentSong].audio.length)
            NextSong();
    }

    public void NextSong()
    {
        ++currentSong;
        ui.SetNextSong(songlist[currentSong%=songlist.Length]);
        playerObject.clip = songlist[currentSong].audio;
        playerObject.Play();
    }

    public void PrevSong()
    {
        --currentSong;
        if (currentSong < 0)
            currentSong = songlist.Length - 1;
        ui.SetNextSong(songlist[currentSong %= songlist.Length]);
        playerObject.clip = songlist[currentSong].audio;
        playerObject.Play();
    }

    public void PlayPauseToggle()
    {
      
        if(playerObject.isPlaying)
            playerObject.Pause();
        else
            playerObject.UnPause();
    }

    public void MenuAction()
    {
        
    }
}
