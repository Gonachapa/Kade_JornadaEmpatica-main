using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private bool playerCollided = false;

    // Detecta colisão com o jogador
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollided = true;
        }
    }

    // Detecta quando o jogador sai da colisão
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollided = false;
        }
    }

    void Update()
    {
        // Verifica se a tecla Z foi pressionada e o jogador está em colisão
        if (playerCollided && Input.GetKeyDown(KeyCode.Z))
        {
            // Muda para a cena desejada (substitua "SceneName" pelo nome da cena)
            SceneManager.LoadScene("BossFight");
        }
    }
}

