using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public int countDownTimer;
    public Text countDownDisplay;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        countDownDisplay.text = countDownTimer.ToString();
        yield return new WaitForSecondsRealtime(1f);

        while (countDownTimer > 0)
        {
            countDownTimer--;
            countDownDisplay.text = countDownTimer.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        countDownDisplay.text = "GO!!!";
        yield return new WaitForSecondsRealtime(1f);

        countDownDisplay.gameObject.SetActive(false);
    }
}
