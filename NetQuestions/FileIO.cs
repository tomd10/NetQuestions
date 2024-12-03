using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Text;

namespace NetQuestions
{
    public static class FileIO
    {
        public async static Task<string> Upload(IBrowserFile f)
        {
            if (f != null && f.Size > 0)
            {
                Stream s = f.OpenReadStream();
                StreamReader sr = new StreamReader(s);

                string ret = await sr.ReadToEndAsync();
                sr.Close();
                s.Close();

                return ret;
            }
            return null;
        }

        public static async void Download(IJSRuntime JS, string filename, string content)
        {
            MemoryStream fs = new MemoryStream(Encoding.UTF8.GetBytes(content));
            using var streamRef = new DotNetStreamReference(fs);

            await JS.InvokeVoidAsync("downloadFileFromStream", filename, streamRef);
        }
    }
}
