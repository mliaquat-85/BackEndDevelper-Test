using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Models
{
    public class StackOverFlowQuestionData// : ISerializable
    {
        public StackOverFlowQuestionItemData[] items { get; set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("items", items);
        }
    }
    public class StackOverFlowQuestionItemData// : ISerializable
    {
        public string[] tags { get; set; }
        public StackOverFlowOwnerInfo owner { get; set; }

        [JsonProperty(PropertyName = "answer_count")]
        public int AnswerCount { get; set; }

        [JsonProperty(PropertyName = "question_id")]
        public string QuestionID { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Question { get; set; }


        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("owner", owner);
            info.AddValue("tags", tags);
            info.AddValue("AnswerCount", AnswerCount);
            info.AddValue("QuestionID", QuestionID);
            info.AddValue("Question", Question);
        }

    }
    public class StackOverFlowOwnerInfo// : ISerializable
    {
        public string account_id { get; set; }
        public string user_id { get; set; }
        public string user_type { get; set; }
        public string profile_image { get; set; }
        public string link { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string UserName { get; set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("UserName", UserName);
            info.AddValue("account_id", account_id);
            info.AddValue("user_id", user_id);
            info.AddValue("user_type", user_type);
            info.AddValue("profile_image", profile_image);
            info.AddValue("link", link);
        }

    }
    public class StackOverFlowAnswerItemData// : ISerializable
    {
        public string[] tags { get; set; }
        public StackOverFlowOwnerInfo owner { get; set; }

        [JsonProperty(PropertyName = "question_id")]
        public string QuestionID { get; set; }

        [JsonProperty(PropertyName = "answer_id")]
        public string AnswerID { get; set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("owner", owner);
            info.AddValue("tags", tags);
            info.AddValue("QuestionID", QuestionID);
            info.AddValue("AnswerID", AnswerID);
        }
    }

    public class StackOverFlowAnswerData// : ISerializable
    {
        public StackOverFlowAnswerItemData[] items { get; set; }


        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("items", items);
        }
    }


    public class StackOverFlowAPI
    {
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private T GetAPIReponse<T>(string o_url)
        {
            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var url = o_url + "?key=U4DMV*8nvpm3EOpvf69Rxw((&site=stackoverflow";


            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/json; charset=utf-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36";
            request.KeepAlive = true;
            request.AutomaticDecompression = DecompressionMethods.Deflate;

            object NULL = null;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var contenttype = response.ContentType;

                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                try
                {
                    var responseFromServer = reader.ReadToEnd();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseFromServer);
                }
                catch (Exception x)
                {
                }
                finally
                {
                    try
                    {
                        reader.Close();
                        dataStream.Close();
                        response.Close();
                    }
                    catch (Exception x)
                    {
                    }
                }
            }
            return (T)NULL;
        }

        public StackOverFlowQuestionData GetQuestions()
        {
            return GetAPIReponse<StackOverFlowQuestionData>("https://api.stackexchange.com/2.3/questions");
        }
        public StackOverFlowAnswerData GetAnswers(string question_id)
        {
            return GetAPIReponse<StackOverFlowAnswerData>(string.Format("https://api.stackexchange.com/2.3/questions/{0}/answers", question_id));
        }
    }
}