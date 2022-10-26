using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed;
    private float maxY = 4.87f , minY = -2.93f;

    public Text ScoreTxt;
    public int Score;

    private float scoreInterval = 1f;
    private float nextScore = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = "Score: " + Score;

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if(transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x , minY ,0);
        }

        else if(transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x , maxY ,0);
        }

        if(Time.time >= nextScore)
        {
            nextScore = Time.time + scoreInterval;
            Score++;
        }
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
