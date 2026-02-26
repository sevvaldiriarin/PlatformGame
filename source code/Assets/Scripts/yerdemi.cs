using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerdemi : MonoBehaviour
{


    public LayerMask layer;
    public bool yerdemiyiz;
    public Rigidbody2D rb;
    public float speed = 8f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.basladiMi==false)
        {
            return;
        }
        RaycastHit2D ishitting=Physics2D.Raycast(transform.position, Vector2.down, 0.3f, layer);


        if(ishitting.collider !=null){
            yerdemiyiz=true;
        }
        else{
            yerdemiyiz=false;
        }

        //klavyeden tuşa basma işlemleri input, tuşa basılma işlemi kontrol ediliyorusa GetKeyDown
        if(yerdemiyiz==true && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity=new Vector2(rb.velocity.x,speed);
    }
   }



    






}
