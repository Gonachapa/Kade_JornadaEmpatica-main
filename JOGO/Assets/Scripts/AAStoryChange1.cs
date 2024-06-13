using UnityEngine;
using UnityEngine.SceneManagement;

public class AAStoryChange1 : MonoBehaviour
{
    // Referência para o canvas que você deseja controlar
    public GameObject canvas;
    [SerializeField] private string nomeDoNivel1;
    [SerializeField] private string nomeDoNivel2;
    [SerializeField] private string nomeDoNivel3;


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
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(nomeDoNivel3);
        }
    }
}
