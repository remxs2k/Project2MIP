using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Did we hit anything at all?
        Debug.Log("The Enemy hit: " + other.gameObject.name);

        if (other.gameObject.name == "Player")
        {
            // 2. We hit the player! Trying to call Game Over...
            Debug.Log("Hit the Player! Calling Game Over...");

            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
                Debug.Log("Game Over command sent.");
            }
            else
            {
                Debug.LogError("ERROR: GameManager.instance is NULL! Is the GameManager object in the scene?");
            }
        }
    }
}