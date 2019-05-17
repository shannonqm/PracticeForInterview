using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    public float damp = 0.5f;//手指拖动时的阻尼

    private GameObject moveObject;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            moveObject = hit.collider.gameObject;
        }
        else
            return;
        //点下鼠标的时候发射一条射线，把获取的物体保存下来
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        moveObject = hit.collider.gameObject;
        //    }
        //    else
        //        return;
        //}
        if (Input.GetMouseButtonUp(0))
        {
            moveObject = null;
            //Debug.Log("MouseButtonUp");
        }
        if (moveObject != null)
        {
            Vector3 screenSpace = Camera.main.WorldToScreenPoint(moveObject.transform.position);//三维物体坐标转屏幕坐标
            //计算出一个物体到鼠标的一个偏移量
            Vector3 offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z)) - moveObject.transform.position;
            //物体加上这个偏移量，即是到鼠标的位置
            moveObject.transform.position = moveObject.transform.position + offset * damp;
        }
        //Debug.Log(moveObject);
    }

}
