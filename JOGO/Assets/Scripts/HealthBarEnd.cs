using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarEnd : MonoBehaviour
{
    public Image healthBar; // Referência à barra de vida
    public string nomeDoNivel;
    void Update()
    {
        // Verifica se a barra de vida está igual a 0
        if (healthBar.fillAmount == 0)
        {
            // Muda para a cena "GameOverScene"
            SceneManager.LoadScene(nomeDoNivel);
        }
    }
}
