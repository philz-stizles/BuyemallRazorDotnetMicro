namespace OrderService.Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get;  }
    }
}