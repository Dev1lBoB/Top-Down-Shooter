using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private Text countdownUI;

    public IEnumerator StartCountdown(int remainingTime)
    {
        --remainingTime;
        if (remainingTime == 0) // Stop the recursion when the time runs out
            yield break;
        countdownUI.text = remainingTime.ToString();
        yield return new WaitForSeconds(0.5f);
        yield return StartCountdown(remainingTime); // Recursively update the timer
    }
}
