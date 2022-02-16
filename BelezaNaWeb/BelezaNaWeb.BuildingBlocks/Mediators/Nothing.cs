using System.Threading.Tasks;

namespace BelezaNaWeb.BuildingBlocks.Mediators
{
    public readonly struct Nothing
    {
        public static readonly Nothing Value = new Nothing();

        public static readonly Task<Nothing> Task = System.Threading.Tasks.Task.FromResult(Value);
    }
}
