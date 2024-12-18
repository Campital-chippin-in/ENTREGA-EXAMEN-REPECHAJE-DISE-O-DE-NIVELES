using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    public void QuitGame()
    {
        // Solo funciona en una aplicación compilada, no en el editor de Unity
        Application.Quit();

        // Código adicional para comprobar en el editor (opcional)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
