using BelezaNaWeb.BuildingBlocks.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.BuildingBlocks.Attributes
{
    public sealed class Produces404NotFoundAttribute : ProducesResponseTypeAttribute, IProducesErrorAttribute
    {
        public Produces404NotFoundAttribute(string ruleName = null)
            : base(typeof(ErrorResponse), StatusCodes.Status404NotFound)
        {
            RuleName = ruleName;
        }

        public string RuleName { get; }
    }
}
