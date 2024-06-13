using UnityEngine;
using UnityEngine.SceneManagement;

public class AAStoryChange4 : MonoBehaviour
{
    // Referência para o canvas que você deseja controlar
    [SerializeField] private string nomeDoNivel1;


    void Update()
    {
        // Verifica se a tecla "Z" foi pressionada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(nomeDoNivel1);
        }
    }
}
