using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu"); // Cambiar a la escena MainMenu
    }
}
