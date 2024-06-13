using UnityEngine;
using UnityEngine.SceneManagement;

public class AAStoryChange2 : MonoBehaviour
{
    // Referência para o canvas que você deseja controlar
    [SerializeField] private string nomeDoNivel1;
    [SerializeField] private string nomeDoNivel2;


    void Update()
    {
        // Verifica se a tecla "Z" foi pressionada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(nomeDoNivel1);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(nomeDoNivel2);
        }
    }
}
