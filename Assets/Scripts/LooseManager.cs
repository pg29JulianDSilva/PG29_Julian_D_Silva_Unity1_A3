using TMPro;
using UnityEngine;

public class LooseManager : MonoBehaviour
{

    //This is an excluse gameover script to manage the canvas on the game over level

    [Header("GUI")]//Gets the Canvas elements
    [SerializeField] private GameObject _score;
    private TextMeshProUGUI displayScore;

    //Calls the score from the game manager once the player has loose
    private void Start()
    {
        displayScore = _score.GetComponent<TextMeshProUGUI>();
        if(GameManager.instance != null)
        {
            displayScore.text = "Your score is: "+ GameManager.instance.scoreDisplay();
        }
    }

    //Call the scene manager of the GameManager to play again
    public void restart()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.startGame();
        }
    }

}
