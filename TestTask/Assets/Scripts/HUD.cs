using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text _speed;


    public void SpeedCounter()
    {
        
        _speed.text = GameController.Instance.Player.ReturnSpeed().ToString();
    }



}
