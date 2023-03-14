using Particles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Particle))]
public class ParticlePlayer : MonoBehaviour
{
    private Particle particle;

    [SerializeField] private int intervalTime;      //º‰∏Ù ±º‰
    private float counter;
    [SerializeField] private bool playOnAwake;

    void Start()
    {
        counter = intervalTime;
        if (playOnAwake)
            counter = 0;
        particle = GetComponent<Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter < 0)
        {
            counter = intervalTime;
            particle.Play();
        }
    }
}
