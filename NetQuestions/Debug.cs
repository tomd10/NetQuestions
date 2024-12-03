using Microsoft.JSInterop;

namespace NetQuestions
{
    public static class Debug
    {
        public static void Log(IJSRuntime JS, string msg)
        {
            JS.InvokeVoidAsync("console.log", msg);
        }
    }
}
