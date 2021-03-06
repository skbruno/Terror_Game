using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_headbobing : MonoBehaviour
{
    public float walkingBobbingSpeed = 14f;
    [SerializeField, Range(0.1f, 0.5f)] public float bobbingAmount = 0.1f;
    public Player_Controller controller;

    float defaultPosY = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(controller.p_X) > 0.1f || Mathf.Abs(controller.p_Z) > 0.1f)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }

    }
}
