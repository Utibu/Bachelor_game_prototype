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
    public bool specialTaskIsOn = false;
    public List<float> taskTimes;
    private int currentTask = 0;

    public AudioSource source;

    private delegate void MyDelegate();
    private MyDelegate method;

    [Header("Task One - Water")]
    public Sprite filledWaterSprite;
    public Sprite emptyWaterSprite;
    public GameObject waterTextContainer;
    public Image waterImage;
    public AudioClip waterClip;

    [Header("Task Two - Food")]
    public Sprite halfFilledFoodSprite;
    public Sprite emptyFoodSprite;
    public GameObject foodTextContainer;
    public Image foodImage;
    public AudioClip foodClip;

    [Header("Task Three - Food 2 (Pig)")]
    public Sprite fullFoodSprite;

    [Header("Task Four - Notification")]
    public AudioClip notificationClip;

    [Header("Task Five - Drowning")]
    public AudioClip drowningClip;
    public GameObject UnderwaterUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TASKTIME: " + time);
        if(taskIsOn)
        {
            time += Time.deltaTime;
            //counterText.text = $"{time}";
            switch(currentTask)
            {
                case 1:
                    TaskOneUpdate();
                    break;
                case 2:
                    TaskTwoUpdate();
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
        //waterTextContainer.SetActive(true);
        method = TaskOneFinished;
        source.loop = true;
        source.clip = waterClip;
        source.Play();
    }

    public void StartTaskTwo()
    {
        foodImage.sprite = emptyFoodSprite;
        foodTextContainer.SetActive(true);
        method = TaskTwoFinished;
        source.loop = true;
        source.clip = foodClip;
        source.Play();
    }

    public void StartTaskThree()
    {
        method = TaskThreeFinished;
    }

    public void StartTaskFour()
    {
        method = TaskFourFinished;
        Player.Instance.playerValues.goalText.text = "Explore the ocean.";
        source.loop = false;
        source.clip = notificationClip;
        source.Play();
    }

    public void StartTaskFive()
    {
        method = TaskFiveFinished;
        UnderwaterUI.SetActive(true);
        source.loop = true;
        source.clip = drowningClip;
        source.Play();
    }

    private void TaskOneUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //GameManager.Instance.FinishTask();
        }
    }

    private void TaskTwoUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.FinishTask();
        }
    }

    private void TaskThreeUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.FinishTask();
        }*/
    }

    private void TaskOneFinished()
    {
        waterImage.sprite = filledWaterSprite;
        waterTextContainer.SetActive(false);
    }

    private void TaskTwoFinished()
    {
        foodImage.sprite = halfFilledFoodSprite;
        foodTextContainer.SetActive(false);
    }

    private void TaskThreeFinished()
    {
        foodImage.sprite = fullFoodSprite;
        foodTextContainer.SetActive(false);
        GameManager.Instance.TriggerTask();
    }

    private void TaskFourFinished()
    {

    }

    private void TaskFiveFinished()
    {
        UnderwaterUI.SetActive(false);
    }

    public void FinishTask()
    {
        taskIsOn = false;
        taskTimes.Add(time);
        source.Stop();
        source.loop = false;
        specialTaskIsOn = false;
        method();
    }

    public void StartTask(bool specialTask = false)
    {
        currentTask++;
        taskIsOn = true;
        time = 0f;

        if(specialTask)
        {
            specialTaskIsOn = true;
        }

        switch (currentTask)
        {
            case 1:
                StartTaskOne();
                break;
            case 2:
                StartTaskTwo();
                break;
            case 3:
                StartTaskThree();
                break;
            case 4:
                StartTaskFour();
                break;
            case 5:
                StartTaskFive();
                break;
            default:
                break;
        }
    }
}
