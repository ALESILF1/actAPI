using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Helper.Extension
{
    public static class ExceptionExtension
    {
        private static void ExplodeInnerException(Exception ex, ref StringBuilder sb)
        {
            if (ex.InnerException == null)
            {
                return;
            }
            sb.AppendLine("InnerException:");
            sb.AppendFormat("Exception: {0}. ", ex.Message);
            sb.AppendFormat("Callstack: {0}.\n", ex.StackTrace);

            ExceptionExtension.ExplodeInnerException(ex.InnerException, ref sb);
        }

        public static string FormatException(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder(1024);
            stringBuilder.AppendFormat("\nException: {0}. ", ex.Message);
            stringBuilder.AppendFormat("Callstack: {0}.\n", ex.StackTrace);

            ExceptionExtension.ExplodeInnerException(ex, ref stringBuilder);
            return stringBuilder.ToString();
        }
    }
}
