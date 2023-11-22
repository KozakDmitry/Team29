using System.Collections;
using UnityEngine;

namespace Infostructure
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}