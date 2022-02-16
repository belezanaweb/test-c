using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BelezaNaWeb.BuildingBlocks.Attributes
{
    public sealed class Produces201CreatedAttribute : ProducesResponseTypeAttribute
    {
        public Produces201CreatedAttribute(Type type = null)
            : base(type ?? typeof(void), StatusCodes.Status201Created)
        {
        }
    }
}
