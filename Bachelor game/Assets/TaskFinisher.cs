using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFinisher : MonoBehaviour
{
    private bool inArea = false;
    public string TriggerHelperText;
    public int TaskToFinish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inArea && GameManager.Instance.taskManager.GetCurrentTask() == TaskToFinish && GameManager.Instance.taskManager.taskIsOn)
        {
            //if(Input.GetMouseButtonDown(0))
            if(Input.GetKeyDown(KeyCode.E))
            {
                Player.Instance.playerValues.TriggerHelper.SetActive(false);
                GameManager.Instance.FinishTask();

                /*if (GameManager.Instance.taskManager.specialTaskIsOn)
                {
                    Player.Instance.playerValues.RegisterFoundObject(this.gameObject, false);
                    GameManager.Instance.FinishTask();
                }
                else
                {
                    Player.Instance.playerValues.RegisterFoundObject(this.gameObject);
                }*/
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.taskManager.GetCurrentTask() == TaskToFinish && GameManager.Instance.taskManager.taskIsOn)
        {
            Player.Instance.playerValues.TriggerHelperText.text = TriggerHelperText;
            Player.Instance.playerValues.TriggerHelper.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && GameManager.Instance.taskManager.GetCurrentTask() == TaskToFinish && GameManager.Instance.taskManager.taskIsOn)
        {
            inArea = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inArea = false;
            Player.Instance.playerValues.TriggerHelper.SetActive(false);
        }
    }
}
