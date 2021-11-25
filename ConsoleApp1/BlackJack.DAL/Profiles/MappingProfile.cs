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
        public MappingProfile()
        {
            CreateMap<PlayerState, PlayerSessions>()
                .ForMember(x => x.Cards,
                           opt => opt.ConvertUsing(new SerializeConverter(), "CardsInHands"));
            CreateMap<PlayerSessions, PlayerState>()
                .ForMember(x => x.CardsInHands,
                           opt => opt.ConvertUsing(new DeserializeConverter(), "Cards"));

            CreateMap<TableSession, Sessions>()
                .ForMember(x => x.Cards,
                           opt => opt.ConvertUsing(new SerializeConverter(), "deck"))
                .ForMember(dst => dst.PlayerSessions, src => src.MapFrom((tblSession, session, i, context) =>
                    tblSession.players.Select(x => context.Mapper.Map<PlayerState, PlayerSessions>(x))));

            CreateMap<Sessions, TableSession>()
                .ForMember(x => x.deck,
                    opt => opt.ConvertUsing(new DeserializeConverter(), "Cards"))
                .ForMember(dst => dst.players, src => src.MapFrom((session, tblSession, i, context) =>
                    session.PlayerSessions.Select(x => context.Mapper.Map<PlayerSessions, PlayerState>(x))));
        }
    }
    public class CustomResolver : IValueResolver<int, string, int>
    {
        public int Resolve(int source, string destination, int member, ResolutionContext context)
        {
            return source;
        }
    }

    public class SerializeConverter : IValueConverter<Stack<Card>, string>
    {
        public string Convert(Stack<Card> source, ResolutionContext context)
        {
            return source == null ?
                String.Empty :
                JsonConvert.SerializeObject(source);
        }
    }
    public class DeserializeConverter : IValueConverter<string, Stack<Card>>
    {
        public Stack<Card> Convert(string source, ResolutionContext context)
        {
            return string.IsNullOrWhiteSpace(source) ?
                new Stack<Card>() : 
                JsonConvert.DeserializeObject<Stack<Card>>(source);
        }
    }
}