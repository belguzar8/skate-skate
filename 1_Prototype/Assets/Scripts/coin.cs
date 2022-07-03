using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    //AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boy")
        {
           
            CoinText.coinAmount += 1;
            Destroy(gameObject);
           // audioSource.Play();
           
        }
    }

    
}
