using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{

    //It creates a safety borderfor the elements to get destroyed or located inside the screen

    private Collider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<Collider>();
    }

    private void OnTriggerExit(Collider other)
    {
        //This one what it does is that, it detects anything except the player
        if (other.gameObject.GetComponent<CharacterControl>() == null) 
        { 
            Destroy(other.gameObject);
            return;
        }

        Vector3 min = _boxCollider.bounds.min;
        Vector3 max = _boxCollider.bounds.max;

        Vector3 playerPosition = other.transform.position;

        if (playerPosition.z > max.z || playerPosition.z < min.z) playerPosition.z *= -1;
        if (playerPosition.x > max.x || playerPosition.x < min.x) playerPosition.x *= -1;

        other.transform.position = playerPosition;
        
    }

}

