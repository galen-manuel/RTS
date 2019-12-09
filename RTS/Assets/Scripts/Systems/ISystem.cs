namespace COG.RTS.Systems
{
    public interface ISystem
    {
        void UpdateSystem(float pDeltaTime);
        void LateUpdateSystem(float pDeltaTime);
        void InitSystem();
        void StartSystem();
        void PauseSystem();
        void StopSystem();
        void ShutdownSystem();
    } 
}
