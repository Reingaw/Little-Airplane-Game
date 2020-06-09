using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{

    public GameObject inimigo;

    // Start is called before the first frame update
    void MyStart()
    {
        InvokeRepeating("CriaInimigo", 0.0f, 1.5f);
    }

    void End()
    {
        CancelInvoke("CriaInimigo");
    }

    void CriaInimigo()
    {
        float alturaAleatoria = 10.0f * Random.value - 5;
        GameObject novoInimigo = Instantiate(inimigo);
        novoInimigo.transform.position = new Vector2(15.0f, alturaAleatoria);
    }
}
