using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapChatServer.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ns;
        public PacketBuilder()
        {
            _ns = new MemoryStream();
        }

        public void WriteOpCode(byte opcode)
        {
            _ns.WriteByte(opcode);
        }

        public void WriteMessage(string msg)
        {
            var msgLength = msg.Length;
            _ns.Write(BitConverter.GetBytes(msgLength));
            _ns.Write(Encoding.ASCII.GetBytes(msg));
        }

        public byte[] GetPacketBytes()
        {
            return _ns.ToArray();
        }
    }
}
