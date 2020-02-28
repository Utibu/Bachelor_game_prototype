using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderwaterBlinking : MonoBehaviour
{
    private float time = 0f;
    private float fullDuration = 1.2f;
    private float originalAlpha = 100f;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        originalAlpha = image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= fullDuration / 2f)
        {
            float newAlpha = Mathf.Lerp(originalAlpha, 0f, time / (fullDuration / 2f));
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            time += Time.deltaTime;
        } else if (time <= fullDuration)
        {
            float newAlpha = Mathf.Lerp(0f, originalAlpha, (time - (fullDuration / 2f)) / (fullDuration / 2f));
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
        }
    }
}
