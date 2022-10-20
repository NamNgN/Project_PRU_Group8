using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private Image totalHealthBar;
    [SerializeField]
    private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currenHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currenHealth / 10;

    }
}
