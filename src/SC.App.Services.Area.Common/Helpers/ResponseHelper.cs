using System.Collections.Generic;
using SC.App.Services.Area.Common.Enums;
using SC.App.Services.Area.Common.Responses;

namespace SC.App.Services.Area.Common.Helpers
{
    public class ResponseHelper
    {
        public static Response<T> Ok<T>(T data) where T : class
        {
            return new Response<T>
            {
                Status = EnumResponseStatus.OK,
                Data = data,
                Errors = new List<ResponseError>()
            };
        }

        public static Response<T> Error<T>(ICollection<ResponseError> errors) where T : class
        {
            return new Response<T>
            {
                Status = EnumResponseStatus.ERROR,
                Errors = errors
            };
        }
    }
}