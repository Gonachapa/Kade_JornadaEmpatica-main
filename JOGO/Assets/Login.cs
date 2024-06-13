using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
 
// Classe para desserializar o JSON
[System.Serializable]
public class LoginResponse
{
    public TokenData data;
    public string status;
    public string message;
}
 
[System.Serializable]
public class TokenData
{
    public string token;
}
 
public class Login : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;
    public string loginUrl = "http://localhost/db/PAPBackEnd/public/api/login.php";
 
    public void OnLoginButtonClicked()
    {
        StartCoroutine(LoginUser());
    }
 
    IEnumerator LoginUser()
    {
        // Criar o formulário
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("password", password.text);
 
        // Criar a solicitação POST
        using (UnityWebRequest www = UnityWebRequest.Post(loginUrl, form))
        {
            // Enviar a solicitação e esperar pela resposta
            yield return www.SendWebRequest();
 
            // Verificar se houve um erro na rede ou HTTP
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Erro no login: " + www.error);
            }
            else
            {
                Debug.Log("Resposta do login: " + www.downloadHandler.text);
 
                // Desserializar a resposta JSON
                LoginResponse response = JsonUtility.FromJson<LoginResponse>(www.downloadHandler.text);
 
                if (response.status == "200")
                {
                    // Armazenar apenas o token no token JWT
                    PlayerPrefs.SetString("jwtToken", response.data.token);
                    Debug.Log(response.data.token);
                    // Carregar a próxima cena
                    SceneManager.LoadScene("Menu");
                }
                else
                {
                    Debug.Log("Falha no login: " + response.message);
                }
            }
        }
    }
}