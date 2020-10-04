using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstBehaviourScript : MonoBehaviour
{
    //modifying variables in unity inspector doesn't change it in the code
    public int CharacterSpeed = 100;

    [SerializeField] //makes the private variable modifiable in unity inspector
    private float _CharacterHealth = 1.0f;

    [SerializeField]
    private bool _IsAlive = true;
    public Vector3 CharacterPosition = new Vector3(0f, 0f, 0f);
    
    private SpriteRenderer _SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _SpriteRenderer.color = Color.blue;
        // Debug.Log("Start!");

        if (_IsAlive == true) 
        {
            Debug.Log("Character is alive!");
        } 
        else 
        {
            Debug.Log("Character is dead!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update!");
    }

    // Awake Runs before the Object activates (meaning before start)
    private void Awake()
    {
        // Debug.Log("Awake!");
    }
    // FixedUpdate Runs each Physics Tick
    private void FixedUpdate()
    {
        // Debug.Log("FixedUpadate!");
    }
}
