namespace Application
{
    public interface IMapper<TDTO, TOutput>
    {
        public TOutput ToMap(TDTO dto);
    }
}
