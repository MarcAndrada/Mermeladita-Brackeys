using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {
    [SerializeField] private int maxTimeInSeconds;
    private float seconds;

    private TMP_Text timerText;

    private void Start() {
        timerText = GetComponent<TMP_Text>();
        seconds = maxTimeInSeconds;
    }

    private void Update() {
        if (seconds >= 0) {
            seconds -= Time.deltaTime;
            UpdateTime(seconds);
        }
    }

    private void UpdateTime(float seconds) {
        
        int currentTime = Mathf.FloorToInt(seconds % 60);
        timerText.text = currentTime.ToString();
    }
}
