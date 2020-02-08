using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerValues : MonoBehaviour
{
    private int foundObjects = 0;
    public TMP_Text collectablesText;
    public GameObject TriggerHelper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.taskManager.taskIsOn)
        {
            if (GameManager.Instance.taskManager.GetCurrentTask() == 1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.Instance.FinishTask();
                }
            }
        }

    }

    public void RegisterFoundObject(GameObject g)
    {
        foundObjects++;
        g.SetActive(false);
        UpdateCollectablesUI();
        TriggerNextTask();
    }

    public void UpdateCollectablesUI()
    {
        collectablesText.text = $"{foundObjects} / 10 garbage collected";
    }

    public void TriggerNextTask()
    {
        GameManager.Instance.taskManager.StartTask();
    }
}
