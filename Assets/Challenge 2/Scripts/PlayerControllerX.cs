using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool isDisabled = false;
    private float timeToWait = 0.3f;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (!isDisabled && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(Debounced(timeToWait));
        }
    }

    private IEnumerator Debounced(float seconds)
    {
        // disable key press
        isDisabled = true;

        // wait for our amount of time to re-enable
        yield return new WaitForSeconds(seconds);

        isDisabled = false;
    }
}
