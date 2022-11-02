using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationSpeed = 10;
    public GameObject bala;
    public GameObject balita;
    public GameObject ParticulasMuerte;
    public bool muerto=false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if(!muerto){
            float vertical = Input.GetAxis("Vertical");

            if (vertical > 0){
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("impulsing", true);
            }
            else {
            anim.SetBool("impulsing", false); 
            }
        

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal) * rotationSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Jump")) {
            GameObject temp = Instantiate(bala, balita.transform.position, transform.rotation);
            Destroy(temp, 1.5f);
        }
    }
    
    
    
    
    
    
    }
    

    public void Muerte()
    {
        GameObject temp = Instantiate(ParticulasMuerte, transform.position, transform.rotation);
        Destroy(temp,2.5f);
        gameManager.instance.vidas-=1;
        if(gameManager.instance.vidas <=0){
            Destroy(gameObject);
            Time.timeScale = 0;
        }
       else{
        StartCoroutine(Respawn_coroutine());
       }
    }
    IEnumerator Respawn_coroutine(){
        muerto =true;
        collider.enabled=false;
        sprite.enabled=false;
        yield return new WaitForSeconds(3); 
        collider.enabled = true;
        sprite.enabled = true;
        
        transform.position = new Vector3(0,0,0);
        rb.velocity = new Vector2(0,0);
        muerto=false;
    }
}
