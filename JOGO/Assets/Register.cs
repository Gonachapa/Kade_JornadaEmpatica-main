using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
 
public class Register : MonoBehaviour
{
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public TMP_InputField EmailInput;
    public TMP_InputField PhoneNumberInput;
    public Button RegisterButton;
 
    // URL para o script PHP de registro
    private string registerURL = "http://localhost/db/PAPBackEnd/public/api/Regist.php";
 
    void Start()
    {
        RegisterButton.onClick.AddListener(RegisterUser);
    }
 
    void RegisterUser()
    {
        StartCoroutine(RegisterCoroutine());
    }
 
    IEnumerator RegisterCoroutine()
    {
        // Criação do formulário com os dados do usuário
        WWWForm form = new WWWForm();
        form.AddField("username", UsernameInput.text);
        form.AddField("password", PasswordInput.text);
        form.AddField("email", EmailInput.text);
        form.AddField("phonenumber", PhoneNumberInput.text);
 
        // Requisição para o script PHP de registro
        using (UnityWebRequest request = UnityWebRequest.Post(registerURL, form))
        {
            yield return request.SendWebRequest();
 
            // Verifica se a requisição foi bem-sucedida
            if (request.result == UnityWebRequest.Result.Success)
            {
                // Analisar a resposta JSON
                Response response = JsonUtility.FromJson<Response>(request.downloadHandler.text);
 
                if (response.status == 200)
                {
                    Debug.Log("Registro bem-sucedido: " + response.message);
                    // Após o registro bem-sucedido, abrir a tela de login
                    OpenLoginScreen();
                }
                else
                {
                    Debug.LogError("Erro no registro: " + response.message);
                }
            }
            else
            {
                Debug.LogError("Erro na requisição: " + request.error);
            }
        }
    }
 
    void OpenLoginScreen()
    {
        SceneManager.LoadScene("Login");
    }
 
    [System.Serializable]
    public class Response
    {
        public int status;
        public string message;
    }
}