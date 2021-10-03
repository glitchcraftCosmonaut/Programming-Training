using UnityEngine;

public class TriggerEvents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "CylinderDestroyer")
        {
            Destroy(other.gameObject);
        } 
        if(other.gameObject.name == "PlayerDestroyer")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name == "Cube Border")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.name == "Cube Border Destroy")
        {
            Destroy(other.gameObject);
        }
    }
}
