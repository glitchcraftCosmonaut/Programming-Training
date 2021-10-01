using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBox : MonoBehaviour
{
    public DualButton2 dualButton2;
    public DualButton dualButton;
    public SingleButton singleButton;
    // Start is called before the first frame update
    void Start()
    {
        // dualButton = GetComponent<DualButton>();
        // dualButton2 = GetComponent<DualButton2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dualButton.clicks == true && dualButton2.clicks == true)
        {
            gameObject.SetActive(false);
            dualButton2.clicks = false;
            dualButton.clicks = false;
        }
        
    }
}
