using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public ParticleSystem ExplosionParticles;
    public MeshRenderer renderer;

    Vector3 rotation;
    
    float scale = 0.0f;
    float health = 100.0f;
    bool dying = false;

	void Start () {
        float x = Random.Range(-3f, 3f);
        float z = Random.Range(-3f, 3f);
        transform.position = new Vector3(x, 30f, z);
        transform.localScale = Vector3.one * 0.01f;
        
        rotation = new Vector3(
            Random.Range(-50, 50),
            Random.Range(-50, 50),
            Random.Range(-50, 50)
        );
    }

    void Update () {
        if (dying)
        {
            scale -= 4f * Time.deltaTime;
            scale = Mathf.Clamp01(scale);
            transform.localScale = Vector3.one * scale;
            return;
        }
        if(scale < 1.0f)
        {
            scale += Time.deltaTime;
            scale = Mathf.Clamp01(scale);
            transform.localScale = Vector3.one * scale;
        }

        transform.position = transform.position + new Vector3(0f, -2f, 0f) * Time.deltaTime;
        transform.Rotate(rotation * Time.deltaTime);
        renderer.material.color = new Color((100f - health) * 0.1f, 0f, 0f);

        if(transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
	}

    private void OnParticleCollision(GameObject other)
    {
        if (dying) { return; }
            

        health -= 3f;
        if(health < 0f)
        {
            dying = true;
            ExplosionParticles.Play();
            Destroy(gameObject, ExplosionParticles.duration + ExplosionParticles.startLifetime);
        }
    }
}
