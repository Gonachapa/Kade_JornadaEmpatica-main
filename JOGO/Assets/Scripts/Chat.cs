using UnityEngine;
using UnityEngine.SceneManagement;

public class Chat : MonoBehaviour
{
    [SerializeField] private string nomeDoNivel;

    // Função chamada quando ocorre um clique no objeto
    private void OnMouseDown()
    {
        // Troca para a cena desejada
        SceneManager.LoadScene(nomeDoNivel);
    }
}
