using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public float movespeed;
    float Xinput;
    float Yinput;
    Rigidbody rb;   
    int CoinCollector;
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Xinput = Input.GetAxis("Horizontal");
        Yinput = Input.GetAxis("Vertical");

        if(transform.position.y <= -5f){
            SceneManager.LoadScene(0);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(Xinput *movespeed,0,Yinput*movespeed);
    }
private void OnTriggerEnter(Collider other){
    if(other.tag == "coin"){
        CoinCollector++;
        other.gameObject.SetActive(false);
    }
    if(CoinCollector>=7)
    {
        winText.SetActive(true);
    }
}


}
