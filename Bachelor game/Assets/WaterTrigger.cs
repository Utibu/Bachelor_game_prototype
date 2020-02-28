using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{

    public GameObject WaterUI;
    public bool hasFinishedTaskFour = false;
    public bool inArea = false;

    private float time = 0f;
    public float delay = 10f;
    private float completionTime = 0f;
    public float completionDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasFinishedTaskFour && inArea)
        {
            if (GameManager.Instance.taskManager.taskIsOn && GameManager.Instance.taskManager.GetCurrentTask() == 4)
            {
                GameManager.Instance.FinishTask();
                //GameManager.Instance.TriggerTask();
                hasFinishedTaskFour = true;

            }
        }

        if(inArea && hasFinishedTaskFour && GameManager.Instance.taskManager.GetCurrentTask() == 4)
        {
            if(time <= delay)
            {
                time += Time.deltaTime;
            }
            else
            {
                GameManager.Instance.TriggerTask();
            }
        }

        if (GameManager.Instance.taskManager.taskIsOn && GameManager.Instance.taskManager.GetCurrentTask() == 5)
        {
            if(!inArea)
            {
                if(completionTime <= completionDelay)
                {
                   completionTime += Time.deltaTime;
                }
                else
                {
                    GameManager.Instance.FinishTask();
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        WaterUI.SetActive(true);
        /*if (GameManager.Instance.taskManager.GetCurrentTask() == 4 && hasFinishedTaskFour)
        {
            GameManager.Instance.TriggerTask();
        }*/
        if (other.CompareTag("Player"))
        {
            inArea = true;
        }

        completionTime = 0f;
        Debug.Log("RESET COMPLETION TIME");
    }

    private void OnTriggerExit(Collider other)
    {
        WaterUI.SetActive(false);
        /*if (GameManager.Instance.taskManager.GetCurrentTask() == 4)
        {
            GameManager.Instance.CancelInvoke();
        }*/
        if (other.CompareTag("Player"))
        {
            inArea = false;
        }

        time = 0f;
        Debug.Log("RESET TIME");
    }
}
