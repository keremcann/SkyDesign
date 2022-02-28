using System;
using System.Collections.Generic;
using System.Text;

namespace SkyDesign.Core.Result
{
    public class Result
    {
        public List<string> Messages { get; private set; }
        public ResultType ResponseType { get; }
        public int Code { get; private set; }

        protected Result(ResultType helperResponseType) => ResponseType = helperResponseType;

        public Result AddMessage(string message)
        {
            Messages ??= new List<string>();
            Messages.Add(message);

            return this;
        }

        public Result WithCode(int code)
        {
            Code = code;
            return this;
        }

        public static Result SuccessResult => new Result(ResultType.Success);
        public static Result ErrorResult => new Result(ResultType.Error);
        public static Result InfoResult => new Result(ResultType.Info);
        public static Result WarningResult => new Result(ResultType.Warning);
    }
}