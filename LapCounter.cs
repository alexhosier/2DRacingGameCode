using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    // UI GameObjects
    [Header("UI GameObjects")]
    public Text LapCounterText;
    public Text LapTimeText;
    public Text PersonalBestText;
    
    // Declorations for the checkers
    [Header("Checkers")]
    public GameObject[] Checkers;

    // Declorations for timer system
    [Header("Timer System")]
    public float SecondCounts;
    public int MinutesTaken;
    public bool LapStarted;

    // Declare private variables
    private int CheckersPassed = 0;
    private int Lap = 0;
    private int pbSecondsTaken = 0;
    private int pbMinutesTaken = 0;

    // Called once per frame
    private void Update()
    {
        // Increase the seconds
        SecondCounts += Time.deltaTime;

        // If seconds is equal to a minute
        if(SecondCounts >= 60)
        {
            MinutesTaken += 1;
            SecondCounts = 0;
        }
        
        // Update UI with time taken so far
        LapTimeText.text = "TIME: " + FormatTime(MinutesTaken) + ":" + FormatTime((int)SecondCounts);
    }

    // On trigger exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        // For each of the checkers, check if player passed it
        foreach (GameObject checker in Checkers)
        {
            // If character passed add one to checkers passed
            if(checker.GetComponent<LapCounterChecker>().characterPassed == true)
            {
                // Increment variable
                CheckersPassed = CheckersPassed + 1;
            }
        }

        // If checkersPassed equals the amount checkers then
        if(CheckersPassed == Checkers.Length)
        {
            // If the trigger was caused by the player
            if (collision.gameObject.name == "Player_Car")
            {
                // Increment lap
                Lap = Lap + 1;

                // Update text
                LapCounterText.text = "LAP: " + Lap;

                // Reset the variable on the checkers
                foreach(GameObject checker in Checkers)
                { 
                    checker.GetComponent<LapCounterChecker>().characterPassed = false;
                }

                // Reset the amount of checkers passed
                CheckersPassed = 0;

                // Check if pbMinutes and pbSeconds are not set
                if (pbMinutesTaken == 0 && pbSecondsTaken == 0)
                {
                    // Update variables
                    pbMinutesTaken = MinutesTaken;
                    pbSecondsTaken = (int)SecondCounts;

                    // Update UI
                    PersonalBestText.text = "PB: " + FormatTime(pbMinutesTaken) + ":" + FormatTime(pbSecondsTaken);
                }
                else
                {
                    // If time beaten update
                    if (MinutesTaken <= pbMinutesTaken && SecondCounts <= pbSecondsTaken)
                    {
                        // Update variables
                        pbMinutesTaken = MinutesTaken;
                        pbSecondsTaken = (int)SecondCounts;

                        // Update UI
                        PersonalBestText.text = "PB: " + FormatTime(pbMinutesTaken) + ":" + FormatTime(pbSecondsTaken);
                    }
                }

                // Reset timer
                MinutesTaken = 0;
                SecondCounts = 0;
            }
        }
    }

    // Function to format time
    private string FormatTime(int TimeToFormat)
    {
        if(TimeToFormat < 10)
        {
            return "0" + TimeToFormat;
        } else
        {
            return "" + TimeToFormat;
        }
    }
}
