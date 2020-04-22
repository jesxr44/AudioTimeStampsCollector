using UnityEngine;
using System.Collections.Generic;
using System.IO;

[RequireComponent(typeof(AudioSource))]
public class TimeStampCollector : MonoBehaviour
{
    AudioSource audioSource;
    private bool paused;

    private List<float> timeStamps = new List<float>();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            string listOfTimeStamps = string.Join(",", timeStamps);
            Debug.Log(listOfTimeStamps);

            File.WriteAllText(Application.dataPath + "/Results/Timestamps.txt", listOfTimeStamps);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            timeStamps.Add(audioSource.time);
            Debug.Log(audioSource.time);
        }
    }
}