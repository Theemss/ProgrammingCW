using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartgame : MonoBehaviour
{
    bool gameHasRestart = false;

    void Update()
    {
        //if the player press R it will restart the game
        if (Input.GetKey(KeyCode.R))
        {
            //it allows to be call just one time
            if (gameHasRestart == false)
            {
                gameHasRestart = true;
                Restart();
            }
        }
    }
    //the first scene with the game is loaded
    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
