using UnityEngine;

public class FreezeAnimationOnJump : MonoBehaviour
{
    public string animationName = "Running"; // Nombre de la animaci�n
    public float freezeFrameTime = 0.233f;   // Tiempo del frame 7 en segundos (ajusta seg�n la duraci�n de tu animaci�n)
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FreezeAnimation()
    {
        // Congelar la animaci�n en el frame 7
        animator.Play(animationName, 0, freezeFrameTime);
        animator.speed = 0; // Detener la animaci�n
    }

    public void UnfreezeAnimation()
    {
        // Reanudar la animaci�n
        animator.speed = 1;
    }
}
