namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class RenderCapability : Proxy<global::Windows.UI.Xaml.Media.RenderCapability>
    {
        public static System.Int32 Tier
        {
            get => __ProxyValue.Tier;
        }

        public static System.Boolean IsShaderEffectSoftwareRenderingSupported
        {
            get => __ProxyValue.IsShaderEffectSoftwareRenderingSupported;
        }

        public static System.Windows.Size MaxHardwareTextureSize
        {
            get => __ProxyValue.MaxHardwareTextureSize;
        }

        public static System.Boolean IsPixelShaderVersionSupported(System.Int16 majorVersionRequested, System.Int16 minorVersionRequested) => Windows.UI.Xaml.Media.RenderCapability.IsPixelShaderVersionSupported(@majorVersionRequested, @minorVersionRequested);
        public static System.Boolean IsPixelShaderVersionSupportedInSoftware(System.Int16 majorVersionRequested, System.Int16 minorVersionRequested) => Windows.UI.Xaml.Media.RenderCapability.IsPixelShaderVersionSupportedInSoftware(@majorVersionRequested, @minorVersionRequested);
        public static System.Int32 MaxPixelShaderInstructionSlots(System.Int16 majorVersionRequested, System.Int16 minorVersionRequested) => Windows.UI.Xaml.Media.RenderCapability.MaxPixelShaderInstructionSlots(@majorVersionRequested, @minorVersionRequested);
        public static void add_TierChanged(System.EventHandler value) => Windows.UI.Xaml.Media.RenderCapability.add_TierChanged(@value);
        public static void remove_TierChanged(System.EventHandler value) => Windows.UI.Xaml.Media.RenderCapability.remove_TierChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}