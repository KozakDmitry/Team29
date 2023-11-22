using System.Collections;
using UnityEngine;

namespace Scripts.Infostructure
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}