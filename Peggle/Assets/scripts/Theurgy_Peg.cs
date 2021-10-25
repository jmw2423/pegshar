using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theurgy_Peg : MonoBehaviour
{
    public Collider2D coll;
    public PhysicsMaterial2D phys;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        //sets startin bounciness
        //coll.sharedMaterial.bounciness = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "summonedPlayer")
        {
            StartCoroutine(Theurgy());
        }

    }
    IEnumerator Theurgy()
    {
        //coll.sharedMaterial.bounciness = 0.9f;
        Game_Manager.theurgyMultiplier += 2;
        Game_Manager.AddScore(0);
        tutorialGameManager.tutorialTheurgyMultiplier += 3;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
