﻿using System.Linq;
using System.Collections;
using System.Text;
using RabbitMQ.Client;

namespace EasyNetQ
{
    public class MessageProperties
    {
        public MessageProperties()
        {
            Headers = new Hashtable();
        }

        public MessageProperties(IBasicProperties basicProperties)
            : this()
        {
            CopyFrom(basicProperties);
        }

        public void CopyFrom(IBasicProperties basicProperties)
        {
            Preconditions.CheckNotNull(basicProperties, "basicProperties");

            if (basicProperties.IsContentTypePresent())         ContentType         = basicProperties.ContentType;
            if (basicProperties.IsContentEncodingPresent())     ContentEncoding     = basicProperties.ContentEncoding;
            if (basicProperties.IsDeliveryModePresent())        DeliveryMode        = basicProperties.DeliveryMode;
            if (basicProperties.IsPriorityPresent())            Priority            = basicProperties.Priority;
            if (basicProperties.IsCorrelationIdPresent())       CorrelationId       = basicProperties.CorrelationId;
            if (basicProperties.IsReplyToPresent())             ReplyTo             = basicProperties.ReplyTo;
            if (basicProperties.IsExpirationPresent())          Expiration          = basicProperties.Expiration;
            if (basicProperties.IsMessageIdPresent())           MessageId           = basicProperties.MessageId;
            if (basicProperties.IsTimestampPresent())           Timestamp           = basicProperties.Timestamp.UnixTime;
            if (basicProperties.IsTypePresent())                Type                = basicProperties.Type;
            if (basicProperties.IsUserIdPresent())              UserId              = basicProperties.UserId;
            if (basicProperties.IsAppIdPresent())               AppId               = basicProperties.AppId;
            if (basicProperties.IsClusterIdPresent())           ClusterId           = basicProperties.ClusterId;

            if (basicProperties.IsHeadersPresent())
            {
                foreach (DictionaryEntry header in basicProperties.Headers)
                {
                    Headers.Add(header.Key, header.Value);
                }
            }
        }

        public void CopyTo(IBasicProperties basicProperties)
        {
            Preconditions.CheckNotNull(basicProperties, "basicProperties");

            if(contentTypePresent)      basicProperties.ContentType      =  ContentType; 
            if(contentEncodingPresent)  basicProperties.ContentEncoding  =  ContentEncoding; 
            if(deliveryModePresent)     basicProperties.DeliveryMode     =  DeliveryMode; 
            if(priorityPresent)         basicProperties.Priority         =  Priority; 
            if(correlationIdPresent)    basicProperties.CorrelationId    =  CorrelationId; 
            if(replyToPresent)          basicProperties.ReplyTo          =  ReplyTo; 
            if(expirationPresent)       basicProperties.Expiration       =  Expiration; 
            if(messageIdPresent)        basicProperties.MessageId        =  MessageId; 
            if(timestampPresent)        basicProperties.Timestamp        =  new AmqpTimestamp(Timestamp); 
            if(typePresent)             basicProperties.Type             =  Type; 
            if(userIdPresent)           basicProperties.UserId           =  UserId; 
            if(appIdPresent)            basicProperties.AppId            =  AppId; 
            if(clusterIdPresent)        basicProperties.ClusterId        =  ClusterId;

            if (headersPresent)
            {
                basicProperties.Headers = new Hashtable(Headers);
            }
        }

        private bool contentTypePresent = false;
        private bool contentEncodingPresent = false;
        private bool headersPresent = false;
        private bool deliveryModePresent = false;
        private bool priorityPresent = false;
        private bool correlationIdPresent = false;
        private bool replyToPresent = false;
        private bool expirationPresent = false;
        private bool messageIdPresent = false;
        private bool timestampPresent = false;
        private bool typePresent = false;
        private bool userIdPresent = false;
        private bool appIdPresent = false;
        private bool clusterIdPresent = false;

        private string contentType;

        /// <summary>
        /// MIME Content type 
        /// </summary>
        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; contentTypePresent = true; }
        }

        private string contentEncoding;

        /// <summary>
        /// MIME content encoding 
        /// </summary>
        public string ContentEncoding
        {
            get { return contentEncoding; }
            set { contentEncoding = value; contentEncodingPresent = true; }
        }

        private IDictionary headers;

        /// <summary>
        /// message header field table 
        /// </summary>
        public IDictionary Headers
        {
            get { return headers; }
            set { headers = value; headersPresent = true; }
        }

        private byte deliveryMode;

        /// <summary>
        /// non-persistent (1) or persistent (2) 
        /// </summary>
        public byte DeliveryMode
        {
            get { return deliveryMode; }
            set { deliveryMode = value; deliveryModePresent = true; }
        }

        private byte priority;

        /// <summary>
        /// message priority, 0 to 9 
        /// </summary>
        public byte Priority
        {
            get { return priority; }
            set { priority = value; priorityPresent = true; }
        }

        private string correlationId;

        /// <summary>
        /// application correlation identifier 
        /// </summary>
        public string CorrelationId
        {
            get { return correlationId; }
            set { correlationId = value; correlationIdPresent = true; }
        }

        private string replyTo;

        /// <summary>
        /// destination to reply to 
        /// </summary>
        public string ReplyTo
        {
            get { return replyTo; }
            set { replyTo = value; replyToPresent = true; }
        }

        private string expiration;

        /// <summary>
        /// message expiration specification 
        /// </summary>
        public string Expiration
        {
            get { return expiration; }
            set { expiration = value; expirationPresent = true; }
        }

        private string messageId;

        /// <summary>
        /// application message identifier 
        /// </summary>
        public string MessageId
        {
            get { return messageId; }
            set { messageId = value; messageIdPresent = true; }
        }

        private long timestamp;

        /// <summary>
        /// message timestamp 
        /// </summary>
        public long Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; timestampPresent = true; }
        }

        private string type;

        /// <summary>
        /// message type name 
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; typePresent = true; }
        }

        private string userId;

        /// <summary>
        /// creating user id 
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; userIdPresent = true; }
        }

        private string appId;

        /// <summary>
        /// creating application id 
        /// </summary>
        public string AppId
        {
            get { return appId; }
            set { appId = value; appIdPresent = true; }
        }

        private string clusterId;

        /// <summary>
        /// intra-cluster routing identifier 
        /// </summary>
        public string ClusterId
        {
            get { return clusterId; }
            set { clusterId = value; clusterIdPresent = true; }
        }

        public bool ContentTypePresent
        {
            get { return contentTypePresent; }
            set { contentTypePresent = value; }
        }

        public bool ContentEncodingPresent
        {
            get { return contentEncodingPresent; }
            set { contentEncodingPresent = value; }
        }

        public bool HeadersPresent
        {
            get { return headersPresent; }
            set { headersPresent = value; }
        }

        public bool DeliveryModePresent
        {
            get { return deliveryModePresent; }
            set { deliveryModePresent = value; }
        }

        public bool PriorityPresent
        {
            get { return priorityPresent; }
            set { priorityPresent = value; }
        }

        public bool CorrelationIdPresent
        {
            get { return correlationIdPresent; }
            set { correlationIdPresent = value; }
        }

        public bool ReplyToPresent
        {
            get { return replyToPresent; }
            set { replyToPresent = value; }
        }

        public bool ExpirationPresent
        {
            get { return expirationPresent; }
            set { expirationPresent = value; }
        }

        public bool MessageIdPresent
        {
            get { return messageIdPresent; }
            set { messageIdPresent = value; }
        }

        public bool TimestampPresent
        {
            get { return timestampPresent; }
            set { timestampPresent = value; }
        }

        public bool TypePresent
        {
            get { return typePresent; }
            set { typePresent = value; }
        }

        public bool UserIdPresent
        {
            get { return userIdPresent; }
            set { userIdPresent = value; }
        }

        public bool AppIdPresent
        {
            get { return appIdPresent; }
            set { appIdPresent = value; }
        }

        public bool ClusterIdPresent
        {
            get { return clusterIdPresent; }
            set { clusterIdPresent = value; }
        }

        public void AppendPropertyDebugStringTo(StringBuilder stringBuilder)
        {
            GetType()
                .GetProperties()
                .Where(x => !x.Name.EndsWith("Present"))
                .Select(x => string.Format("{0}={1}", x.Name, GetValueString(x.GetValue(this, null))))
                .Intersperse(", ")
                .Aggregate(stringBuilder, (sb, x) =>
                {
                    sb.Append(x);
                    return sb;
                });
        }

        private string GetValueString(object value)
        {
            if (value == null) return "NULL";

            var dictionary = value as IDictionary;
            if (dictionary == null) return value.ToString();

            var stringBuilder = new StringBuilder();

            dictionary
                .EnumerateDictionary()
                .Select(x => string.Format("{0}={1}", x.Key, x.Value))
                .Intersperse(", ")
                .SurroundWith("[", "]")
                .Aggregate(stringBuilder, (sb, x) =>
                    {
                        sb.Append(x);
                        return sb;
                    });

            return stringBuilder.ToString();
        }
    }
}