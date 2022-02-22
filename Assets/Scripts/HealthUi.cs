using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUi : MonoBehaviour
{

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI points;
    public PointsManager pointsManager;
    public HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"Health: {healthManager.getCurrentHealth()}";

    }
}
