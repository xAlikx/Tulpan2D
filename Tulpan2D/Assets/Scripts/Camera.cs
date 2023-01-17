using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Ancor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Ancor.transform.position.x,Ancor.transform.position.y);
    }
}
