using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;
    public GameObject splashPrefab;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        AddSplash(collision);
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {

        }
        else if (materialName == "UnSafe (Instance)")
        {
            GameManager.gameOver = true;
            audioManager.Play("gameover");
        }
        else if(materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            GameManager.levelCompleted = true;
            audioManager.Play("winlevel");
        }

       
    }
    public void AddSplash(Collision collision)
    {
        GameObject newSplash;
        newSplash = Instantiate(splashPrefab);

        newSplash.transform.SetParent(collision.transform);
        newSplash.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.2f, this.transform.position.z);

        Destroy(newSplash, 2);
    }
}
