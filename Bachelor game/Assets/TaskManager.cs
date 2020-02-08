using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TaskManager : MonoBehaviour
{

    public TMP_Text counterText;
    public float time;
    public bool taskIsOn = false;
    public List<float> taskTimes;
    private int currentTask = 0;

    public AudioSource source;

    private delegate void MyDelegate();
    private MyDelegate method;

    public Sprite filledWaterSprite;
    public Sprite emptyWaterSprite;
    public GameObject waterTextContainer;
    public Image waterImage;
    public AudioClip waterClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(taskIsOn)
        {
            time += Time.deltaTime;
            counterText.text = $"{time}";
            switch(currentTask)
            {
                case 1:
                    TaskOneUpdate();
                    break;
                default:
                    break;
            }
        }
    }

    public int GetCurrentTask()
    {
        return currentTask;
    }

    public void StartTaskOne()
    {
        waterImage.sprite = emptyWaterSprite;
        waterTextContainer.SetActive(true);
        method = TaskOneFinished;
        source.loop = true;
        source.clip = waterClip;
        source.Play();
    }

    private void TaskOneUpdate()
    {

    }

    private void TaskOneFinished()
    {
        waterImage.sprite = filledWaterSprite;
        waterTextContainer.SetActive(false);
    }

    public void FinishTask()
    {
        taskIsOn = false;
        taskTimes.Add(time);
        source.Stop();
        source.loop = false;
        method();
    }

    public void StartTask()
    {
        currentTask++;
        taskIsOn = true;
        time = 0f;

        switch (currentTask)
        {
            case 1:
                StartTaskOne();
                break;
            default:
                break;
        }
    }
}
