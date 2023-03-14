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
        /// 触发单次粒子特效
        /// </summary>
        public override void Play()
        {
            spark.Play();
        }

        /// <summary>
        /// 同时触发多次粒子特效
        /// </summary>
        /// <param name="number">触发次数</param>
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
                throw new ArgumentException("left应比right小");
            }
            spark.Emit(UnityEngine.Random.Range(left, right));
        }

        public override void Stop()
        {
            spark.Stop();
        }
    }
}