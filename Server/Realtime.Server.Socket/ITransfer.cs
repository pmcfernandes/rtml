using System.Collections.Generic;

namespace Rtml.Server
{
    public interface ITransfer
    {
        byte[] Shake(HttpRequest request);

        void Receive(List<byte> data);
        
        byte[] Text(string text);
        
        byte[] Binary(byte[] bytes);
     
        byte[] Destroy();
    }
}
