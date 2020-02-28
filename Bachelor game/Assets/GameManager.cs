using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TaskManager taskManager;
    public List<GameObject> pickups;
    private Queue<GameObject> pickupQueue;
    public Canvas finishCanvas;
    public FilePrinter filePrinter;
    public int Version = 0;
    public TMP_InputField IdentifierInput;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            Debug.LogError("Instance already exists of " + this.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //ShowFinish();
        pickupQueue = new Queue<GameObject>();
        Debug.Log(pickups.Count);
        for(int i = 0; i <= pickups.Count - 1; i++)
        {
            GameObject go = pickups[i];
            go.SetActive(false);
            pickupQueue.Enqueue(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerTask()
    {
        switch(taskManager.GetCurrentTask())
        {
            case 0:
                Invoke("TriggerTaskHandler", 1f);
                break;
            case 1:
                Invoke("TriggerTaskHandler", 1f);
                break;
            case 3:
                Invoke("TriggerTaskHandler", 10f);
                break;
            default:
                TriggerTaskHandler();
                break;
        }

    }

    public void TriggerTaskHandler(bool specialTask)
    {
        taskManager.StartTask(specialTask);
    }

    public void TriggerTaskHandler()
    {
        taskManager.StartTask();
    }

    public void CancelTriggers()
    {
        Debug.Log("CANCEL INVOKE!");
        CancelInvoke("TriggerTaskHandler");
    }

    public void FinishTask()
    {
        taskManager.FinishTask();
        if (pickupQueue.Count > 0)
        {
            GameObject newGameObject = pickupQueue.Dequeue();
            Debug.Log(newGameObject.name);
            newGameObject.SetActive(true);
            if (newGameObject.CompareTag("Instant"))
            {
                TriggerTaskHandler(true);
            }

        }
        else
        {
            Debug.Log("GAME FINISHED!");
            ShowFinish();
        }
    }

    public void ShowFinish()
    {
        Debug.Log("SHOWFINISH");
        finishCanvas.gameObject.SetActive(true);
        Player.Instance.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
        Player.Instance.GetComponent<FirstPersonAIO>().playerCanMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Save()
    {
        filePrinter.SaveFile(IdentifierInput.text);
    }
}
