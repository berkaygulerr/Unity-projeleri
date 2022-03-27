using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour {

    bool bitti = true;

    public GameObject yerBir;
    public GameObject yerIki;

    float uzunluk;
    float degisimZaman = 0;

    int sayac = 0;

    public GameObject engel;
    public int kacAdetEngel = 5;
    GameObject[] engeller;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;
	void Start ()
    {
        fizikBir = yerBir.GetComponent<Rigidbody2D>();
        fizikIki = yerIki.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(-1, 0);
        fizikIki.velocity = new Vector2(-1, 0);

        uzunluk = yerBir.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[kacAdetEngel];

        for(int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(-1, 0);
        }
    }
	
	void Update ()
    {
        if (bitti)
        {
            if (yerBir.transform.position.x <= -uzunluk)
            {
                yerBir.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (yerIki.transform.position.x <= -uzunluk)
            {
                yerIki.transform.position += new Vector3(uzunluk * 2, 0);
            }

            degisimZaman += Time.deltaTime;

            if (degisimZaman > 1.3f)
            {
                degisimZaman = 0;
                float Yeksenim = Random.Range(0.70f, -0.90f);
                engeller[sayac].transform.position = new Vector3(16, Yeksenim);
                sayac++;

                if (sayac == engeller.Length)
                {
                    sayac = 0;
                }
            }
        }
    }
    public void oyunBitti()
    {
        for(int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikBir.velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
        }
        bitti = false;
    }

    public void reset()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
