using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed=10f;
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text panelScoreText;

    [SerializeField]
    GameObject LauncherPanel;
    
    public Animator anim;
    bool isrunning=false;
    
    public static int score=0;

    public static bool basladiMi=false;

    [SerializeField]
    GameObject TryAgainPanel;
    [SerializeField]
    AudioSource coinsound;

    private void Awake() {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }
    private void OnEnable() {
        if(PlayerPrefs.HasKey("Coins")){
            score=PlayerPrefs.GetInt("Coins");
        }
    }
    void Start()
    {
               
        scoreText.text=score.ToString();
        if(GameManager.isrestart==true){
            LauncherPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(basladiMi==false){
            return;
        }
        float horizontal=Input.GetAxis("Horizontal");
        //yürüme
        move(horizontal);
        //animasyon
        animasyon(horizontal);
        //yön verme
        turnmove(horizontal);

    }

    void move(float horizontal){
        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);
    }
    void animasyon(float horizontal){
        if(horizontal!=0){
            isrunning=true;
        }
        else
        {
            isrunning=false;
        }

        anim.SetBool("isrunning",isrunning);

    }
    void turnmove(float horizontal){
        if(horizontal>0){
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(horizontal<0){
            transform.localScale = new Vector3(-1f,1f,1f);    
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin")){
            coinsound.Play();
            ScoreCounter(collision,1);
        }
        else if(collision.CompareTag("Enemy")){
            Death();
        }
        else if(collision.CompareTag("Star")){
            coinsound.Play();
            ScoreCounter(collision,5);
        }
        else if(collision.CompareTag("Door")){
            //string level=SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            

        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Death")){
            Death();
        }
    }
    
    void ScoreCounter(Collider2D collision,int value){
        score+=value;
        Destroy(collision.gameObject);
        scoreText.text=score.ToString();

    }
    void Death(){
        //transform.position = new Vector3(transform.position.x-0.8f,transform.position.y,transform.position.z);
        //transform.Rotate(new Vector3(0,0,90));
        Destroy(this.gameObject,1f);
        TryAgainPanel.SetActive(true);
        panelScoreText.text="Score: "+score.ToString();
        score=0;
    }

    public void oyunabasla()
    {
        basladiMi=true;
        LauncherPanel.SetActive(false);
    }
    private void OnDestroy() {
        SavePrefs();
    }
    void SavePrefs()
    {
        PlayerPrefs.SetInt("Coins",score);
        PlayerPrefs.Save();
    }
    public void startagain(){
        SceneManager.LoadScene("level1");
        score=0;
    }
}
