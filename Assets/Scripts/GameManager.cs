using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private int _score = 0;

    //sets the beggining to don't destroy on load
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }    
    }

    //start the game and restart the score if restated
    public void startGame()
    {
        _score = 0;
        SceneManager.LoadScene("MainGameScene");
    }

    //when there is a game over
    public void endGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    //When the player adds score
    public void addScore()
    {
        _score += 50;
    }

    //Displays the score when game ends
    public int scoreDisplay()
    {
        return _score;
    }
}
