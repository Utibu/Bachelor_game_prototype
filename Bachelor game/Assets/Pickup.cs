using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private bool inArea = false;
    public string TriggerHelperText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inArea)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Player.Instance.playerValues.TriggerHelper.SetActive(false);


                if(GameManager.Instance.taskManager.specialTaskIsOn)
                {
                    Player.Instance.playerValues.RegisterFoundObject(this.gameObject, false);
                    GameManager.Instance.FinishTask();
                }
                else
                {
                    Player.Instance.playerValues.RegisterFoundObject(this.gameObject);
                }
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Instance.playerValues.TriggerHelperText.text = TriggerHelperText;
            Player.Instance.playerValues.TriggerHelper.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
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
