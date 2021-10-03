using UnityEngine;

public class CollisionEvents : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name == "CylinderDestroyer Col")
        {
            Destroy(other.gameObject);
        } 
        if(other.gameObject.name == "PlayerDestroyer Col")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.name == "Cube Border Col")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.name == "Cube Border Destroy Col")
        {
            Destroy(other.gameObject);
        }
    }
}
