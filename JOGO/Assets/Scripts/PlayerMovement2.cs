using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeedMultiplier = 2f; // Multiplicador de velocidade ao correr
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject[] canvases; // Array de refer�ncias para os canvases

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Verificar se todos os canvases est�o inativos
        bool allCanvasesInactive = true;
        foreach (GameObject canvas in canvases)
        {
            if (canvas.activeSelf)
            {
                allCanvasesInactive = false;
                break;
            }
        }

        // Permitir o movimento do jogador apenas se todos os canvases estiverem inativos
        if (allCanvasesInactive)
        {
            // Obter a entrada do eixo horizontal e vertical
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            // Normalizar o vetor de movimento para evitar movimento diagonal mais r�pido
            movement = new Vector2(moveX, moveY).normalized;

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            // Verificar se a tecla Shift est� pressionada para correr
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                // Multiplicar a velocidade de movimento pelo multiplicador de corrida
                rb.MovePosition(rb.position + movement * (moveSpeed * runSpeedMultiplier) * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            // Se pelo menos um canvas estiver ativo, definir todas as anima��es para 0 e impedir o movimento do jogador
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
    }
}
