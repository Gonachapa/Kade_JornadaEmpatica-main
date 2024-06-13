using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
 
public class SendSMS : MonoBehaviour
{
    public string smsUrl = "http://localhost/db/PAPBackEnd/public/SendSMS.php";
 
    public void OnClicked()
    {
        StartCoroutine(SendToken());
    }
 
    IEnumerator SendToken()
    {
        // Pegar o token JWT armazenado
        string jwtToken = PlayerPrefs.GetString("jwtToken");
 
        if (string.IsNullOrEmpty(jwtToken))
        {
            Debug.Log("Token JWT não encontrado. Por favor, faça login novamente.");
            yield break;
        }
 
        // Configurar a solicitação HTTP POST
        using (UnityWebRequest www = new UnityWebRequest(smsUrl, UnityWebRequest.kHttpVerbPOST))
        {
www.SetRequestHeader("Authorization", "Bearer " + jwtToken);
www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
 
            // Configurar a solicitação para enviar dados vazios (pois estamos apenas enviando cabeçalhos)
www.uploadHandler = new UploadHandlerRaw(new byte[0]);
www.downloadHandler = new DownloadHandlerBuffer();
 
            // Enviar a solicitação e esperar pela resposta
            yield return www.SendWebRequest();
 
            // Verificar se houve um erro na rede ou HTTP
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Erro ao enviar token: " + www.error);
            }
            else
            {
                Debug.Log("Token enviado com sucesso. Resposta do servidor: " + www.downloadHandler.text);
            }
        }
    }
}