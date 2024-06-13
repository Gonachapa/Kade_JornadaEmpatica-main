using UnityEngine;
using UnityEngine.SceneManagement;

public class TradeScene : MonoBehaviour
{
    [SerializeField] private string nomeDoNivel;

    // This method is called when the button is clicked
    public void TrocarCena()
    {
        SceneManager.LoadScene(nomeDoNivel);
    }
}