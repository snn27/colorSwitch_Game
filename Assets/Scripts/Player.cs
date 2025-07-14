using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;

    //çeşitli fonk. erişmek için
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    //renkerler
    public Color colorBlue;
    public Color colorYellow;
    public Color colorRed;
    public Color colorPurple;

    [SerializeField]
    private int WhatLevel;

    private void Start()
    {
        SetRandomColor();
        Time.timeScale = 0f;//başlangıçta top yere yapışmasın diye
        WhatLevel = SceneManager.GetActiveScene().buildIndex; 
    }
    void Update()
    {
        {
            if (Input.GetMouseButtonUp(0) || Input.GetButtonDown("Jump"))
            {
                Time.timeScale = 1f; //oyun başlıyor
                rb.velocity = Vector2.up * jumpForce;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChange")
        {
            SetRandomColor();
            Debug.Log("renk değiştirildi!");
            Destroy(collision.gameObject);//renk değiştikten sonra çismi yok et
            return;
        }
        else if (collision.tag != currentColor)
        {
            again();

        }
        if(collision.tag == "LavelChange")//diğer levele geçiş
        {
            WhatLevel += 1;
            SceneManager.LoadScene(WhatLevel);
            Debug.Log("başarılar");

        }


    }

    private void SetRandomColor() //top renginin belirlenmesi
    {
        int index = Random.Range(0,4);
        switch (index)
        {

            case 0:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Red";
                sr.color = colorRed;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;

        }

    }
    public void again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
