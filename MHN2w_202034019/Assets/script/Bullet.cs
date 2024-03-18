using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedBox"))
        {          
            this.gameObject.SetActive(false);
        }
    }
}
