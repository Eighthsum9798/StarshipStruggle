using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI; //references game over ui canvas in level

    

    //method to call up game over ui
    public void gameOver() 
    {
        gameOverUI.SetActive(true); // sets gameover ui to active and shows on screen
    }

}
