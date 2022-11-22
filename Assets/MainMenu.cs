using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonHandler()
    {
        SceneManager.LoadScene("GameScene");
    }
}
