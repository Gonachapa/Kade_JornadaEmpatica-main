using UnityEngine;

public class Fase1 : MonoBehaviour
{
    [SerializeField] private GameObject objetoAtivar;
    private bool podeTrocarCena = false;

    // Função ocorre quando uma colisão entre dois objetos com o componente Collider 2D colidem
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
            // Ativa o objeto desejado
            objetoAtivar.SetActive(true);
        }
    }
}
