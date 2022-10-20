using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    private AudioClip checkpointSound;
    private Transform currentCheckpoint;// last checkpoint
    private Health playerHealth;
    private Scene currentScene;



    private void Awake()
    {
        playerHealth = GetComponent<Health>();
       
    }

    public void CheckRespawn()
    {
        //check if checpoint is avalible
        if (currentCheckpoint == null)
        {
            //show gameoversceen
            SceneManager.LoadScene("GamoverScense");
            return;
        }


        transform.position = currentCheckpoint.position;//move to checkpoint position;
        //restore
        playerHealth.Respawn();

        //move camera to checkpoint
        //Camera.main.GetComponent<CameraController>().
    }

    //activate checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CheckPoint")
        {
            SoundManager.instance.PlaySound(checkpointSound);
            currentCheckpoint = collision.transform;
            //SoundManager
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear") ;
        }
    }

}
