using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Particles
{
    public class SparkParticel : Particle
    {
        [SerializeField] private ParticleSystem spark;

        /// <summary>
        /// ��������������Ч
        /// </summary>
        public override void Play()
        {
            spark.Play();
        }

        /// <summary>
        /// ͬʱ�������������Ч
        /// </summary>
        /// <param name="number">��������</param>
        public override void Emit(int number)
        {
            spark.Emit(number);
        }

        public override void EmitRandom(int left, int right)
        {
            if (left <= 0)
            {
                left = 1;
            }
            if (right <= 0)
            {
                right = 1;
            }
            if (left < right)
            {
                throw new ArgumentException("leftӦ��rightС");
            }
            spark.Emit(UnityEngine.Random.Range(left, right));
        }

        public override void Stop()
        {
            spark.Stop();
        }
    }
}