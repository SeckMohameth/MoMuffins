using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CountdownControllerScript : MonoBehaviour
{
    public int countDownTime;
    public TMP_Text countDownDisplay;

    public void Start()
    {
        StartCoroutine(CountDownToStart());
    }

    IEnumerator CountDownToStart()
    {
        while(countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        countDownDisplay.text = "GO!";

        //GameController.instance.BeginGame();

        yield return new WaitForSeconds(1f);

        countDownDisplay.gameObject.SetActive(false);
    }
}
