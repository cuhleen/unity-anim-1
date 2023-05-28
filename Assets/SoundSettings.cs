using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        soundOnImage = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonClicked()
    {
        if (isOn)///the sound is on
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            MuteAllAudioSources(true);
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            MuteAllAudioSources(false);
        }
    }
    void MuteAllAudioSources(bool mute)
    {
        var audioSources = FindObjectsOfType<AudioSource>();
        foreach (var audioSource in audioSources)
        {
            audioSource.mute = mute;
        }
    }
}
