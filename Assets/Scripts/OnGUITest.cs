using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnGUITest : MonoBehaviour
{
    /*private RawImage raw;

    [Header("Parameters")]
    public float timer;
    public float intervalTime = 1;
    public float speed = 1;

    private float uv_X;*/
    // Start is called before the first frame update
    public Dropdown dropdown;
    public float a;
    void Start()
    {
        dropdown = GetComponent<Dropdown>();

        dropdown.onValueChanged.AddListener(delegate{ Test(a); }); 
        /*raw = this.gameObject.GetComponent<RawImage>();
        raw.uvRect = new Rect(new Vector2(0.05f, 0.5f), new Vector2(0.19f, 0.5f));*/
    }
    void Test(float value)
    {
        switch(value)
        {
            case 0:
                dropdown.itemImage.color = Color.red;
                break;
            case 1:
                dropdown.itemImage.color = Color.yellow;
                break;
            case 2:
                dropdown.itemImage.color = Color.blue;
                break;
            case 3:
                dropdown.itemImage.color = Color.green;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        /*uv_X = raw.uvRect.x;
        timer += Time.deltaTime;
        if(timer >= intervalTime)
        {
            raw.uvRect = new Rect(new Vector2(raw.uvRect.x + 0.2f, raw.uvRect.y), new Vector2(raw.uvRect.width, raw.uvRect.height));
            timer = 0;
        }
        if(uv_X >= 0.8)
        {
            raw.uvRect = new Rect(new Vector2(0f, raw.uvRect.y + 0.5f), new Vector2(raw.uvRect.width, raw.uvRect.height));
            
        }*/
    }
 /*   private void OnGUI()    
    {
        if(GUI.Button(new Rect(50, 50, 50, 70), "Test"))
        {
            Debug.Log("Test");
        }

    }*/
}
