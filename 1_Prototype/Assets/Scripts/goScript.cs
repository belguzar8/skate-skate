using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goScript : MonoBehaviour
{
    public GameObject go;
    public void goButton()
    {
        
        SceneManager.LoadScene(1);
    }
}
