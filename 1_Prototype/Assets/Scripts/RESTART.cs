using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESTART : MonoBehaviour
{
    public GameObject restart;
    

    public void restartButton()
    {
        SceneManager.LoadScene(0);
    }
}
