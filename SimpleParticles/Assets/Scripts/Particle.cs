using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles
{
    public abstract class Particle : MonoBehaviour
    {
        public abstract void Play();
        public abstract void Emit(int number);
        public abstract void EmitRandom(int left, int right);
        public abstract void Stop();
    }
}

