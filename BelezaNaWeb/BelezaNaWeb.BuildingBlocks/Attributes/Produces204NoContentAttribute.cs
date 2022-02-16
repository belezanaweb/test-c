using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BelezaNaWeb.BuildingBlocks.Attributes
{
    public sealed class Produces204NoContentAttribute : ProducesResponseTypeAttribute
    {
        public Produces204NoContentAttribute(Type type = null)
            : base(type ?? typeof(void), StatusCodes.Status204NoContent)
        {
        }
    }
}
