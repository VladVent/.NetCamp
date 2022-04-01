using AutoMapper;
using BlackJack.DAL.Models;
using BlackJack.Logic;
using BlackJack.Types;
using Newtonsoft.Json;

#pragma warning disable CS8603 // Possible null reference return.
namespace BlackJack.DAL.Profiles
{
    public class MappingProfile : Profile
    {
    //    public MappingProfile()
    //    {

    //        CreateMap<TableSession, SessionDB>()
    //            .ForMember(x => x.deck, 
    //            src => src.MapFrom((x => x.deck));
    //    }
    //}
    //public class CustomResolver : IValueResolver<int, string, int>
    //{
    //    public int Resolve(int source, string destination, int member, ResolutionContext context)
    //    {
    //        return source;
    //    }
    //}

    //public class SerializeConverter : IValueConverter<Stack<Card>, string>
    //{
    //    public string Convert(Stack<Card> source, ResolutionContext context)
    //    {
    //        return source == null ?
    //            String.Empty :
    //            JsonConvert.SerializeObject(source);
    //    }
    //}
    //public class DeserializeConverter : IValueConverter<string, Stack<Card>>
    //{
    //    public Stack<Card> Convert(string source, ResolutionContext context)
    //    {
    //        return string.IsNullOrWhiteSpace(source) ?
    //            new Stack<Card>() : 
    //            JsonConvert.DeserializeObject<Stack<Card>>(source);
    //    }
    }
}