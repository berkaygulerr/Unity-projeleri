using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusKontrol : MonoBehaviour {

    public Sprite[] kusSprite;
    SpriteRenderer spriterenderer;
    int kusSayac = 0;
    bool ileriGeri = true;

    float kusAnimasyonZaman;

    Rigidbody2D fizik;

    bool basla = false;

    
	
	void Start ()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();        
    }
	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            basla = true;
        }

        if (!basla)
        {
            fizik.gravityScale = 0;
            fizik.velocity = new Vector2(0, 0);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                fizik.gravityScale = 1;
                fizik.velocity = new Vector2(0, 0);
                fizik.AddForce(new Vector2(0, 200));
            }

            if (fizik.velocity.y > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 45);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, -45);
            }
            Animasyon();
        }

        
	}  
    
    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;

        if (kusAnimasyonZaman > 0.1f)
        {
            kusAnimasyonZaman = 0;

            if (ileriGeri)
            {
                spriterenderer.sprite = kusSprite[kusSayac];
                kusSayac++;

                if (kusSayac == kusSprite.Length)
                {
                    kusSayac--;
                    ileriGeri = false;
                }
            }
            else
            {
                kusSayac--;
                spriterenderer.sprite = kusSprite[kusSayac];

                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeri = true;
                }
            }
        }
    }
}
