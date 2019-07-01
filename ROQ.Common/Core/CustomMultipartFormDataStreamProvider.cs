using System.Net.Http;
using ROQ.Common.Helper;

namespace ROQ.Common.Core
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public string CustomFileName { get; set; }
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string random = new RandomString().GetRandomString();

            CustomFileName = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName)
                ? random + "_" + headers.ContentDisposition.FileName
                : random;

            CustomFileName = CustomFileName.Replace("\"", string.Empty);
            return CustomFileName; //this is here because Chrome submits files in quotation marks which get treated as part of the filename and get escaped
        }
    }
}
