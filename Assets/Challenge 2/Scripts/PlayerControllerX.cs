using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spamCooldown = 3.0f;
    private float spamCooldownIter = 3.0f;
    private bool isSpam = false;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && spamCooldownIter == spamCooldown)
        {
            isSpam = true;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
        if (isSpam == true)
        {
            SpamCooldown();
        }
    }

    void SpamCooldown()
    {
        if (spamCooldownIter < 0)
        {
            isSpam = false;
            spamCooldownIter = spamCooldown;
        }
        else
        {
            spamCooldownIter -= Time.deltaTime * spamCooldown;
        }
    }
}
