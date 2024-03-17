using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    ManaManager manaManager;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        manaManager.currentMana = manaManager.maxMana;
    }

    // Update is called once per frame
    public void Update()
    {
        slider.value = manaManager.currentMana;
    }
}
