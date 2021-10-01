using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualButton2 : MonoBehaviour
{
    private Button myButton2;
    public GameObject myBox;
    public bool clicks = false;
    // Start is called before the first frame update
    void Start()
    {
        myButton2 = GetComponent<Button>();
        myButton2.onClick.AddListener(delegate{
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
        // if(clicks == 1)
        // {
        //     myBox.gameObject.SetActive(false);
        // }
    }
    private void OnDestroy() 
    {
        myButton2.onClick.RemoveAllListeners();
    }
}
