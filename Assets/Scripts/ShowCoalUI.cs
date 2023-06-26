using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCoalUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coalAmountText;
    [SerializeField] PressureLevel pressureLevel;
    // Start is called before the first frame update

    void Start()
    {
        coalAmountText = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void UpdateCoalInUI(int coal)
    {
        coalAmountText.text = coal.ToString();
        pressureLevel.SetPressureInInv(coal);
    }


}
