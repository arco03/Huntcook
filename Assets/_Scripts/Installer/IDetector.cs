using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Installer
{
    public interface IDetector
    {
        public void Interaction(Transform point, bool capture);
    }
}


