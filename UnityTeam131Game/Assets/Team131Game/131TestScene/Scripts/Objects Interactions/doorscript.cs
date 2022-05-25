using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;

    private bool opened = false;
    private Animator anim;
    public PlayerController playerController;
    private float _timer;
    private bool _timerbool;

    void Update()
    {
        if (_timerbool == true)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _timer = 0;
                _timerbool = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
            Debug.Log("You Press E");
            _timerbool = true;

        }

        void Pressed()
        {

            RaycastHit doorhit;

            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
            {
                Debug.Log(doorhit.transform.gameObject.tag);
                if (doorhit.transform.gameObject.CompareTag("Door"))
                {
                    anim = doorhit.transform.gameObject.GetComponent<Animator>();
                    opened = !opened;
                    anim.SetBool("Opened", opened);

                }

            }
        }
    }
}
