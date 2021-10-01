using UnityEngine;
using UnityEngine.UI;

public class SingleButton : MonoBehaviour
{
    public GameObject myBox;

    public void OnButtonClick()
    {
        if(myBox.activeInHierarchy == true)
        {
            myBox.SetActive(false);
        }
        else
        {
            myBox.SetActive(true);
        }
    }
}
