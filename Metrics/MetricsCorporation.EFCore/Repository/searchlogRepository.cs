namespace MetricsCorporation.EFCore.Repository
{
    public partial class searchlogRepository
    {
        protected override void BeforeInsert(Entities.searchlog entity)
        {
            entity.Active = true;
            base.BeforeInsert(entity);
        }
    }
}
