using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class mp3Test : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    public void LoadButton()
    {
        StartCoroutine(LoadAudioClip());
    }
    IEnumerator LoadAudioClip()
    {

        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(("D:\\1\\2.mp3"), AudioType.MPEG))
        {
            yield return uwr.SendWebRequest();
            var  Musics = DownloadHandlerAudioClip.GetContent(uwr);

            audioSource.clip = Musics;

            audioSource.Play();
        }
    }
}
