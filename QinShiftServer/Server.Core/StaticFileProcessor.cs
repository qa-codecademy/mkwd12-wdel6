using ServerTwo.Interface;

using System.Linq;
using System.Reflection;

namespace ServerTwo.Core
{
    internal class StaticFileProcessor : IPipelineProcessor
    {
        public string Folder { get; init; }
        public StaticFileProcessor(string folder)
        {
            if (!Path.IsPathFullyQualified(folder))
            {
                folder = Path.Combine(Environment.CurrentDirectory, folder);
            }
            Folder = folder;
            if (!Directory.Exists(folder))
            {
                throw new ArgumentException($"Folder {folder} does not exist", nameof(folder));
            }
        }

        public bool CanProcess(Request request)
        {
            var (valid, fullPath) = GetLocalFileName(request);
            if (!valid)
            {
                return false;
            }
            return File.Exists(fullPath);
        }

        private (bool Valid, string FileName) GetLocalFileName(Request request)
        {
            if (request.Method != Interface.HttpMethod.Get)
            {
                return (false, string.Empty);
            }
            var pathParts = request.Path.Split("/");
            if (pathParts.Any(part => part.Contains("..")))
            {
                return (false, string.Empty);
            }
            var lastPart = pathParts.Last();
            if (string.IsNullOrEmpty(lastPart))
            {
                lastPart = "index.html";
            }
            var others = pathParts.Take(pathParts.Length - 1);
            var fullRelativePath = Path.Combine(others.Append(lastPart).ToArray());
            var fullPath = Path.Combine(Folder, fullRelativePath);
            return (true, fullPath);
        }

        public BaseResponse Process(Request request)
        {
            var (_, fullPath) = GetLocalFileName(request);

            var extension = Path.GetExtension(fullPath);

            if (extension == ".ico")
            {
                var contents = File.ReadAllBytes(fullPath);
                return new BinaryResponse
                {
                    StatusCode = StatusCode.OK,
                    Body = contents,
                    Headers = new Headers
                    {
                        { "Content-Type", "image/x-icon" }
                    }
                };
            }
            if (extension == ".png")
            {
                var contents = File.ReadAllBytes(fullPath);
                return new BinaryResponse
                {
                    StatusCode = StatusCode.OK,
                    Body = contents,
                    Headers = new Headers
                    {
                        { "Content-Type", "image/png" }
                    }
                };
            }
            if (extension == ".html")
            {
                var contents = File.ReadAllText(fullPath);
                return new Response
                {
                    StatusCode = StatusCode.OK,
                    Body = contents,
                    Headers = new Headers
                    {
                        { "Content-Type", "text/html" }
                    }
                };
            }

            return InvalidResponse.InvalidRequest("Invalid file type");
        }
    }
}