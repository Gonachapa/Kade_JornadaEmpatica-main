using UnityEngine;
using UnityEngine.SceneManagement;

public class Banana : MonoBehaviour
{
    // Nome da cena que você deseja carregar

    void Update()
    {
        // Verifica se a tecla 'Z' foi pressionada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Carrega a cena especificada
            SceneManager.LoadScene("GameOverF2");
        }
    }
}
