using System;

namespace MessageRoll
{
    class ConfigEvent
    {
        public void OnMessageSend(ConfigEventArgs e)
        {
            ConfigEventHander?.Invoke(this, e);
        }

        public event EventHandler<ConfigEventArgs> ConfigEventHander;
    }
}
