using UnityEngine;
using UnityEngine.SceneManagement;

public class AAStoryChange5 : MonoBehaviour
{
    // Referência para o canvas que você deseja controlar
    [SerializeField] private string nomeDoNivel1;
    [SerializeField] private string nomeDoNivel2;


    void Update()
    {
        // Verifica se a tecla "Z" foi pressionada
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(nomeDoNivel1);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(nomeDoNivel2);
        }
    }
}
