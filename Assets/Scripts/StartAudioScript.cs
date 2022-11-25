using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class StartAudioScript : MonoBehaviour
{

    AudioClip _audioClip;
    AudioSource audioSource;
    int CurrentClip = 0;

    DateTime timeStart;
    DateTime timeEnd;



    string[] ListAllMp3;
     [SerializeField] float TimeToChangeMp3 = 7;


    [SerializeField] AudioClip flySound;

    void Start()
    {
        int CurrentClip = 0;

        timeEnd = DateTime.Now;
        audioSource = GetComponent<AudioSource>();
        AudioMp3 audioMp3 = new AudioMp3();
        string PathToFolderMp3 = "I:\\data1\\mp3.eng\\HarryPotter";
        ListAllMp3 = audioMp3.ListMp3(PathToFolderMp3);

        StartCoroutine(ListPlay());



    }



    IEnumerator ListPlay()
    {


        double dellta = (timeEnd - DateTime.Now).TotalSeconds;
        Debug.Log(" ListPlay Seconds " + dellta.ToString() + " timeEnd > DateTime.Now " + (timeEnd > DateTime.Now).ToString());

        while (timeEnd > DateTime.Now)
            yield return new WaitForSeconds((float)dellta);
        StartCoroutine(LoadAudioClip(ListAllMp3[CurrentClip++]));

    }




    IEnumerator LoadAudioClip(string PtsPath)
    {

        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip((PtsPath), AudioType.MPEG))
        {
            yield return uwr.SendWebRequest();
            _audioClip = DownloadHandlerAudioClip.GetContent(uwr);
            audioSource.clip = _audioClip;
            audioSource.Play();
            timeStart = DateTime.Now;
            timeEnd = timeStart.AddSeconds(_audioClip.length);
            if (TimeToChangeMp3>0)  // fast change for debug and etc
            timeEnd = timeStart.AddSeconds(TimeToChangeMp3);
            Debug.Log("TotalSeconds to change track = " + (timeEnd - DateTime.Now).TotalSeconds);
            StartCoroutine(ListPlay());

        }
    }


}



