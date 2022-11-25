using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioScript : MonoBehaviour
{
    AudioMan audioMan = new AudioMan();
    string PathToFolderMp3 = "I:\\data1\\mp3.eng\\HarryPotter";

    void Start()
    {
        StartCoroutine(LoadSongCoroutine());
    }


    IEnumerator  LoadSongCoroutine()
    {
        audioMan.Play(PathToFolderMp3);
        yield return new WaitForSeconds(5);
    }

  
}
