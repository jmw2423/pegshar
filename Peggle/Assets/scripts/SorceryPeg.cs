using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorceryPeg : MonoBehaviour
{
    public GameObject ball;
    private bool large;
    public static List<GameObject> balls = Game_Manager.balls;
    // Start is called before the first frame update
    void Start()
    {
        ball.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "summonedPlayer")
        {
            Game_Manager.AddScore(500);
            tutorialGameManager.AddScore(500);
            StartCoroutine(Destroy());
        }
    }
   IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
 
}
