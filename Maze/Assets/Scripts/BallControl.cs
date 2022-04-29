using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody rb;
    public UnityEngine.UI.Text time, health,gameCheckControl;
    float timer = 20;
    int healthCounter = 5;
    public float hiz = 1.8f;
    bool gameCheck = true;
    bool completed = false;
    public UnityEngine.UI.Button button;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCheck && !completed){
              timer -= Time.deltaTime; 
              time.text = (int)timer + "";
        }
        else if(!completed){
            gameCheckControl.text = "GAME OVER";
            button.gameObject.SetActive(true);
            
        }
      
        if(timer < 0){
            gameCheck = false;
        }
        
    }
    void FixedUpdate(){
        if(gameCheck && !completed){
           float horizontal = Input.GetAxis("Horizontal");
           float vertical = Input.GetAxis("Vertical");
           Vector3 force = new Vector3(-vertical,0,horizontal);
           rb.AddForce(force*hiz);
        }
        else{
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    

    }
    void OnCollisionEnter(Collision cls){
        string objectName = cls.gameObject.name;
        if(objectName.Equals("Finish")){
            completed = true;
            gameCheckControl.text = "WELL DONE";
              button.gameObject.SetActive(true);

        }
        else if(!objectName.Equals("Plane") && !objectName.Equals("Maze Plane") )
           healthCounter -= 1;
           health.text = healthCounter + "";
           if(healthCounter == 0){
               gameCheck = false;

           }

    }
}
