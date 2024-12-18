using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    public void QuitGame()
    {
        // Solo funciona en una aplicaci�n compilada, no en el editor de Unity
        Application.Quit();

        // C�digo adicional para comprobar en el editor (opcional)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
