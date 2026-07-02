namespace Wwise_Implementation_Audio 
{
    public static class AudioManager
    {
        // Función centralizada para disparar eventos
        public static void TriggerEvent(string eventName, GameObject source)
        {
            AkSoundEngine.PostEvent(eventName, source);
        }

        // Función para manejar variables dinámicas (RTPCs)
        public static void SetGlobalParameter(string parameterName, float value)
        {
            AkSoundEngine.SetRTPCValue(parameterName, value);
        }
    }
}
