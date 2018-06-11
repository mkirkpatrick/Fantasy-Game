using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public float gameClock = 0f;
    public float timeMultiplier = 1f;

    public int currentDay = 1;
    public float currentTime = 6f;
    public int hours;
    public float minutes;

    public bool isDaytime = true;
    public bool isPaused = false;

	void Start () {
		
	}
	
	void Update () {

        if (isPaused != true) {
            UpdateClocks();
        }
    }

    public void UpdateClocks() {
        float startTime = gameClock;
        gameClock += Time.deltaTime * timeMultiplier;

        float timeChange = gameClock - startTime;
        currentTime += timeChange;

            minutes += timeChange;
        if (minutes >= 60) {
            //Check for 6am day change
            if (hours == 5)
                currentDay++;
            minutes -= 60;
            hours++;
        }

        if (hours >= 24) {
            hours -= 24;
        }
        
    }
}
