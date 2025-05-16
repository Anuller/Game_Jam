using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

     

    public class Shooting : MonoBehaviour
    {
        private Camera mainCam;
        private Vector3 mousePos;

        public GameObject lanterna;
    [SerializeField]
        private bool lantermaOn;
        // Start is called before the first frame update
       
    void Start()
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
        

    void Update()
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotz);


            /*if (Input.GetKeyDown(KeyCode.E) && lantermaOn == false)
            {
            print("Ativo");
                lanterna.SetActive(true);
            lantermaOn = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && lantermaOn == true)
            {
            print("Desativo");
                lanterna.SetActive(false);
            lantermaOn=false;
            }*/
        }
    }
