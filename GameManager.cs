using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public void EndGame()
    {
        //it allows to be call just one time
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }
    //the end scene is loaded
    void Restart()
    {
        SceneManager.LoadScene("end");
    }
}
