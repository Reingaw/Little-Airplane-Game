using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    bool comecouJogo, terminouJogo;
    Rigidbody2D corpoJogador;
    Vector2 forcaImpulso = new Vector2(0, 300f);
    int pontuacao;

    public GameObject peninhas;
    public Text textoScore;

    GameObject gameEngine;

    // Start is called before the first frame update
    void Start()
    {
        gameEngine = GameObject.FindGameObjectWithTag("MainCamera");
        corpoJogador = GetComponent<Rigidbody2D>();
        textoScore.transform.position = new Vector2(Screen.width / 2, Screen.height - 200);
        textoScore.text = "Toque para iniciar";
        textoScore.fontSize = 35;
    }

    // Update is called once per frame
    void Update()
    {
        if (!terminouJogo)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!comecouJogo)
                {
                    comecouJogo = true;
                    corpoJogador.isKinematic = false;

                    textoScore.text = pontuacao.ToString();
                    textoScore.fontSize = 35;

                    gameEngine.SendMessage("MyStart");
                }

                corpoJogador.velocity = new Vector2(0, 0);
                corpoJogador.AddForce(forcaImpulso);

                GameObject pena = Instantiate(peninhas);
                Vector3 posFelpudo = this.transform.position + new Vector3(0, 1, 0);
                pena.transform.position = posFelpudo;
            }

            float alturaFelpudoEmPixels = Camera.main.WorldToScreenPoint(transform.position).y;

            if (alturaFelpudoEmPixels > Screen.height || alturaFelpudoEmPixels < 0)
            {
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
                GetComponent<Rigidbody2D>().AddTorque(300f);

                GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.55f, 0.55f);
                FimDeJogo();
            }

            transform.rotation = Quaternion.Euler(0, 0, corpoJogador.velocity.y * 3);
        }
    }

    private void OnCollisionEnter2D()
    {
        if (!terminouJogo)
        {
            terminouJogo = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
            GetComponent<Rigidbody2D>().AddTorque(300f);

            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.55f, 0.55f);
            FimDeJogo();
        }
    }

    void MarcaPonto()
    {
        pontuacao++;
        textoScore.text = pontuacao.ToString();
    }

    void FimDeJogo()
    {
        gameEngine.SendMessage("End");
        Invoke("LoadScene", 2);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
