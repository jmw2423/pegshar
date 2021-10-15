using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class termination : MonoBehaviour
{
    
    public GameObject regularBall;
    public SpriteRenderer targetColor;
    public static List<GameObject> balls = Game_Manager.balls;
    Color myColor = new Color(1, 0, 0, 1);
    public Collider2D coll;
    public PhysicsMaterial2D phys;
    public PhysicsMaterial2D phys2;
    void Start()
    {
        targetColor = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        //sets startin bounciness
        coll.sharedMaterial.bounciness = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //realScore = Game_Manager.realScoreInGame;
        //destroying them and those only when the are no player's peg on screen(between shots)
        //and which color is red
        if (balls.Count == 0 && targetColor.color == myColor)
        {
           
            Destroy(regularBall);
        }
        //swappes physics. We want to have less bounce from hitted pegs
        if(targetColor.color == myColor)
        {
            this.coll.sharedMaterial = phys;
        }
        //swappes it back if not hit(after restart)
        if (targetColor.color != myColor)
        {
            this.coll.sharedMaterial = phys;
        }

    }
    //changes color of ball if it was hit by player peg
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && targetColor.color != myColor)
        {
            //+300 score if regular peg was hit
            Game_Manager.realScoreInGame += 300;
            targetColor.color = myColor;
            
            
        }
        
            
    }
}
