using BelezaNaWeb.BuildingBlocks.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.BuildingBlocks.Attributes
{
    public sealed class Produces400BadRequestAttribute : ProducesResponseTypeAttribute, IProducesErrorAttribute
    {
        public Produces400BadRequestAttribute(string ruleName)
            : base(typeof(ErrorResponse), StatusCodes.Status400BadRequest)
        {
            RuleName = ruleName;
        }

        public string RuleName { get; }
    }
}
