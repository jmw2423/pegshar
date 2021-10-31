using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonedShoot : MonoBehaviour
{
    public GameObject summonedBall;
    public static List<GameObject> summonedBalls = Game_Manager.summonedBalls;
    public Collider2D coll;
    private float stuckTime;
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        stuckTime = 0;
        coll = GetComponent<Collider2D>();
        coll.sharedMaterial.bounciness = 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        if (summonedBall.transform.position == lastPos)
        {
            stuckTime += Time.deltaTime;
        }
        else
        {
            stuckTime = 0;
        }

        if (stuckTime >= 1.5)
        {
            Destroy(this.gameObject);
            summonedBalls.RemoveAt(summonedBalls.Count - 1);
        }

        lastPos = summonedBall.transform.position;

        coll.sharedMaterial.bounciness -= 0.0002f;
        if (summonedBall.transform.position.y < -6)
        {
            Destroy(this.gameObject);
            summonedBalls.RemoveAt(summonedBalls.Count - 1);
            coll.sharedMaterial.bounciness = 0.9f;
        }
        //if (Game_Manager.theurgyMultiplier > 0)
        //{
        //    Game_Manager.theurgyMultiplier--;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "SorceryPeg")
        {
           
            StartCoroutine(Increase());
        }
    }

    private IEnumerator Increase()
    {


        this.gameObject.transform.localScale += new Vector3(0.032f, 0.032f, 0.032f);

        yield return new WaitForSeconds(4f);
        this.gameObject.transform.localScale -= new Vector3(0.032f, 0.032f, 0.032f);




    }
}
