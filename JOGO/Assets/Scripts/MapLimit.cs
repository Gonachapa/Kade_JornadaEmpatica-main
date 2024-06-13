using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLimit : MonoBehaviour
{
    public GameObject LimitCanvas;
    public float moveSpeed = 5f; // Velocidade de movimento do jogador

    // Função ocorre quando uma colisão entre dois objetos com o componente Collider2D acontece
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica se o objeto com o qual o jogador colidiu é o "right_limit"
            if (gameObject.name == "Right_limit")
            {
                // Mover o jogador para a esquerda
                MovePlayerLeft(collision.gameObject);
            }
            // Verifica se o objeto com o qual o jogador colidiu é o "left_limit"
            else if (gameObject.name == "Left_limit")
            {
                // Mover o jogador para a direita
                MovePlayerRight(collision.gameObject);
            }
            // Ativa ou desativa o canvas de limite, conforme necessário
            else if (gameObject.name == "Up_limit")
            {
                // Mover o jogador para a direita
                MovePlayerUp(collision.gameObject);
            }
            // Ativa ou desativa o canvas de limite, conforme necessário
            else if (gameObject.name == "Down_limit")
            {
                // Mover o jogador para a direita
                MovePlayerDown(collision.gameObject);
            }
            // Ativa ou desativa o canvas de limite, conforme necessário
            LimitCanvas.SetActive(!LimitCanvas.activeSelf);
        }
    }

    // Função para mover o jogador para a esquerda
    private void MovePlayerLeft(GameObject player)
    {
        // Calcula a nova posição do jogador (movendo para a esquerda)
        Vector3 newPosition = player.transform.position - Vector3.right * moveSpeed * Time.deltaTime;
        // Define a nova posição do jogador
        player.transform.position = newPosition;
    }

    // Função para mover o jogador para a direita
    private void MovePlayerRight(GameObject player)
    {
        // Calcula a nova posição do jogador (movendo para a direita)
        Vector3 newPosition = player.transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        // Define a nova posição do jogador
        player.transform.position = newPosition;
    }

    private void MovePlayerUp(GameObject player)
    {
        // Calcula a nova posição do jogador (movendo para a direita)
        Vector3 newPosition = player.transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        // Define a nova posição do jogador
        player.transform.position = newPosition;
    }

    private void MovePlayerDown(GameObject player)
    {
        // Calcula a nova posição do jogador (movendo para a direita)
        Vector3 newPosition = player.transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        // Define a nova posição do jogador
        player.transform.position = newPosition;
    }
}
