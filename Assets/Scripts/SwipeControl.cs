using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour
{
    public GameObject scrollbar;
    float scrollPos = 0;
    float[] posOfContent;
    int newPos = 0;
    void Start()
    {
        
    }

    public void Next()
    {
        if(newPos < posOfContent.Length - 1)
        {
            newPos += 1;
            scrollPos = posOfContent[newPos];
        }
    }

    public void Previous()
    {
        if (newPos > 0)
        {
            newPos -= 1;
            scrollPos = posOfContent[newPos];
        }
    }
    void Update()
    {
        posOfContent = new float[transform.childCount];
        float distance = 1f / (posOfContent.Length - 1f);
        for(int index = 0; index < posOfContent.Length; index++)
        {
            posOfContent[index] = distance * index;
        }

        if(Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int index = 0; index<posOfContent.Length;index++)
            {
                if(scrollPos < posOfContent[index] + (distance/2) && scrollPos > posOfContent[index] - (distance/2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, posOfContent[index], 0.15f);
                    newPos = index;
                }
            }
        }
    }
}
