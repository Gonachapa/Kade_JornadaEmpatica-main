using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class VerifySMS : MonoBehaviour
{
    public string verificationUrl = "http://localhost/db/PAPBackEnd/public/verefication.php";
    public TMP_InputField inputField; // Campo de entrada de texto
    public Button verifyButton; // Botão de verificação

    void Start()
    {
        verifyButton.onClick.AddListener(OnVerifyButtonClicked);
    }

    public void OnVerifyButtonClicked()
    {
        string verificationCode = inputField.text;
        StartCoroutine(VerifyTokenAndCode(verificationCode));
    }

    IEnumerator VerifyTokenAndCode(string verificationCode)
    {
        // Pegar o token JWT armazenado
        string jwtToken = PlayerPrefs.GetString("jwtToken");

        if (string.IsNullOrEmpty(jwtToken))
        {
            Debug.LogError("Token JWT não encontrado. Por favor, faça login novamente.");
            yield break;
        }

        // Criar o formulário para enviar o código SMS
        WWWForm form = new WWWForm();
        form.AddField("codigo_sms", verificationCode);

        // Configurar a solicitação HTTP POST
        using (UnityWebRequest www = UnityWebRequest.Post(verificationUrl, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + jwtToken);
            www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            // Enviar a solicitação e esperar pela resposta
            yield return www.SendWebRequest();

            // Verificar se houve um erro na rede ou HTTP
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Erro ao enviar token: " + www.error);
            }
            else
            {
                Debug.Log("Resposta do servidor: " + www.downloadHandler.text);

                // Analisar a resposta JSON
                var response = JsonUtility.FromJson<ServerResponse>(www.downloadHandler.text);

                // Verificar se a verificação foi bem-sucedida
                if (response.status == 200)
                {
                    Debug.Log("Código de verificação válido. Abrindo nova cena...");
                    // Abra a próxima cena
                    SceneManager.LoadScene("userdata_change 1"); // Substitua "EditProfile" pelo nome da sua próxima cena
                }
                else
                {
                    Debug.LogError("Falha na verificação: " + response.message);
                }
            }
        }
    }

    [System.Serializable]
    public class ServerResponse
    {
        public int status;
        public string message;
    }
}
