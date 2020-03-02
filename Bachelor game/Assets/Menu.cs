using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public AudioMixerGroup mixerGroup;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayVersionOne()
    {
        //Sound
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("CurrentVersion", 1);
        SceneManager.LoadScene(1);
    }

    public void PlayVersionTwo()
    {
        //No Sound
        mixerGroup.audioMixer.SetFloat("Volume", -80f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("CurrentVersion", 2);
        SceneManager.LoadScene(1);
    }
}
