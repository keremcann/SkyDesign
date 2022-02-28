using System;
using System.Collections.Generic;
using System.Text;

namespace SkyDesign.Core.Result
{
    public class ResultTypeChecker
    {
        /// <summary>
        /// returns all checked type responses if matches
        /// </summary>
        /// <param name="responseTypeToCheck"></param>
        /// <param name="helperResponses"></param>
        /// <returns></returns>
        public static IEnumerable<Result> CheckStatus(
            ResultType responseTypeToCheck,
            params Result[] helperResponses)
        {
            foreach (var response in helperResponses)
                if (response.ResponseType == responseTypeToCheck)
                    yield return response;
        }

        /// <summary>
        /// returns all checked type responses if not matches
        /// </summary>
        /// <param name="responseTypeToCheck"></param>
        /// <param name="helperResponses"></param>
        /// <returns></returns>
        public static IEnumerable<Result> CheckNotMatchedStatus(
            ResultType responseTypeToCheck,
            params Result[] helperResponses)
        {
            foreach (var response in helperResponses)
                if (response.ResponseType != responseTypeToCheck)
                    yield return response;
        }
    }
}