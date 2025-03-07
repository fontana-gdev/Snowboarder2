using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay = 2f;
    [SerializeField] private ParticleSystem finishEffect;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Player.ToString()))
        {
            Debug.Log("The player crossed the finish line!");
            GetComponent<AudioSource>().Play();
            finishEffect.Play();
            Invoke(nameof(ReloadFirstScene), finishDelay);
        }
    }

    void ReloadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}
