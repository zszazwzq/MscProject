using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.sence
{
    class FiefControl
    {
        /*
        public ProtoGenericArray<ProtoFief> Check(Login l)
        {
            ProtoMessage checkMessage = new ProtoMessage();
            checkMessage.ActionType = Actions.ViewMyFiefs;
            l.Send(checkMessage);
            var reply = GetActionReply(Actions.ViewMyFiefs, l);
            var fiefs = (ProtoGenericArray<ProtoFief>)reply.Result;
            return fiefs;
        }
        
        public Task<ProtoMessage> GetActionReply(Actions action, Login l)
        {
            Task<ProtoMessage> responseTask = l.GetReply();
            responseTask.Wait();
            while (responseTask.Result.ActionType != action)
            {
                responseTask = l.GetReply();
                responseTask.Wait();
            }
            l.ClearMessageQueues();
            return responseTask;
        }
        */
    }

}
