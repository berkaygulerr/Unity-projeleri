using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kontrol : MonoBehaviour {

    bool basla = false, bitti = true;

    OyunKontrol oyunfizik;

    bool dusme = true;
    public Sprite[] kusSprite;
    SpriteRenderer spriteRenderer;
    bool kusİleriGeri = true;
    int kusSayac = 0;
    float kusAnimasyonZaman;

    Rigidbody2D fizik;

    public Text puanText;

    float zaman;

    int puan = 0;
	
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunfizik = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<OyunKontrol>();
	}
	
	
	void Update ()
    {
        if (basla)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.position.y < -0.3 && dusme)
            {
                basla = true;
                fizik.velocity = new Vector2(0, 0);
                fizik.AddForce(new Vector2(0, 130));
            }
        }

        if (fizik.velocity.y >= 0)
        {
            if(zaman < 20)
            {
                if (fizik.velocity.y <= -3)
                {
                    zaman += 30;
                }
                else
                {
                    zaman += 15;
                }
                transform.eulerAngles = new Vector3(0, 0, zaman);
            }
        }
        else
        {
            if(zaman > -90 && fizik.velocity.y < -1.5f)
            {
                if(fizik.velocity.y <= -5)
                {
                    zaman -= 15;
                }
                else
                {
                    zaman -= 6;
                }
                transform.eulerAngles = new Vector3(0, 0, zaman);
            }
        }

        Animasyon();        
	}

    void Animasyon()
    {
        if (bitti)
        {
            kusAnimasyonZaman += Time.deltaTime;

            if (kusAnimasyonZaman > 0.1f)
            {
                kusAnimasyonZaman = 0;

                if (kusİleriGeri)
                {
                    spriteRenderer.sprite = kusSprite[kusSayac];
                    kusSayac++;

                    if (kusSayac == kusSprite.Length)
                    {
                        kusSayac--;
                        kusİleriGeri = false;
                    }
                }
                else
                {
                    kusSayac--;
                    spriteRenderer.sprite = kusSprite[kusSayac];

                    if (kusSayac == 0)
                    {
                        kusSayac++;
                        kusİleriGeri = true;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "puan")
        {
            puan++;
            puanText.text = "" + puan;
        }

        if(col.gameObject.tag == "engel")
        {
            bitti = false;
            dusme = false;
            oyunfizik.oyunBitti();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "engel")
        {
            bitti = false;
            dusme = false;
            oyunfizik.oyunBitti();
        }
    }
}
