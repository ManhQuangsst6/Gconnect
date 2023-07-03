using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
//using System.Web.Http.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gconnect.API.Filters;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiCompressFilter : ActionFilterAttribute
{
    //public override void OnActionExecuted(ActionExecutedContext context)
    //{
    /*
    var acceptedEncoding = context.HttpContext.Response.RequestMessage.Headers.AcceptEncoding.First().Value;
    if (!acceptedEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase)
    && !acceptedEncoding.Equals("deflate", StringComparison.InvariantCultureIgnoreCase))
    {
        return;
    }
    context.Response.Content = new CompressedContent(context.Response.Content, acceptedEncoding);
    */
    //}
    private Stream _originStream = null;
    private MemoryStream _ms = null;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        HttpRequest request = context.HttpContext.Request;
        string acceptEncoding = request.Headers["Accept-Encoding"];
        if (string.IsNullOrEmpty(acceptEncoding)) return;
        acceptEncoding = acceptEncoding.ToUpperInvariant();
        HttpResponse response = context.HttpContext.Response;
        if (acceptEncoding.Contains("BR", StringComparison.OrdinalIgnoreCase))//Brotli 
        {
            if (!(response.Body is BrotliStream))// avoid twice compression.
            {
                _originStream = response.Body;
                _ms = new MemoryStream();
                response.Headers.Add("Content-encoding", "br");
                response.Body = new BrotliStream(_ms, CompressionLevel.Optimal);
            }
        }
        else if (acceptEncoding.Contains("GZIP", StringComparison.OrdinalIgnoreCase))
        {
            if (!(response.Body is GZipStream))
            {
                _originStream = response.Body;
                _ms = new MemoryStream();
                response.Headers.Add("Content-Encoding", "gzip");
                response.Body = new GZipStream(_ms, CompressionLevel.Optimal);
            }
        }
        else if (acceptEncoding.Contains("DEFLATE", StringComparison.OrdinalIgnoreCase))
        {
            if (!(response.Body is DeflateStream))
            {
                _originStream = response.Body;
                _ms = new MemoryStream();
                response.Headers.Add("Content-encoding", "deflate");
                response.Body = new DeflateStream(_ms, CompressionLevel.Optimal);
            }
        }
        base.OnActionExecuting(context);
    }

    public override async void OnResultExecuted(ResultExecutedContext context)
    {
        if ((_originStream != null) && (_ms != null))
        {
            HttpResponse response = context.HttpContext.Response;
            try
            {
                await response.Body.FlushAsync();
                _ms.Seek(0, SeekOrigin.Begin);
                response.Headers.ContentLength = _ms.Length;
                await _ms.CopyToAsync(_originStream);
                response.Body.Dispose();
                _ms.Dispose();
                response.Body = _originStream;
            }
            catch (Exception ex) { }
        }
        base.OnResultExecuted(context);
    }
}