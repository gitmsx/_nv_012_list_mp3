using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class mp3Test3 : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip _audioClip;
    AudioSource audioSource;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        LoadButton();



    }


    public void LoadButton()
    {
        StartCoroutine(LoadAudioClip());
    }

    IEnumerator LoadAudioClip()
    {
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(("D:/1/2.mp3"), AudioType.MPEG))
        {
            yield return uwr.SendWebRequest();
            _audioClip = DownloadHandlerAudioClip.GetContent(uwr);
            audioSource.clip = _audioClip;
            audioSource.Play();
         //   StartCoroutine(AudioClip());
        }
    }


    IEnumerator AudioClip()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip =null;
    }

}





