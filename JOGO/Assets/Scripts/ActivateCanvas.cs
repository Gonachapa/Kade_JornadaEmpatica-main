    using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateCanvas : MonoBehaviour
{
    public GameObject[] canvases;
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;
    private int currentCanvasIndex = 0;
    private bool podeTrocarCena = false;

    // Função ocorre quando uma colisão entre dois objetos com o componente Collider2D acontece
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
            // Desativa o canvas atual
            if (currentCanvasIndex < canvases.Length)
            {
                canvases[currentCanvasIndex].SetActive(false);
                currentCanvasIndex++;
            }
            else
            {
                // Se todos os canvases foram ativados, reinicia o índice para mostrar o primeiro canvas novamente
                currentCanvasIndex = 0;
            }

            // Ativa o próximo canvas na lista
            if (currentCanvasIndex < canvases.Length)
            {
                canvases[currentCanvasIndex].SetActive(true);
            }

            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                    obj.SetActive(true);
            }

            foreach (GameObject obj in objectsToDeactivate)
            {
                if (obj != null)
                    obj.SetActive(false);
            }

            // Verifica se todos os canvases foram lidos e, se sim, remove o script do objeto
            if (currentCanvasIndex == canvases.Length)
            {
                // Remove o script do objeto
                Destroy(this);
            }
        }
    }
}
