using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
 
public class Profile : MonoBehaviour
{
    public string profileUrl = "http://localhost/db/PAPBackEnd/public/api/profile.php";
    public TMP_Text usernameText;
    public TMP_Text emailText;
    public TMP_Text phonenumberText;
 
    void Start()
    {
        StartCoroutine(GetProfileData());
    }
 
    IEnumerator GetProfileData()
    {
        // Pegar o token JWT armazenado
        string jwtToken = PlayerPrefs.GetString("jwtToken");
 
        if (string.IsNullOrEmpty(jwtToken))
        {
            Debug.Log("Token JWT não encontrado. Por favor, faça login novamente.");
            yield break;
        }
 
        // Criar a solicitação GET com cabeçalho de autorização
        using (UnityWebRequest www = UnityWebRequest.Get(profileUrl))
        {
www.SetRequestHeader("Authorization", "Bearer " + jwtToken);
www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
 
            // Enviar a solicitação e esperar pela resposta
            yield return www.SendWebRequest();
 
            // Verificar se houve um erro na rede ou HTTP
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Erro ao recuperar dados do perfil: " + www.error);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                Debug.Log("Resposta do perfil: " + jsonResponse);
 
                // Verificar se a resposta JSON está correta
                try
                {
                    ProfileResponse response = JsonUtility.FromJson<ProfileResponse>(jsonResponse);
 
                    if (response.status == "200")
                    {
                        // Atualizar a UI com as informações do perfil
                        usernameText.text = response.data.username;
                        emailText.text = response.data.email;
                        phonenumberText.text = response.data.phonenumber;
                    }
                    else
                    {
                        Debug.Log("Erro ao recuperar dados do perfil: " + response.message);
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.Log("Erro ao desserializar JSON: " + ex.Message);
                    Debug.Log("JSON Recebido: " + jsonResponse);
                }
            }
        }
    }
}
 
[System.Serializable]
public class ProfileResponse
{
    public string status;
    public ProfileData data;
    public string message;
}
 
[System.Serializable]
public class ProfileData
{
    public string username;
    public string email;
    public string phonenumber;
}