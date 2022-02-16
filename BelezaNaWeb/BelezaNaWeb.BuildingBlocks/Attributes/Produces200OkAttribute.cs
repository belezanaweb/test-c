using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BelezaNaWeb.BuildingBlocks.Attributes
{
    public sealed class Produces200OkAttribute : ProducesResponseTypeAttribute
    {
        public Produces200OkAttribute(Type type = null)
            : base(type ?? typeof(void), StatusCodes.Status200OK)
        {
        }
    }
}
