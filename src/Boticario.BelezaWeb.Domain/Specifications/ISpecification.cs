/*
* https://www.codeproject.com/Tips/790758/Specification-and-Notification-Patterns
*/
namespace Boticario.BelezaWeb.Domain.Specifications
{
	public interface ISpecification<in T>
	{
		bool IsSatisfiedBy(T entity);
	}
}
