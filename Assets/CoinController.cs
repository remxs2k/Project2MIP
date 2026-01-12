using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering is the Player
        if (other.gameObject.name == "Player")
        {
            // Add 10 points
            GameManager.instance.AddScore(10);
            // Remove coin
            Destroy(gameObject);
        }
    }
}