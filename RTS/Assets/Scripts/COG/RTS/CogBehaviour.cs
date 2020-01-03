using UnityEngine;

namespace COG.RTS
{
    public abstract class CogBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Performs any needed initialization required.
        /// </summary>
        public virtual void Init()
        {

        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="pDeltaTime">The delta time of the frame.</param>
        public virtual void CustomUpdate(float pDeltaTime)
        {

        }

        /// <summary>
        /// Called right before the render loop.
        /// </summary>
        /// <param name="pDeltaTime">The delta time of the frame.</param>
        public virtual void CustomLateUpdate(float pDeltaTime)
        {

        }

        public virtual void Pause()
        {
            
        }

        public virtual void Resume()
        {
            
        }

        public virtual void Stop()
        {
            
        }

        /// <summary>
        /// Performs any clean up needed.
        /// </summary>
        public virtual void CleanUp()
        {

        }
    } 
}
