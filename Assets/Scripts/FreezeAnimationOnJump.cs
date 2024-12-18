using UnityEngine;

public class FreezeAnimationOnJump : MonoBehaviour
{
    public string animationName = "Running"; // Nombre de la animación
    public float freezeFrameTime = 0.233f;   // Tiempo del frame 7 en segundos (ajusta según la duración de tu animación)
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FreezeAnimation()
    {
        // Congelar la animación en el frame 7
        animator.Play(animationName, 0, freezeFrameTime);
        animator.speed = 0; // Detener la animación
    }

    public void UnfreezeAnimation()
    {
        // Reanudar la animación
        animator.speed = 1;
    }
}
