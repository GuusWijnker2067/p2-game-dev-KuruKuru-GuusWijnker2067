using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
