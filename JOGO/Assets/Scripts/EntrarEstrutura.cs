using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarEstrutura : MonoBehaviour
{
    [SerializeField] private string nomeDoNivel;

    // Função chamada quando ocorre uma colisão 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Troca para a cena desejada
            SceneManager.LoadScene(nomeDoNivel);
        }
    }
}
