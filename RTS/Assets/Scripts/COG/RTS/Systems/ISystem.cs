namespace COG.RTS.Systems
{
    public interface ISystem
    {
        void InitSystem();
        void StartSystem();
        void UpdateSystem(float pDeltaTime);
        void LateUpdateSystem(float pDeltaTime);
        void PauseSystem();
        void ResumeSystem();
        void StopSystem();
        void ShutdownSystem();
    } 
}
