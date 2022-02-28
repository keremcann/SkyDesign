using System;
using System.Collections.Generic;
using System.Text;

namespace SkyDesign.Core.Result
{
    public class DataResult<TData> : Result
    {
        public TData Data { get; }
        public DataResult(ResultType helperResponseType, TData data) : base(helperResponseType) => Data = data;

        public static new DataResult<TData> SuccessResult(TData data) => new DataResult<TData>(ResultType.Success, data);
        public static new DataResult<TData> ErrorResult(TData data) => new DataResult<TData>(ResultType.Error, data);
        public static new DataResult<TData> InfoResult(TData data) => new DataResult<TData>(ResultType.Info, data);
        public static new DataResult<TData> WarningResult(TData data) => new DataResult<TData>(ResultType.Warning, data);
    }
}