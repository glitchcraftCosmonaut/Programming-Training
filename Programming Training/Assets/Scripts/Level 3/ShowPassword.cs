using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{
    [SerializeField] private InputField userPassword;
 
    public void ShowUserPassword()
    {
        if (userPassword.contentType == InputField.ContentType.Password)
        {
            userPassword.contentType = InputField.ContentType.Standard;
        }
        else
        {
            userPassword.contentType = InputField.ContentType.Password;
        }
        userPassword.ForceLabelUpdate();
    }
}
