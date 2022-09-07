using System.ComponentModel;

namespace SC.App.Services.Area.Enums
{
    public enum EnumEnvironment
    {
        [Description("unknown")]
        Unknown,

        [Description("local")]
        Local,

        [Description("dev")]
        Dev,

        [Description("preview")]
        Preview,

        [Description("live")]
        Live
    }
}