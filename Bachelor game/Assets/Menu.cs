using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
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
    }

    public void PlayVersionTwo()
    {
        //No Sound
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
