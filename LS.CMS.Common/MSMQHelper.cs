using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;


namespace LS.CMS.Common
{
    /// <summary>
    /// MSMQ队列帮助类
    /// </summary>
    public class MSMQHelper
    {
        private readonly string _path;
        private MessageQueue _msmq;
        public MSMQHelper()
        {
            _path = @".\private$\log";
            if (!MessageQueue.Exists(_path))
            {
                MessageQueue.Create(_path);
            }
            _msmq = new MessageQueue(_path);
        }

        /// <summary>
        /// 发送消息队列
        /// </summary>
        /// <param name="msmqIndex">消息队列实体</param>
        /// <returns></returns>
        public void Send(object msmqIndex)
        {
            _msmq.Send(new Message(msmqIndex, new BinaryMessageFormatter()));
        }

        /// <summary>
        /// 接收消息队列,删除队列
        /// </summary>
        /// <returns></returns>
        public object ReceiveAndRemove()
        {
            object msmqIndex = null;
            _msmq.Formatter = new BinaryMessageFormatter();
            Message msg = null;
            try
            {
                msg = _msmq.Receive(new TimeSpan(0, 0, 1));
            }
            catch (Exception ex)
            {
                LogHelper.SaveException(ex);
            }
            if (msg != null)
            {
                msmqIndex = msg.Body;
            }
            return msmqIndex;
        }
        /// <summary>
        /// 获取队列中的所有信息
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllMessage()
        {
            Message[] allMessage = _msmq.GetAllMessages();
            BinaryMessageFormatter formatter = new BinaryMessageFormatter();
            List<string> list = new List<string>();
            for (int i = 0; i < allMessage.Length; i++)
            {
                allMessage[i].Formatter = formatter;
                list.Add(allMessage[i].Body.ToString());
            }
            return list;
        }
        /// <summary>
        /// 关闭消息管道
        /// </summary>
        public void Clear()
        {
            _msmq.Purge();
        }
        /// <summary>
        /// 释放消息队列实例
        /// </summary>
        public void Dispose()
        {
            if (_msmq != null)
            {
                _msmq.Close();
                _msmq.Dispose();
                _msmq = null;
            }
        }
    }
}
