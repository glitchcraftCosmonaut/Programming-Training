using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject soundOnIcon;
    public TextMeshProUGUI onText;
    [SerializeField] Slider volumeSlider;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }
    private void Update() 
    {
        UpdateButtonIcon();
    }
    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
    }
    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            onText.text = " Sound ON";
        }
        else
        {
            onText.text = "Sound Off";
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
