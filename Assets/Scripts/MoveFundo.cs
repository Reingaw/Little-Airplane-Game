using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFundo : MonoBehaviour
{
    float larguraTela, alturaTela, larguraImagem, alturaImagem;

    // Start is called before the first frame update
    void Start()
    {        
        SpriteRenderer grafico = GetComponent<SpriteRenderer>();

        larguraImagem = grafico.sprite.bounds.size.x;
        alturaImagem = grafico.sprite.bounds.size.y;

        alturaTela = Camera.main.orthographicSize * 2f;
        larguraTela = alturaTela / Screen.height * Screen.width;

        Vector2 novaScala = transform.localScale;
        novaScala.x = larguraTela / larguraImagem + 0.25f;
        novaScala.y = alturaTela / alturaImagem;
        this.transform.localScale = novaScala;

        if(this.name == "ImagemFundo B")
        {
            transform.position = new Vector2(larguraTela, 0f);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -larguraTela)
        {
            transform.position = new Vector2(larguraTela, 0f);
        }
    }
}
