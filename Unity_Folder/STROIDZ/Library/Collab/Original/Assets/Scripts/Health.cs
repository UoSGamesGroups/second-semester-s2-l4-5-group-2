using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Health : MonoBehaviour
{
    public int PlayerHealth;

    private SpriteRenderer sr;
    public Sprite Planet5;
    public Sprite Planet4;
    public Sprite Planet3;
    public Sprite Planet2;
    public Sprite Planet1;
    public Sprite Planet0;

    public Canvas Congratulations;
    public Canvas NextRound;

    void Start()
    {
        PlayerHealth = 5;

        Congratulations = Congratulations.GetComponent<Canvas>();
        NextRound = NextRound.GetComponent<Canvas>();

        NextRound.enabled = false;
        Congratulations.enabled = false;

        sr = GetComponent<SpriteRenderer>();
    }

    public void UpdateHealth(int Number)
    {
        if (Number == 5)
        {

            sr.sprite = Planet5;
        }

        if (Number == 4)
        {

            sr.sprite = Planet4;
        }

        if (Number == 3)
        {
            sr.sprite = Planet3;
        }


        if (Number == 2)
        {
            sr.sprite = Planet2;
        }


        if (Number == 1)
        {
            sr.sprite = Planet1;
        }

        if (Number == 0)
        {
            sr.sprite = Planet1;
            Congratulations.enabled = true;
            sr.sprite = Planet1;
            PlayerDead();
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ASTEROID")
        {
            Destroy(col.gameObject);
            PlayerHealth = PlayerHealth - 1;
            UpdateHealth(PlayerHealth);
        }
    }

    void PlayerDead()
    {
        Congratulations.enabled = true;
        StartCoroutine("GameFinished");
    }

    IEnumerator GameFinished()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0;
        Congratulations.enabled = false;
        NextRound.enabled = true;
    }
}