using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
    [SerializeField]
    private Text comboText;

    [SerializeField]
    private float fadeOutSpeed = 1f;
    [SerializeField]
    private float delayAmount = 3f;

    private Coroutine currentRoutine = null;

    public void ShowCombo(string finalCombo)
    {
        // Recieve information about the killing combo and show it to the screen
        comboText.color = new Color(comboText.color.r, comboText.color.g, comboText.color.b, 1f); // Make sure that the comboText is visible
        comboText.text = finalCombo;

        if (currentRoutine != null)
            StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(FadeOutText());
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    private IEnumerator FadeOutText()
    {
        yield return Delay(delayAmount);

        while (comboText.color.a > 0)
        {
            Color c = comboText.color;
            float fadeAmount = c.a - fadeOutSpeed * Time.deltaTime;

            c = new Color(c.r, c.g, c.b, fadeAmount);
            comboText.color = c;
            yield return null;
        }
        currentRoutine = null;
    }
}
