using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LeaveMarket : MonoBehaviour
{
    public string nomeDaCenaParaTrocar;
    public TMP_Text textMeshPro1; // Referência para o primeiro TextMeshPro
    public TMP_Text textMeshPro2; // Referência para o segundo TextMeshPro

    // Este método será chamado quando o botão for clicado
    public void LeaveMarketOnClick()
    {
        // Verifica se o texto dos TextMeshPro é "2" e "1"
        if (textMeshPro1.text == "2" && textMeshPro2.text == "1")
        {
            // Se sim, carrega a cena especificada
            SceneManager.LoadScene(nomeDaCenaParaTrocar);
        }
        else
        {
            // Caso contrário, faça outra coisa, como exibir uma mensagem de erro
            Debug.Log("Os valores dos TextMeshPro não correspondem aos requisitos para sair do mercado.");
        }
    }
}
