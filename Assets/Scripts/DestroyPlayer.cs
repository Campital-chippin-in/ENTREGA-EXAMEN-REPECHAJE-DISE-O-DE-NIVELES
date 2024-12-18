using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DestroyPlayer : MonoBehaviour
{
    public float delay = 3f;  // Tiempo de espera antes de reiniciar la escena

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);  // Elimina al jugador
            StartCoroutine(RestartScene());  // Inicia la corrutina para reiniciar la escena
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(delay);  // Espera durante el tiempo especificado
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reinicia la escena actual
    }
}
