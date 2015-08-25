using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftWrapper.WebInterface
{
    public  class QueryResult
    {
        public QueryResult(int rowCount, bool hasResult, bool hasError, Exception ex)
        {
            this.RowCount = rowCount;
            this.HasResult = hasResult;
            this.HasError = hasError;
            this.Exception = ex;
        }

        public QueryResult(int rowCount)
        {
            this.RowCount = rowCount;
            this.HasResult = false;
            this.HasError = false;
            this.Exception = null;

            if (rowCount != -1)
            {
                this.HasResult = true;
            }
        }

        public QueryResult(Exception ex)
        {
            this.RowCount = -1;
            this.HasResult = false;
            this.HasError = true;
            this.Exception = ex;
        }

        private static QueryResult defaultResult = new QueryResult(0, false, false, null);

        public static QueryResult Default
        {
            get { return defaultResult ;}
        }

        public Boolean HasResultAndNoError
        {
            get
            {
                return hasResult && !hasError;
            }
        }

        int rowCount = 0;

        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value; }
        }
        bool hasResult = false;

        public bool HasResult
        {
            get { return hasResult; }
            set { hasResult = value; }
        }

        bool hasError = false;

        public bool HasError
        {
            get { return hasError; }
            set { hasError = value; }
        }

        Exception exception = null;

        public Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }
    }
}
