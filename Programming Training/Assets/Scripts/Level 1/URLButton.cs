using UnityEngine;

public class URLButton : MonoBehaviour
{
    public void OpenUrl()
    {
        Application.OpenURL("https://github.com/glitchcraftCosmonaut?tab=repositories");
        Debug.Log("URl opened");
    }
}
