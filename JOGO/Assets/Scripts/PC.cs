using UnityEngine;
using UnityEngine.SceneManagement;

public class PC : MonoBehaviour
{
    [SerializeField] private string nomeDoNivel;
    private bool podeTrocarCena = false;
    public GameObject[] objectsToDeactivate;

    // Função ocorre quando uma colisão entre dois objetos com o component collider 2d colidem
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Define que a troca de cena é possível
            podeTrocarCena = true;
        }
    }

    void Update()
    {
        // Verifica se a tecla Z foi pressionada e se o jogador está em contato com o objeto
        if (podeTrocarCena && Input.GetKeyDown(KeyCode.Z))
        {
            // Troca para a cena desejada
            SceneManager.LoadScene(nomeDoNivel);
        }
    }
}
