using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineLevel2 : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;

   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delay); 
        }
   }

   void ReloadScene()
   {
        SceneManager.LoadScene(0);
   }
}
