using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillManager : MonoBehaviour
{
    //Variables
    public static int kills = 0;
    public TextMeshProUGUI killText;
    // Start is called before the first frame update
    void Start()
    {
        //Getting componets
        killText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shows kills on player UI
        killText.text = "Kills: " + kills;
    }
}
