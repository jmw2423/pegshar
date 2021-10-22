using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchcraft_peg : MonoBehaviour
{
    //  public Witch_Effect witchEffect;
    // Start is called before the first frame update
    public GameObject witchPeg;
    Vector3 temp;
    bool activated;
    void Start()
    {
        activated = false;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TEST");
        if (other.tag == "Player" || other.tag == "summonedPlayer")
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, 2f);
            //for each in array
            foreach (var hitCollider in hitColliders)
            {
                //check if it is regular peg
                if (hitCollider.gameObject.tag == "regularPeg")
                {
                    //if it is, updating score by value of regular peg and destroying regular peg
                    //somehow it doubles(score), so I made it 150 instead of 300
                   // Game_Manager.realScoreInGame += 150;
                    termination temp = (termination)hitCollider.GetComponent(typeof(termination));
                    temp.Activate();

                }

            }
            Game_Manager.AddScore(1000);
            StartCoroutine(getHit());
            //if (!activated)
            //{
            //    Debug.Log("BASED");
            //    //StartCoroutine(getHit());
            //    temp = transform.localScale;
            //    temp.x = 3.5f;
            //    temp.y = 3.5f;
            //    witchPeg.transform.localScale = temp;
            //    Game_Manager.realScoreInGame += 1000;
            //    activated = true;
            //}
        }
    }
   IEnumerator getHit()
   {
        witchPeg.GetComponent<SpriteRenderer>().color = new Color(0,1,0,1);
        yield return new WaitForSeconds(.15f);
        Destroy(witchPeg);
    }
}
