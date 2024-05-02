using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 3f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var inputVertical = Input.GetAxis(Constant.INPUT_VERTICAL);
        var inputHorizontal = Input.GetAxis(Constant.INPUT_HORIZONTAL);
        transform.Translate(Vector3.forward * inputHorizontal * speed * Time.deltaTime + Vector3.left * inputVertical * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_GROUND))
        {
            return;
        }
        Destroy(other.gameObject);
        UIController.Instance.IncreaseTagNum(other.tag, 1);
    }
}
