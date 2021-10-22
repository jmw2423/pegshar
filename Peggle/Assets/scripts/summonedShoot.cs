using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonedShoot : MonoBehaviour
{
    public GameObject summonedBall;
    public static List<GameObject> summonedBalls = Game_Manager.summonedBalls;
    public Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        coll.sharedMaterial.bounciness = 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        coll.sharedMaterial.bounciness -= 0.0002f;
        if (summonedBall.transform.position.y < -6)
        {
            Destroy(this.gameObject);
            coll.sharedMaterial.bounciness = 0.9f;
            summonedBalls.RemoveAt(summonedBalls.Count - 1);
        }
        if (Game_Manager.theurgyRounds > 0)
        {
            Game_Manager.theurgyRounds--;
        }
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


        this.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

        yield return new WaitForSeconds(4f);
        this.gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);




    }
}
