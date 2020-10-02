using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCounterChecker : MonoBehaviour
{
    public bool characterPassed = false;

    // On trigger exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        // If player
        if (collision.gameObject.name == "Player_Car")
        {
            // Change the variable
            characterPassed = true;
        }
    }
}
