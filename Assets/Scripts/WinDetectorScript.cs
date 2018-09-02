using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDetectorScript : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        WinGame();
    }

    public void WinGame()
    {
        GameObject.Find("/GameComplete").GetComponent<GameComplete>().win.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadNext()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}