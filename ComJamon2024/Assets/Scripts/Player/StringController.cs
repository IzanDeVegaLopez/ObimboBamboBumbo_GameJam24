using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthHandler healthHandler;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        healthHandler = GetComponentInParent<HealthHandler>();
        player = transform;
    }

    // Update is called once per frame
    public void CallUpdate()
    {
        UpdateStrings();
    }
    private void UpdateStrings()
    {

        for (int i = 0; i < healthHandler.maxHealth; i++)
        {
            if (healthHandler.currentHealth > i)
            {
                player.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                player.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
