using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Resourse : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private float maxTimer;
    [SerializeField] Slider sliderTimer;

    public float Hp;
    public float maxHp;
    public int humans;

    public int derevo;
    public int derevoMax;
    public int kamen;
    public int kamenMax;



    private string hpText;
    private string timerText;
    private string derevoText;
    private string kamenText;

    [SerializeField] GameObject hpTextObject;
    [SerializeField] GameObject timerTextObject;
    [SerializeField] GameObject derevoTextObject;
    [SerializeField] GameObject kamenTextObject;

    void Start()
    {
        maxHp = 100;
        Hp = maxHp;
        derevoMax = 10;
        kamenMax = 10;
        humans = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Hp > 0) { 
            Timer += Time.deltaTime;
            Hp = Hp - humans/100;
            sliderTimer.value = Hp / maxHp;

        }
        else
        {
            if (Timer > maxTimer) { maxTimer = Timer; }




        }


        
    }

    private void OnGUI()
    {
        hpText = Hp.ToString("0.0") + " / " + maxHp.ToString();
        hpTextObject.GetComponent<Text>().text = hpText;
        timerText = "Время текущего раунда: " + Timer.ToString("0.0");
        timerTextObject.GetComponent<Text>().text = timerText;
        derevoText = "Дерево: " + derevo.ToString() + " / " + derevoMax.ToString(); 
        derevoTextObject.GetComponent<Text>().text = derevoText;
        kamenText = "Дерево: " + kamen.ToString() + " / " + kamenMax.ToString(); 
        kamenTextObject.GetComponent<Text>().text = kamenText;



    }
}
