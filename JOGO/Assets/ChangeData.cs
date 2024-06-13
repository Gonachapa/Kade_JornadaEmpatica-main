using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
 
public class ChangeData : MonoBehaviour
{
    [System.Serializable]
    public class User
    {
        public string username;
        public string email;
        public string phonenumber;
    }
 
    [System.Serializable]
    public class Response
    {
        public int status;
        public Data data;
        public string message;
    }
 
    [System.Serializable]
    public class Data
    {
        public User user;
    }
 
    public string apiUrl = "http://localhost/db/PAPBackEnd/public/updateProfile.php";
 
    // Referências para os campos TextMeshPro
    public TMP_InputField userNameField;
    public TMP_InputField userEmailField;
    public TMP_InputField userPhoneNumberField;
    public TMP_InputField userNewPasswordField;
 
    public void StartUpdateProfile()
    {
        // Obter os valores dos campos TextMeshPro
        string userName = userNameField.text;
        string userEmail = userEmailField.text;
        string userPhoneNumber = userPhoneNumberField.text;
        string userNewPassword = userNewPasswordField.text;
 
        // Obter o token do PlayerPrefs antes de iniciar a coroutine
        string token = PlayerPrefs.GetString("jwtToken", null);
 
        if (string.IsNullOrEmpty(token))
        {
            Debug.LogError("Token is null or empty");
            return;
        }
 
        StartCoroutine(UpdateProfileCoroutine(userName, userEmail, userPhoneNumber, userNewPassword, token));
    }
 
    IEnumerator UpdateProfileCoroutine(string name, string email, string phonenumber, string newPassword, string token)
    {
        WWWForm form = new WWWForm();
        if (!string.IsNullOrEmpty(name)) form.AddField("nome", name);
        if (!string.IsNullOrEmpty(email)) form.AddField("email", email);
        if (!string.IsNullOrEmpty(phonenumber)) form.AddField("phonenumber", phonenumber);
        if (!string.IsNullOrEmpty(newPassword)) form.AddField("new_password", newPassword);
 
        UnityWebRequest www = UnityWebRequest.Post(apiUrl, form);
www.SetRequestHeader("Authorization", "Bearer " + token);
www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
 
        yield return www.SendWebRequest();
 
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Form upload complete!");
            string responseText = www.downloadHandler.text;
            Debug.Log("Response: " + responseText);
 
            Response response = JsonUtility.FromJson<Response>(responseText);
            if (response.status == 200)
            {
                Debug.Log("User profile updated successfully");
                Debug.Log("Username: " + response.data.user.username);
                Debug.Log("Email: " + response.data.user.email);
                Debug.Log("Phone number: " + response.data.user.phonenumber);
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Debug.LogError("Failed to update profile: " + response.message);
            }
        }
        else
        {
            Debug.LogError("Error: " + www.error);
            Debug.LogError("Response Code: " + www.responseCode);
            Debug.LogError("Response: " + www.downloadHandler.text);
        }
    }
}