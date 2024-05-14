using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    // Reference to the UI Text component displaying the score
    public Text score;

    // Static variable to keep track of the score across all instances of Scoring
    public static int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score count to 0 at the start of the game
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the text of the score UI element with the current score coun
        score.text = " " + Mathf.Round(scoreCount);

    }
}
