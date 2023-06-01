using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    //[SerializeField] AudioClip crashSFX;
    bool crashed = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !crashed)
        {
            crashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().Play();
            //GetComponent<AudioSource>().PlayOneShot(crashSFX, 1f);
            Invoke("ReloadCurrentScene", delay);
        }    
    }

   void ReloadCurrentScene()
   {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
   }

}
