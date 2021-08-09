using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Replay();
        }
    }
}
