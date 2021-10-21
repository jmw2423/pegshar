using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theurgy_Peg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Theurgy());
        }

    }
    IEnumerator Theurgy()
    {
        Game_Manager.theurgyRounds += 3;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
