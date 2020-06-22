using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    void OnCollisionEnter () {
        Debug.Log("You are dead.");        
    }

}
