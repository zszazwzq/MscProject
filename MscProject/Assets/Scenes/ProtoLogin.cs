using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Assets.sence
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ProtoLogIn : ProtoMessage
    {
        /// <summary>
        /// The session salt, used to salt the password hash
        /// </summary>
        public byte[] sessionSalt { get; set; }
        /// <summary>
        /// The user's salt, used to salt the password hash
        /// </summary>
        public byte[] userSalt { get; set; }
        /// <summary>
        /// Key used in symmetric encryption. This key should be created on the client side and encrypted with the server's public key, then decrypted on the server side with the public key
        /// </summary>
        public byte[] Key { get; set; }
        /// <summary>
        /// Challenge text to be signed by server
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Result of server signing certificate
        /// </summary>
        public byte[] Signature { get; set; }
        /// <summary>
        /// Holds the X509 certificate as a byte array for optionally verifying the peer
        /// </summary>
        public byte[] certificate { get; set; }


    }
 
}
