using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{

    public GameObject WaterUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        WaterUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        WaterUI.SetActive(false);
    }
}
