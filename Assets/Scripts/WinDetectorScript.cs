using UnityEngine;

public class WinDetectorScript : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        WinGame();
    }

    void WinGame()
    {
        // Placeholder
        Debug.Log("You've won the level.");
    }
}