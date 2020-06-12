using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoaderAnim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] float letterPause = 0.2f;
    [SerializeField] char[] extraCharacters;
    string textComponent;
    void Start()
    {
        textComponent = loadingText.text;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        while (true)
        {
            foreach (char letter in extraCharacters)
            {
                loadingText.text += letter;
                yield return new WaitForSeconds(letterPause);
            }
            loadingText.text = textComponent;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
