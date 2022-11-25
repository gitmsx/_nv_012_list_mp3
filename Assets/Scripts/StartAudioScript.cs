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
    


     float TimeToChangeMp3 = 7;
     float TimeHasLongTime = 0;

    [SerializeField] AudioClip flySound;

    void Start()
    {
        int CurrentClip = 0;

        timeEnd = DateTime.Now.AddSeconds(2);

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
        {
        

            yield return new WaitForSeconds((float)dellta);
            
            
        }
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
            timeEnd = timeStart.AddSeconds(7);
            StartCoroutine(ListPlay());
            //Debug.Log(_audioClip.length / 60);
            //Debug.Log(PtsPath);

            //Debug.Log(timeStart);
            //Debug.Log(timeEnd);
            //Debug.Log((timeEnd - DateTime.Now).TotalSeconds);
            //Debug.Log((DateTime.Now- timeEnd ).TotalSeconds);


            //   StartCoroutine(AudioClip());
        }
    }


}



