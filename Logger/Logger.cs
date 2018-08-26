using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed class Log : ILogger
    {
        private static readonly Lazy<Log> _logger = new Lazy<Log>(() => new Log());

        private Log()
        {

        }

        public static Log GetLogger
        {

            get
            {
                return _logger.Value;
            }
        }

        public void LogMessage(string Message)
        {

            StringBuilder sb = this.GetStringBuilder();

            sb.AppendLine(String.Format("Message:{0}", Message));

            this.WriteLog(sb.ToString());

        }

        public void LogMessage(Exception exception)
        {

            StringBuilder sb = this.GetStringBuilder();

            sb.AppendLine(String.Format("Error:{0}", exception.Message));

            sb.AppendLine(String.Format("InnerException:{0}", exception.InnerException));

            this.WriteLog(sb.ToString());

        }

        private StringBuilder GetStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------------------------------------------------------------");
            sb.AppendLine(String.Format("{0}", DateTime.Now.ToString()));

            return sb;
        }

        private void WriteLog(string message)
        {
            string fileName = String.Format("{0}.log", DateTime.Now.ToShortDateString());

            string path = String.Format("{0}{1}", ConfigurationManager.AppSettings["LogFilePath"], fileName);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(message);
                sw.Flush();
            }
        }
    }
}
