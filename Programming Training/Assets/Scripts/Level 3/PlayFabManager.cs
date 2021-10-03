using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public Image loginScreen;
    public InputField emailInput;
    public InputField passwordInput;
    public void RegisterButton()
    {
        if(passwordInput.text.Length < 6)
        {
            messageText.text = "passord to Short";
            return;
        }
        var request = new RegisterPlayFabUserRequest{
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "registered and logged in";
        loginScreen.gameObject.SetActive(false);
    }
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest{
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest{
            Email = emailInput.text,
            TitleId = "C5AB9"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest 
        {
            CustomId = SystemInfo.deviceUniqueIdentifier, 
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess,OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged IN";
        loginScreen.gameObject.SetActive(false);
        Debug.Log("Loging success");

    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "password reset email sent";
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("successful login/create account");
    }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
}
