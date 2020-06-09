using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    GameObject player;
    bool marcouPonto;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if(transform.position.x < player.transform.position.x)
            {
                if (!marcouPonto)
                {
                    marcouPonto = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 5.0f);
                    GetComponent<Rigidbody2D>().AddTorque(-50f);
                    GetComponent<Rigidbody2D>().isKinematic = false;
                    GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.55f, 0.55f);

                    player.SendMessage("MarcaPonto");
                }                
            }
        }
    }
}
