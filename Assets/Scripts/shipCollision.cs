using UnityEngine;

[RequireComponent(typeof(Collider))]
public class shipCollision : MonoBehaviour
{

    //This is a custom collision for the ships to match by tag and not by team

    //Checks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        if(CompareTag(collision.gameObject.tag))
        {
            //Check if the gameObject is an AI invider and if it the case it adds score to the game manager
            if (gameObject.GetComponent<invidersAI>() != null && GameManager.instance != null)
            {
                GameManager.instance.addScore();
            }
            Destroy(gameObject);
        }
    }
}
