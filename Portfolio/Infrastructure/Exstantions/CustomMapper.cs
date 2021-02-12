using AutoMapper;


namespace Portfolio.Infrastructure.Exstantions
{
    public class CustomMapper<TEntity>
    {

     /*   public TEntity UpdatePortfolio(TEntity ViewModel, TEntity DTO, TEntity data)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ViewModel, DTO>()
               .ForMember(e => e.About_me, opt => opt.MapFrom(e => e.AboutAuthor))
            );
            var mapper = new Mapper(config);
            return mapper.Map<DTO>(data);
        }*/
    }
}
