using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour {

    public Image countdownImage;

    public float timer = 1f;

    void Update () {
        timer -= .1f * Time.deltaTime;

        countdownImage.fillAmount = timer;

        if (timer < 0) {
            // Switch turn
        }
	}
}
