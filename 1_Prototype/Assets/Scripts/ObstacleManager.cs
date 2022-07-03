using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "boy")
        {
        
            SceneManager.LoadScene(6);
        }
       
    }


}
