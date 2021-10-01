using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualButton : MonoBehaviour
{
    private Button myButton;
    public GameObject myBox;
    public bool clicks = false;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(delegate{
            clicks = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        ButtonClicked();
    }
    public void ButtonClicked()
    {
        // if(clicks == 2)
        // {
        //     Destroy(myBox);
        // }
    }
    private void OnDestroy() 
    {
        myButton.onClick.RemoveAllListeners();    
    }
}
