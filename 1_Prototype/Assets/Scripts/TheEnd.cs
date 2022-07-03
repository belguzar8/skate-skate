using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject partScreen;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boy")
        {
            endScreen.SetActive(true);
        }
    }

    public void partButton()
    {
        partScreen.SetActive(true);
    }

    public void firstButton()
    {
        SceneManager.LoadScene(1);
    }

    public void secondButton()
    {
        SceneManager.LoadScene(2);
    }

    public void thirdButton()
    {
        SceneManager.LoadScene(3);
    }

    public void fourthButton()
    {
        SceneManager.LoadScene(4);
    }
    public void fifthButton()
    {
        SceneManager.LoadScene(5);
    }

  



}
