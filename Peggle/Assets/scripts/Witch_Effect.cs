using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    bool active;
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(active)
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
        }
            
            
    }
    void setActive(bool active)
    {
        this.active = active;
    }
}
