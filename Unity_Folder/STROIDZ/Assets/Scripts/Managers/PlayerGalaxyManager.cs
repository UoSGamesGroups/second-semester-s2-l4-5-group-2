using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGalaxyManager : MonoBehaviour {

    /// <summary>
    /// PlayerGalaxyManager.
    /// Created by: Daniel Pokladek.
    /// 
    /// This script is controlling the galaxy of the player.
    /// It contains information about the galaxy, such as the
    /// health it currently is at. It will switch the sprite,
    /// depending on its health.
    /// 
    /// </summary>

    [Header("Galaxy Variables")]
    public float galaxyHealth = 6f;
    public SpriteRenderer sprRenderer;
    public Sprite[] galaxySprites;

    void Start () {
        sprRenderer = GetComponent<SpriteRenderer>();
        UpdateHealth();
	}
	
	public void Damage (float _dmgAmnt) {
        galaxyHealth -= _dmgAmnt;
        UpdateHealth();
	}

    void UpdateHealth ( ) {
        if (galaxyHealth == 5)
            sprRenderer.sprite = galaxySprites[5];
        else if (galaxyHealth == 4)
            sprRenderer.sprite = galaxySprites[4];
        else if (galaxyHealth == 3)
            sprRenderer.sprite = galaxySprites[3];
        else if (galaxyHealth == 2)
            sprRenderer.sprite = galaxySprites[2];
        else if (galaxyHealth == 1)
            sprRenderer.sprite = galaxySprites[1];
        else if (galaxyHealth == 0)
            sprRenderer.sprite = galaxySprites[0];
    }
}
