﻿using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public class NotFoundException : ProductClientHubException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
